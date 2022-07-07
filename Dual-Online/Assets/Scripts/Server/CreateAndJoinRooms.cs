using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
   [SerializeField] public InputField CreateInput;
    public InputField JoinInput;
    public GameObject CharacterSelectPanel;
    public GameObject CreateJoinPanel;
    public Text RoomName;

    public List<PlayerItem> PlayerItemList = new List<PlayerItem>();
    public PlayerItem PlayerItemPrefab;
    public Transform PlayerItemParent;
    public GameObject PlayeButton;

    void Start()
    {
        CharacterSelectPanel.gameObject.SetActive(false);
    }

    public void CreateRoom()
    {
      if (CreateInput.text.Length>=1)
       {
            PhotonNetwork.CreateRoom(CreateInput.text,new RoomOptions(){MaxPlayers = 2,  BroadcastPropsChangeToAll = true});
            Debug.Log("Room Created" );
       }
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
        Debug.Log("Room Joined");
        CreateJoinPanel.gameObject.SetActive(false);
        CharacterSelectPanel.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        CreateJoinPanel.gameObject.SetActive(false);
        CharacterSelectPanel.gameObject.SetActive(true);
        RoomName.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    // public void JoinInRoom() 
    // {
    //     if(JoinInput.text.Length>=1)
    //     {
    //         CharacterSelectPanel.gameObject.SetActive(false);
    //         PhotonNetwork.LoadLevel("GameScene");
    //     }
    // }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        CharacterSelectPanel.gameObject.SetActive(false);

    }

    public override void OnLeftRoom()
    {
        CreateJoinPanel.gameObject.SetActive(false);
        CharacterSelectPanel.gameObject.SetActive(false);
    }

    void UpdatePlayerList()
    {
        //Destroy all the item  in the list and clear the list.
        foreach (PlayerItem item in PlayerItemList)
        {
            Destroy(item.gameObject);
        }
        PlayerItemList.Clear();
        
        //Check if the room is empty or not
        if (PhotonNetwork.CurrentRoom == null) 
        {
            return;
        }

        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log("key is ;"+player.Key );
            Debug.Log("joined player id is : "+player.Value.UserId);
            Debug.Log("Player Count is :"+ PhotonNetwork.CountOfPlayers);
            PlayerItem newPlayerItem = Instantiate(PlayerItemPrefab, PlayerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.LocalChange();
            }
            PlayerItemList.Add(newPlayerItem);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        UpdatePlayerList();
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >=2)
        {
            PlayeButton.SetActive(true);
        }
        else
        {
            PlayeButton.SetActive(false);
        }
    }

    public void OnClickPlayButton()
    {
        CharacterSelectPanel.gameObject.SetActive(false);
        PhotonNetwork.LoadLevel("GameScene");
    }
}
