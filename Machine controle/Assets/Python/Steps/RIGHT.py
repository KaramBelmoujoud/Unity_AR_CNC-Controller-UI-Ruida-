import socket
import json

f = open(r'D:\Unitywork\Machine controle\Assets\Python\right.json')

data = json.load(f)
D = "data.data"

# UDP_IP = "127.0.0.1"
# UDP_PORT = 5005

UDP_IP = "192.168.10.166"
UDP_PORT = 50200
# MESSAGE = b"\x02\x8d\xd0\xab\x89\x89"

print("UDP target IP: %s" % UDP_IP)
print("UDP target port: %s" % UDP_PORT)

j = 0
for i in data:
    MESSAGE = data[j]["_source"]["layers"]["data"][D].replace(':', '')

    # print("message: %s" % bytearray.fromhex(MESSAGE))
    sock = socket.socket(socket.AF_INET,  # Internet
                         socket.SOCK_DGRAM)  # UDP
    sock.bind(("", 40200))
    sock.sendto(bytearray.fromhex(MESSAGE), (UDP_IP, UDP_PORT))
    j = j+1
# print(data[0]["_source"]["layers"]["data"][D])
f.close()
