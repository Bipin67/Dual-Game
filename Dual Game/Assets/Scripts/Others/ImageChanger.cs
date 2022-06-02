using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Others
{
    public class ImageChanger : MonoBehaviour
    {
        //Public Instances
        public Image Original;
        public Sprite NewImage;

        /// <summary>
        /// Changing the image
        /// </summary>
        public void NewImg()
        {
            Original.sprite = NewImage;
        }

    }
}
