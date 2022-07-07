using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterBulletFire _bulletFirer;
    private PhotonView _view;


    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.GetInstance()?.SetPlayer(this);
        _view = GetComponent<PhotonView>();
        ReloadTheBullet();
    }

    private void OnDestroy()
    {
        CharacterManager.GetInstance()?.RemovePlayer();
    }

    public void ReloadTheBullet()
    {
        _bulletFirer.ReloadBullets();
    }

    public void FireBullet()
    {
        _bulletFirer.FireBullet();
        // Debug.Log("Bullet Fired From Gun");
    }
}