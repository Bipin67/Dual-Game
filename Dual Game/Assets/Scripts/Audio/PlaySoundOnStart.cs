using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;
    void Start()
    {
        AudioManager.Instance.PlaySound(_clip);
        Debug.Log("Hello");
    }
}

