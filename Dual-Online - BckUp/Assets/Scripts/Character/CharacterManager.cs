using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public GameObject SelectedSkin;
        public GameObject Player;

        private Sprite _playerSprite;
        
        /// <summary>
        /// Loading the Selected character on Game-Object Player..
        /// </summary>
        void Start()
        {
            _playerSprite = SelectedSkin.GetComponent<SpriteRenderer>().sprite;
            Player.GetComponent<SpriteRenderer>().sprite = _playerSprite;
        }
    }
}
