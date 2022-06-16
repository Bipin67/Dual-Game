using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Audio
{
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
  
  /// <summary>
  /// Loads low Level Scene.
  /// </summary>
  public void LowLevel()
  {
   SceneManager.LoadScene("LowLevel");
  }
 }
}
