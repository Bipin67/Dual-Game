using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        //Public Instances
        public static AudioManager Instance;
        public AudioSource MusicSource, FireSource;

         private void Awake()
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
/// Playing  music in the game
/// The background music doesn't change in whole game.
/// </summary>
/// <param name="music"></param>
        public void PLayMusic(AudioClip music)
        {
            //Music Source doesn't change in whole game.
            MusicSource.clip = music;
            //Playing the music 
            MusicSource.Play();
        }
    
        /// <summary>
        /// Parameterized method with AudioClip parameter named fire which is played only at once.
        /// Fire sound in the game is played once it is called. 
        /// </summary>
        /// <param name="fire"></param>
        public void FireSound(AudioClip fire)
        {
            //Playing Fire Sound once.
            FireSource.PlayOneShot(fire);          
        }
        
        
    /// <summary>
    /// mute and unmute Audio music.
    /// </summary>
        public void ToggleMusic()
        {
            MusicSource.mute = !MusicSource.mute;
        }
        
        /// <summary>
        /// Mute and unmute Audio sfx
        /// </summary>
        public void ToggleSfx()
        {
            FireSource.mute = !FireSource.mute;
        }
    }
}


