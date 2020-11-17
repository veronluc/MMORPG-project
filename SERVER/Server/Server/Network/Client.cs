using Server.Network.Messages;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Network
{
    public class Client
    {
        public DataInterfaceForNetwork data;

        public static int dataBufferSize = 4096;
        bool isConnected = false;

        public string ip = "127.0.0.1";
        public int port = 26950;
        public int myId = 0;

        public TcpClient socket;

        private NetworkStream stream;
        private byte[] receiveBuffer;

        void UpdateLog(int id, string msg)
        {
            //Debug.Log("\n(" + id + ") sended : <i>" + msg + "</i>.");
            //Log.text += "OK";
        }

        public Client()
        {
            ConnectToServer();
        }
       
        public void ConnectToServer()
        {
           
        }


        private void ConnectCallback(IAsyncResult _result)
        {
           
        }


        private void ReceiveCallback(IAsyncResult _result)
        {
           
        }

        private bool HandleData(byte[] _data)
        {
            
            return true;
        }
        private void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                socket.Close();
                //Debug.Log("Disconnected from server.");
            }
            stream = null;
            receiveBuffer = null;
            socket = null;
        }


        //Packets
        public void SendData(Packet _packet)
        {
           
        }

        public void DebugIt(string mes)
        {
            //Debug.Log(mes);
        }
    }
}
