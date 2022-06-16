using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Character
{
    public class SkinManager : MonoBehaviour
    {
        //Public Instances
        public SpriteRenderer Sr;
        public List<Sprite> Skins = new List<Sprite>();
        public GameObject PlayerCharacter;

        private int _selectedskin = 0;


        public void NextCharacter()
        {
            _selectedskin = _selectedskin + 1;
            if (_selectedskin == Skins.Count)
            {
                _selectedskin = 0;
            }
            Sr.sprite = Skins[_selectedskin];
        }
        
        public void BackCharacter()
        {
            _selectedskin = _selectedskin - 1;
            if (_selectedskin < 0 )
            {
                _selectedskin = Skins.Count - 1;
            }
            Sr.sprite = Skins[_selectedskin];
        }

        public void PlayGame()
        {
            PrefabUtility.SaveAsPrefabAsset(PlayerCharacter, "Assets/Characters/SelectedSkin.prefab");
            SceneManager.LoadScene("GameScene");
        }
    }
}
