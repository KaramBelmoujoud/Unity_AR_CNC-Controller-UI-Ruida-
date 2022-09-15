using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

public class python_runner : MonoBehaviour
{
    public InputField IpText, PortText, XText, YText;
    string ip;
    int port;
    public InputField x, y;
    string PacketData = null;
    DataTransfer dataTransfer;
    [SerializeField]
    GameObject Data;

    void Update()
    {


    }

    void Awake()
    {
        dataTransfer = Data.GetComponent<DataTransfer>();
    }

    public class Root
    {
        [JsonProperty("data.data")]
        public string DataData { get; set; }

        [JsonProperty("data.len")]
        public string DataLen { get; set; }
    }

    public void SaveIpPort()
    {
        ip = IpText.text;
        port = int.Parse(PortText.text);
    }

    [HideInInspector]
    public int time = 0;
    [HideInInspector]
    public float X_pos = 0, Y_pos = 0;

    public void SaveXY()
    {
        float Xex = float.Parse(x.text), Yex = float.Parse(y.text);
        float MX = float.Parse(XText.text), MY = float.Parse(YText.text);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        if (Xex > MX)
        {
            Xex = MY;
        }
        if (Yex > MY)
        {
            Yex = MY;
        }

        if (X_pos < Xex)
        {
            float Xpos = ((Xex - X_pos) / 60f) * 1000;
            X_pos = Xex;
            string jsontext = dataTransfer.Con_Left;
            var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);

            for (int j = 0; j < Dt.Length; j++)
            {
                var data = Dt[j];
                PacketData = data.DataData;
                PacketData = PacketData.Replace(":", "");
                Debug.Log(PacketData);
                byte[] myData = new byte[PacketData.Length / 2];

                for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
                {
                    myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
                }
                myClient.Send(myData, myData.Length);
                time++;
                if (time == Dt.Length - 1)
                {
                    Debug.Log("LEFT " + Xpos);
                    Thread.Sleep((int)Xpos);
                }
            }
            time = 0;
        }
        else if (X_pos > Xex)
        {
            float Xpos = ((X_pos - Xex) / 60f) * 1000;
            X_pos = Xex;
            string jsontext = dataTransfer.Con_Right;
            var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);

            for (int j = 0; j < Dt.Length; j++)
            {
                var data = Dt[j];
                PacketData = data.DataData;
                PacketData = PacketData.Replace(":", "");
                Debug.Log(PacketData);
                byte[] myData = new byte[PacketData.Length / 2];

                for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
                {
                    myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
                }
                myClient.Send(myData, myData.Length);
                time++;
                Debug.Log(time);
                if (time == Dt.Length - 1)
                {
                    Debug.Log("RIGHT " + Xpos);
                    Thread.Sleep((int)Xpos);
                }
            }
            time = 0;
        }
        if (Y_pos < Yex)
        {
            float Ypos = ((Yex - Y_pos) / 60f) * 1000;
            Y_pos = Yex;
            string jsontext = dataTransfer.Con_Down;
            var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);

            for (int j = 0; j < Dt.Length; j++)
            {
                var data = Dt[j];
                PacketData = data.DataData;
                PacketData = PacketData.Replace(":", "");
                Debug.Log(PacketData);
                byte[] myData = new byte[PacketData.Length / 2];

                for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
                {
                    myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
                }
                myClient.Send(myData, myData.Length);
                time++;
                if (time == Dt.Length - 1)
                {
                    Debug.Log("DOWN " + Ypos);
                    Thread.Sleep((int)Ypos);
                }
            }
            time = 0;
        }
        else if (Y_pos > Yex)
        {
            float Ypos = ((Y_pos - Yex) / 60f) * 1000;
            Y_pos = Yex;
            string jsontext = dataTransfer.Con_Up;
            var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);

            for (int j = 0; j < Dt.Length; j++)
            {
                var data = Dt[j];
                PacketData = data.DataData;
                PacketData = PacketData.Replace(":", "");
                Debug.Log(PacketData);
                byte[] myData = new byte[PacketData.Length / 2];

                for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
                {
                    myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
                }
                myClient.Send(myData, myData.Length);
                time++;
                if (time == Dt.Length - 1)
                {
                    Debug.Log("UP " + Ypos);
                    Thread.Sleep((int)Ypos);
                }
            }
            time = 0;
        }
        myClient.Close();
    }

    public void LEFT()
    {
        string jsontext = dataTransfer.Left;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        // foreach (var data in Dt)
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }

    public void RIGHT()
    {
        string jsontext = dataTransfer.Right;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        // foreach (var data in Dt)
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }

    public void UP()
    {
        string jsontext = dataTransfer.Up;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        // foreach (var data in Dt)
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }

    public void DOWN()
    {
        string jsontext = dataTransfer.Down;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        // foreach (var data in Dt)
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }

    public void HOME()
    {
        string jsontext = dataTransfer.Home;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }
    [HideInInspector]
    public int t = 0;

    public void CON_LEFT()
    {
        string jsontext = dataTransfer.Con_Left;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
            t++;
            Debug.Log(t);
            if (j == 2)
            {
                break;
            }
        }
        myClient.Close();
    }

    public void CON_LEFT_STOP()
    {
        string jsontext = dataTransfer.Con_Left;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        Debug.Log(t);
        for (int j = t - 1; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        t = 0;
        myClient.Close();
    }

    public void CON_RIGHT()
    {
        string jsontext = dataTransfer.Con_Right;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
            t++;
            Debug.Log(t);
            if (j == 2)
            {
                break;
            }
        }
        myClient.Close();
    }

    public void CON_RIGHT_STOP()
    {
        string jsontext = dataTransfer.Con_Right;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        Debug.Log(t);
        for (int j = t - 1; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
            
        }
        t = 0;
        myClient.Close();
    }

    public void CON_UP()
    {
        string jsontext = dataTransfer.Con_Up;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
            t++;
            Debug.Log(t);
            if (j == 2)
            {
                break;
            }
        }
        myClient.Close();
    }

    public void CON_UP_STOP()
    {
        string jsontext = dataTransfer.Con_Up;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        Debug.Log(t);
        for (int j = t - 1; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        t = 0;
        myClient.Close();
    }

    public void CON_DOWN()
    {
        string jsontext = dataTransfer.Con_Down;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
            t++;
            Debug.Log(t);
            if (j == 2)
            {
                break;
            }
        }
        myClient.Close();
    }

    public void CON_DOWN_STOP()
    {
        string jsontext = dataTransfer.Con_Down;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        Debug.Log(t);
        for (int j = t - 1; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
 
        }
        t = 0;
        myClient.Close();
    }
    public void Stop_ALL()
    {
        string jsontext = dataTransfer.Emergency_Stop;
        var Dt = JsonConvert.DeserializeObject<Root[]>(jsontext);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
        UdpClient myClient = new UdpClient(40200);
        myClient.Connect(ep);
        for (int j = 0; j < Dt.Length; j++)
        {
            var data = Dt[j];
            PacketData = data.DataData;
            PacketData = PacketData.Replace(":", "");
            Debug.Log(PacketData);
            byte[] myData = new byte[PacketData.Length / 2];

            for (int i = 0, h = 0; h < PacketData.Length; i++, h += 2)
            {
                myData[i] = (byte)Int32.Parse(PacketData.Substring(h, 2), System.Globalization.NumberStyles.HexNumber);
            }
            Debug.Log(myData);
            myClient.Send(myData, myData.Length);
        }
        myClient.Close();
    }
}