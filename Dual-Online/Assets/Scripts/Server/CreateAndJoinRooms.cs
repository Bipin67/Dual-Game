using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
   [SerializeField] public InputField CreateInput;
    public InputField JoinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateInput.text);
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
