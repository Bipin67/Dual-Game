using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using UnityEngine;

public class ToggleAudios : MonoBehaviour
{
    [SerializeField] private bool _music, _sfx;

    /// <summary>
    /// if bool is music then toggle music on or off.
    /// if bool is sfx then toggle sfx on or off.
    /// </summary>
    public void Toggle()
    {
        //if bool is music then calling instance of AudioManager Class method ToggleMusic to make on or off music.
        if (_music)
        {
            AudioManager.Instance.ToggleMusic();
        }
        
        //if bool is music then calling instance of AudioManager Class method Toggle sfx to make on or off sfx.
        if (_sfx)
        {
            AudioManager.Instance.ToggleSfx();
        }
    }
}
