using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    //Private Instances
    [SerializeField] Slider _volumeSlider;
    
    void Start()
    {
        //If there is no any save data from the last game then setting volume to 100% i.e. 1
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
        }
        //else loading the save data from the last game sessions.
        else
        {
            Load();
        }
    }

    /// <summary>
    /// Changing the audio slider volume.
    /// And  saving the changed value.
    /// </summary>
    public void ChangeVolume()
    {
        //Changing the audio listener volume using slider.
        AudioListener.volume = _volumeSlider.value;
        //Calling the save method to save the changed value.
        Save();
    }

    /// <summary>
    /// Loading the changed value on game start.
    /// </summary>
    private void Load()
    {
        //Loading the save values from the player prefs.
        _volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    /// <summary>
    /// Saves the sliders volume changed value.
    /// </summary>
    private void Save()
    {
        //Saving the changed values from the slider.
        PlayerPrefs.SetFloat("volume", _volumeSlider.value);
    }
}