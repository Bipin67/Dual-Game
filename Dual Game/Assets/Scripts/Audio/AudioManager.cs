using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        [SerializeField] private AudioSource _music, _bulletHit, _bulletFire;
        // public AudioClip BulletFireSound;

        void Awake()
        {
            if (Instance = null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            _bulletFire.PlayOneShot(clip);
            // _bulletHit.PlayOneShot(clip);
        }

    
        // public void PlaySoundEnum(clipName soundName)
        // {
        //     switch (soundName)
        //     {
        //         case clipName.bulletfire:
        //             _bulletFire.PlayOneShot(BulletFireSound);
        //             break;
        //     }
        // }

    }
}

// public enum clipName
// {
//     bulletfire,
//     gamecomplete
// }
