using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Spawn_Players : MonoBehaviour
{

    public GameObject Player;
    public float MinX, MaxX;
    public float MinY, MaxY;
    void Start()
    {
        Vector2 RandomPosn = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        PhotonNetwork.Instantiate(Player.name, RandomPosn, Quaternion.identity);
        Debug.Log("Player Spawned" + Player);
    }

    
}
