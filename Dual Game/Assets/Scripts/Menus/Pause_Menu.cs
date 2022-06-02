using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class Pause_Menu : MonoBehaviour
    {
        //Public Instances
        public GameObject PauseMenu;

        private void Start()
        {
            //Disabling the gameObject pauseMenu at start.
            PauseMenu.gameObject.SetActive(false);
        }

        /// <summary>
        /// When the pause menu is triggered in the game the game will be paused.
        /// The time scale will be 0.
        /// Audio Listener Volume will be zero.
        /// </summary>
        public void PauseGame()
        {
            //Enabling the menu
            PauseMenu.SetActive(true);
            //Pausing the time scale
            Time.timeScale = 0;
            //Disabling Audios in the game.
            AudioListener.volume = 0;
        }

        /// <summary>
        /// Pause Menu is disabled when triggered.
        /// Time scale will be set to 1 again to resume the game.
        /// </summary>
        public void ResumeGame()
        {
            //Disabling the Pause Menu
            PauseMenu.SetActive(false);
            //Resume the time scale
            Time.timeScale = 1;
            //Enabling Audios in the game.
            AudioListener.volume = 1;

        }

        /// <summary>
        /// Reloading the game from the scenemanger.
        /// Calling the resumeGame method to restart the game.
        /// </summary>
        public void RestartGame()
        {
            //Reloading the scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //calling method sto resume the game.
            ResumeGame();
        }
    }
}