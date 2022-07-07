using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn_Players : MonoBehaviour
{

    // public GameObject Player;
    public GameObject[] PlayerPrefs;
    public float MinX, MaxX;
    public float MinY, MaxY;
    // public float MinZ, MaxZ;
    void Start()
    {
        Vector3 RandomPosn = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY),-2f);
        GameObject playertoSpawn = PlayerPrefs[(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playertoSpawn.name, RandomPosn, quaternion.identity);
        Debug.Log("Player Spawned" + PlayerPrefs.Length);
    }

    
}
