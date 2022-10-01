import socket
import json

f = open(r'D:\Unitywork\Machine controle\Assets\Python\right.json')

data = json.load(f)
D = "data.data"

j = 0
for i in data:
    MESSAGE = data[j]["_source"]["layers"]["data"][D].replace(':', '')

    # print("message: %s" % bytearray.fromhex(MESSAGE))
    sock = socket.socket(socket.AF_INET,  # Internet
                         socket.SOCK_DGRAM)  # UDP
    sock.bind(("", 40200))
    sock.sendto(bytearray.fromhex(MESSAGE), (UDP_IP, UDP_PORT))
    j = j+1
print(data[0]["_source"]["layers"]["data"][D])
f.close()
