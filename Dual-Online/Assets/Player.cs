using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterBulletFire _bulletFirer;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.GetInstance()?.SetPlayer(this);
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
    }
}