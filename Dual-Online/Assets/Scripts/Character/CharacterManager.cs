using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterManager : MonoBehaviour
    {
        private static CharacterManager _instance { get; set; }
        private Player _humanPlayer;
        
        /// <summary> Making The Instance of CharacterManager.</summary>
        public static CharacterManager GetInstance()
        {
            return _instance == null ? FindObjectOfType<CharacterManager>() : _instance;
        }
        
        /// <summary>
        /// Assigning the value of the _humanPlayer.
        /// </summary>
        /// <param name="player"></param>
        public void SetPlayer(Player player)
        {
            _humanPlayer = player;
        }

        public void RemovePlayer()
        {
            _humanPlayer = null;
        }

        #region Player Actions

        public void FireBullet()
        {
            if (_humanPlayer == null) return;
            _humanPlayer.FireBullet();
        }

        public void ReloadBullet()
        {
            if (_humanPlayer == null) return;
            _humanPlayer.ReloadTheBullet();
        }

        #endregion
    }
}
