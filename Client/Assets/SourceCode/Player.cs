using UnityEngine;
using System;
using DevelopersHub.RealtimeNetworking.Client;


public class Player : MonoBehaviour
{
    public enum RequestID
    {
        AUTH = 1
    }

    private void Start()
    {
        RealtimeNetworking.OnLongReceived += ReceiveLong;
        ConnectToServer();
    }

    private void ReceiveLong(int id, long value)
    {
        switch (id)
        {
            case 1: Debug.Log(value);
                break;
        }
    }

    private void ConnectionResponse(bool successfull)
    {
        if (successfull)
        {
            RealtimeNetworking.OnDisconnectedFromServer += DisconnectedFromServer;
            string device = SystemInfo.deviceUniqueIdentifier;
            Sender.TCP_Send((int)RequestID.AUTH, device);
        }
        else
        {
            //  TODO:   Connnection failed message box with retry button
        }
        RealtimeNetworking.OnConnectingToServerResult -= ConnectionResponse;
    }

    public void ConnectToServer()
    {
        RealtimeNetworking.OnConnectingToServerResult += ConnectionResponse;
        RealtimeNetworking.Connect();
    }

    private void DisconnectedFromServer()
    {
        RealtimeNetworking.OnDisconnectedFromServer -= DisconnectedFromServer;
        //  TODO:   Connnection failed message box with retry button
    }
}