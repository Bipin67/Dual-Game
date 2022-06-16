using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
 public static  Audio_Manager Instance;
 public AudioSource MusicSource, FireSource;

 void Awake()
 {
  if (Instance == null)
  {
   Instance = this;
   DontDestroyOnLoad(gameObject);
  }
  else
  {
   Destroy(gameObject);
  }
 }

 /// <summary>
 /// Playing music in the whole game which doesnot changes.
 /// </summary>
 /// <param name="music"></param>
 public void PlayMusic(AudioClip music)
 {
  MusicSource.clip = music;
  MusicSource.Play();
 }

 /// <summary>
 /// Playing the sfx once.
 /// </summary>
 /// <param name="fire"></param>
 public void PlaySfx(AudioClip fire)
 {
  FireSource.PlayOneShot(fire);
 }

 /// <summary>
 /// Muting & Un-muting the music;
 /// </summary>
 public void ToggleMusic()
 {
  MusicSource.mute = !MusicSource.mute;
 }
 
 /// <summary>
 /// Muting & Un-muting the sfx.
 /// </summary>
 public void ToggleSfx()
 {
  FireSource.mute = !FireSource.mute;
 }
}
