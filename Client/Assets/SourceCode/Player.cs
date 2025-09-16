using UnityEngine;
using System;
using DevelopersHub.RealtimeNetworking.Client;


public class Player : MonoBehaviour
{
    public enum RequestID
    {
        AUTH = 1,
        SYNC = 2
    }

    private void Start()
    {
        RealtimeNetworking.OnLongReceived += ReceivedLong;
        RealtimeNetworking.OnStringReceived += ReceivedString;
        ConnectToServer();
    }

    private void ReceivedLong(int id, long value)
    {
        switch (id)
        {
            case 1: 
                Debug.Log(value);
                Sender.TCP_Send((int)RequestID.SYNC, SystemInfo.deviceUniqueIdentifier);
                break;
        }
    }

    private void ReceivedString(int id, string value)
    {
        switch (id)
        {
            case 2:
                Data.Player player = Data.Desrialize<Data.Player>(value);
                MainUI.instance._goldText.text = player.gold.ToString();
                MainUI.instance._elixirText.text = player.elixir.ToString();
                MainUI.instance._gemsText.text = player.gems.ToString();
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