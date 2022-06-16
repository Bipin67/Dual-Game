using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlectedPlayer : MonoBehaviour
{
    public GameObject SelectedSkin;
    public GameObject Player;

    private Sprite _playerSprite;
    
    void Start()
    {
        _playerSprite = SelectedSkin.GetComponent<SpriteRenderer>().sprite;
        Player.GetComponent<SpriteRenderer>().sprite = _playerSprite;
    }
}
