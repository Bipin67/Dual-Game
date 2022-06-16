using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Audio_Toggle : MonoBehaviour
{
    [SerializeField] private  bool _music, _sfx;

    /// <summary>
    /// Muting & Un-muting the musics & Sfx.
    /// </summary>
    public void Toggle()
    {
        if (_music) Audio_Manager.Instance.ToggleMusic();
        if(_sfx) Audio_Manager.Instance.ToggleSfx();
    }
}
