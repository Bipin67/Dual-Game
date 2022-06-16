using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
//Private Instances
    [SerializeField] private GameObject PauseMenu;
    void Start()
    {
        PauseMenu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
        AudioListener.volume = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        AudioListener.volume = 1;
        
        //If there is no any save data from the last game then setting volume to 100% i.e. 1
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
        }
        //else loading the save data from the last game sessions.
        else
        {
           Audio_Slider.Instance.Load();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
