using UnityEngine;
using BestHTTP;
using BestHTTP.SocketIO;
using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;


public class SocketFunction : MonoBehaviour {
	
	/// <summary>
	/// The WebSocket address to connect
	/// </summary>
	string address = "ws://localhost:8080";

	/// <summary>
	/// Default text to send
	/// </summary>
	string msgToSend = "Hello World!";

	/// <summary>
	/// Debug text to draw on the gui
	/// </summary>
	string Text = string.Empty;

	/// <summary>
	/// Saved WebSocket instance
	/// </summary>
	SocketManager manager = new SocketManager(new Uri("http://localhost:8888/socket.io/"));

	/// <summary>
	/// GUI scroll position
	/// </summary>
	void Start () {
		manager.Socket.Emit("connectToServer", "{'token': '12cdcwev', 'username': 'phuc'}");
		manager.Socket.On("haha", OnMessage);
		manager.Socket.On("err", OnError);
	}



	// event handler
	void OnMessage(Socket socket, Packet packet, params object[] args)
	{
		Debug.Log(packet);
	}
	void OnError(Socket socket, Packet packet, params object[] args)
	{
		// args[0] is the nick of the sender
		// args[1] is the message
		Debug.Log(packet);
	}

	void Update () {
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		transform.position += new Vector3 (moveHorizontal, moveVertical, 0);
		if(moveVertical != 0 || moveHorizontal!= 0) manager.Socket.Emit("move","{x:"+transform.position.x+ "}");*/

	}
}
