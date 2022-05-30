using UnityEngine;

namespace Assets.Scripts.Others
{
    public class OpenClose : MonoBehaviour
    {
        //instances
        public GameObject Panels;

        void Start()
        {
            Panels.SetActive(false);
        }

        public void OpenPanel()
        {
            if (Panels != null)
            {
                bool isActive = Panels.activeSelf;
                Panels.SetActive(true);
            }
        }


        public void ClosePanel()
        {
            if (Panels !=null)
            {
                Panels.SetActive(false);
            }
        }
    }
}
