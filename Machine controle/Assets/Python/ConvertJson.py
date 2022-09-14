import json
f = open(r'D:\Unitywork\Machine controle\Assets\JsonFiles\con_down.json')
data = json.load(f)
D = "data.data"
j = 0
for i in data:
    ageinfo = data[j]["_source"]["layers"]["data"]
    print(ageinfo)
    j = j+1
f.close()
