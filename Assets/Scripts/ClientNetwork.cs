using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class ClientNetwork
{
    public bool socketReady = false;
    private TcpClient mySocket;
    private NetworkStream theStream;
    private StreamWriter theWriter;
    private StreamReader theReader;
    private Byte[] sizeBuf = new Byte[2];
    private Byte[] commandBuf = new Byte[2];
    private Byte[] dataBuf;

    public void Update()
    {
        if (socketReady && theStream.DataAvailable)
        {
            Int32 bytesSize = theStream.Read(sizeBuf, 0, 2);
            var sizeData = BitConverter.ToUInt16(sizeBuf, 0);
            dataBuf = new Byte[sizeData - 2];

            Int32 bytesData = theStream.Read(dataBuf, 0, sizeData - 2);

            Buffer.BlockCopy(dataBuf, 0, commandBuf, 0, 2);

            var commandData = BitConverter.ToUInt16(commandBuf, 0);
            var message = System.Text.Encoding.UTF8.GetString(dataBuf, 2, sizeData - 4);
            HandlePacket(commandData, message);
        }
        //theStream.Close();
        //mySocket.Close();
    }

    //private void OnApplicationQuit()
    //{
    //    closeSocket();
    //}
    public bool setupSocket(string Host, int Port)
    {
        try
        {
            mySocket = new TcpClient(Host, Port);
            mySocket.NoDelay = true;
            mySocket.Connect(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;

            return true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
            return false;
        }
    }

    public void HandlePacket(int command, string message)
    {
        switch (command)
        {
            case 1:
                Debug.Log("Hello from Server : " + message);
                break;

            default:
                break;
        }
    }

    public void WriteString(string theLine)
    {
        if (!socketReady) return;
        String foo = theLine + "\r\n";
        theWriter.Write(foo);
        theWriter.Flush();
    }

    public string ReadString()
    {
        if ((socketReady) && (mySocket.Connected))
        {
            if (theStream.DataAvailable)
                return theReader.ReadLine();
        }
        return "";
    }

    public void closeSocket()
    {
        if ((socketReady) && (mySocket.Connected))
        {
            theWriter.Close();
            theReader.Close();
            mySocket.Close();
            socketReady = false;
        }
    }
}