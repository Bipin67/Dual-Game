using UnityEngine;

namespace Assets.Scripts.Others
{
    public class OpenClose : MonoBehaviour
    {
        //Public instances
        public GameObject Panels;

        void Start()
        {
            //Disabling the GameObject i.e. Panel at the start.
            Panels.SetActive(false);
        }

        /// <summary>
        /// If the panel is not opened then the panel will be set to true to open the panel. 
        /// </summary>
        public void OpenPanel()
        {
            //Checking if the panel is opened or not at first.
            if (Panels != null)
            {
                // If the panel is not opened before then it will be opened.
                bool isActive = Panels.activeSelf;
                Panels.SetActive(true);
            }
        }


        /// <summary>
        /// Closing the opened panel after checking if it is opened or not.
        /// </summary>
        public void ClosePanel()
        {
            //If the panel is opened then it will close the opened panel.
            if (Panels !=null)
            {
                // Closing the GameObject Panel.
                Panels.SetActive(false);
            }
        }
    }
}
