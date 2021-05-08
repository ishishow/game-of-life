using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{    
    public class MenuManager : MonoBehaviour 
    {
        [SerializeField]
        private Button _createModel;
        [SerializeField]
        private Button _collection;
        [SerializeField]
        private Button _ranking;

        private void Awake()
        {
            _createModel.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Game");
            });
            _collection.onClick.AddListener(() => 
            {
                SceneManager.LoadScene("UsersCollection");
            });
            _ranking.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Ranking");
            });
        }
    }
}