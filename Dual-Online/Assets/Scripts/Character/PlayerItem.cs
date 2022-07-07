using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Player = Photon.Realtime.Player;


public class PlayerItem : MonoBehaviourPunCallbacks
{ 
    private Image _backgroundImage;
    public Text PlayerName;
    public Color HighlightColor;
    public GameObject LeftBtn;
    public GameObject RighBtn;

    private ExitGames.Client.Photon.Hashtable _playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] Avatars;
    Photon.Realtime.Player player;
    
    
    void Start()
    {
        _backgroundImage = GetComponent<Image>();
    }

    /// <summary>
    /// Setting the player nickname.
    /// </summary>
    /// <param name="_player"></param>
    public void SetPlayerInfo(Photon.Realtime.Player _player)
   {
      PlayerName.text = _player.NickName;
      player = _player;
      UpdatePlayerItem(player);
   }
    
    public void LocalChange()
    {
        // _backgroundImage.color = HighlightColor;
        LeftBtn.SetActive(true);
        RighBtn.SetActive(true);
    }

    public void OnClickLeftButton()
    {
        Debug.Log("Left Button Clicked");
        if ((int)_playerProperties["playerAvatar"] == 0)
        {
            _playerProperties["playerAvatar"] = Avatars.Length - 1;
            
        }
        else
        {
            _playerProperties["playerAvatar"] = (int)_playerProperties["playerAvatar"] - 1 ;
        }
        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }
    
    public void OnClickRightButton()
    {
        Debug.Log("Right Button Clicked");

        if ((int)_playerProperties["playerAvatar"] == Avatars.Length - 1)
        {
            _playerProperties["playerAvatar"] = 0;
        }
        else
        {
            _playerProperties["playerAvatar"] = (int)_playerProperties["playerAvatar"] + 1 ;
        }
        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps){
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    private void UpdatePlayerItem(Photon.Realtime.Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = Avatars[(int) player.CustomProperties["playerAvatar"]];
            _playerProperties["playerAvatar"] = (int) player.CustomProperties["playerAvatar"];
        }
        else
        {
            _playerProperties["playerAvatar"] = 0;
        }
    }
}
