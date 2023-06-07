#nullable enable
using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class PositionBroadCast : MonoBehaviour
{
    [SerializeField] private int port = 25550;
    [SerializeField] private int targetPort = 24000;

    private string? previous = null;

    private UdpClient udpClient = null!;

    private void Start()
    {
        udpClient = new UdpClient(port);
    }

    private void Update()
    {
        var position = transform.position;
        var message = $"{position.x}!{position.y}!{position.z}";
        if (previous == message)
        {
            return;
        }

        var array = Encoding.ASCII.GetBytes(message);
        udpClient.Send(array, array.Length, "localhost", targetPort);
        previous = message;
    }
}