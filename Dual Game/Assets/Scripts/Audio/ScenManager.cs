using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
 /// <summary>
 /// Loads Main Menu Scene
 /// </summary>
 public void MainMenu()
 {
  SceneManager.LoadScene("MainMenu");
 } 
 
 /// <summary>
 /// Loads Hard level scene.
 /// </summary>
 public void HardLevel()
 {
  SceneManager.LoadScene("HardLevel");
 } 
 
 /// <summary>
 /// Loads Medium Level Scene.
 /// </summary>
 public void MediumLevel()
 {
  SceneManager.LoadScene("MediumLevel");
 }
}
