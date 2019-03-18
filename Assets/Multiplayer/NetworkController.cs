using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text status;

    private bool roomExists = false;

    public Camera cam;
    public GameObject field;
    public GameObject player;
    public GameObject ball;

    Vector3 pos;
    Quaternion rot;
    byte group = 0;
    bool gameReady = false;

    public Button buttonConnect;
    public Button buttonRandomMatch;
    public Button buttonDisconnect;

    public void Update()
    {
        if (roomExists)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && gameReady == false )
            {
                gameReady = true;

                buttonConnect.gameObject.SetActive(false);
                buttonRandomMatch.gameObject.SetActive(false);
                buttonDisconnect.gameObject.SetActive(false);
                status.text = "";
                status.gameObject.SetActive(false);

                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Instantiate(field.name, new Vector3(0, 0, 0), Quaternion.identity, group);
                    PhotonNetwork.Instantiate(ball.name, new Vector3(0, 0, 0), Quaternion.identity, group);
                }
            }

        }
    }

    public override void OnConnected()
    {
        Debug.Log("Conectou no servidor Photon."); 
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectou no master, procure uma sala...");
        status.text = "Status: please, match a room!";
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("NewRoom" + Random.Range(10, 1000));
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom ");
        roomExists = true;

        Debug.Log("PlayerCount: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(player.name, new Vector3(-8f, 0, 0), Quaternion.identity, group);
            status.text = "Status: Waiting for an opponent...";
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(player.name, new Vector3(8f, 0, 0), Quaternion.identity, group);
            status.text = "Status: Ready!!!";
        } 
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Desconectou do servidor: " + cause);
    }
}
