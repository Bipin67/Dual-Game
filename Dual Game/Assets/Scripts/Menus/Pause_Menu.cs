using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class Pause_Menu : MonoBehaviour
    {
        //Instances
        public GameObject PauseMenu;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        //Pause 
        public void PauseGame()
        {
            //Enabling the menu
            PauseMenu.SetActive(true);
            //Pausing the time scale
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        //Restart
        public void ResumeGame()
        {
            //Disabling the Pause Menu
            PauseMenu.SetActive(false);
            //Resume the time scale
            Time.timeScale = 1;
        }

        //Restart
        public void RestartGame()
        {
            //Reloading the scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //calling method sto resume the game.
            ResumeGame();
        }
    }
}