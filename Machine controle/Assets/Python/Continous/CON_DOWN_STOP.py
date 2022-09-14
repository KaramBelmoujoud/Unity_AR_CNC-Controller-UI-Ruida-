import socket
import json

# locate file json
f = open(r'D:\Unitywork\Machine controle\Assets\Python\con_down.json')
# "r" useD to reaD file as raw strings fix issue for DecoDe \U00000

# extract Data from json file
data = json.load(f)
# variable D to remove complexity of coDe
D = "data.data"


#############################################################

# senD Data to the test Data exchange
# UDP_IP = "127.0.0.1"
# UDP_PORT = 5005

# to send Data to the machine
UDP_IP = "192.168.10.166"
UDP_PORT = 50200

#############################################################

# MESSAGE = b"\x02\x8D\xD0\xab\x89\x89"
print("UDP target IP: %s" % UDP_IP)
print("UDP target port: %s" % UDP_PORT)

#############################################################

# loop to send all extracted Data from json file
j = 0

# for i in data:
# this should be changed based on the format your data is in store on the json file
MESSAGE = data[len(data)-1]["_source"]["layers"]["data"][D].replace(':', '')

# print("message: %s" % bytearray.fromhex(MESSAGE))
sock = socket.socket(socket.AF_INET,  # Internet
                     socket.SOCK_DGRAM)  # UDP
sock.bind(("", 40200))
sock.sendto(bytearray.fromhex(MESSAGE), (UDP_IP, UDP_PORT))
# j = j+1


f.close()
