using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_Close : MonoBehaviour
{
    //Private Instances
    [SerializeField] private GameObject Panels;

    /// <summary>
    /// Disabling the game object at start.
    /// </summary>
    void Start()
    {
        Panels.gameObject.SetActive(false);
    }

    /// <summary>
    /// Enabling the game object
    /// </summary>
    public void Open()
    {
        Panels.gameObject.SetActive(true);
    }

    public void Close()
    {
        Panels.gameObject.SetActive(false);
    }

    public void ChangeScenes()
    {
        SceneManager.LoadScene("OfflIneGameScene");
    }
}
