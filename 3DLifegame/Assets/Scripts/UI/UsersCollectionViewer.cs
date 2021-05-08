using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Network;
using Network.RequestDto;
using Network.ResponseDto;

namespace UI
{    
    public class UsersCollectionViewer : MonoBehaviour 
    {
        [SerializeField]
        private Transform _contents;
        [SerializeField]
        private Button _close;

        private void Awake() 
        {
            var factory = new LifemodelNodeFactory();
            var url = NetworkManager.Instance.GetMethod(MethodType.GetModelUser);
            StartCoroutine(NetworkManager.Instance.WebRequest.Get<ModelUsersResponseDto>(url, response =>
            {
                foreach(var model in response.life_model_list)
                {
                    var obj = factory.Create();
                    var node = obj.GetComponent<LifemodelNode>();
                    node.Init(model);
                    obj.transform.SetParent(_contents);
                    obj.transform.localScale = Vector3.one;
                }
            }));
            _close.onClick.AddListener(() => 
            {
                SceneManager.LoadScene("Menu");
            });
        }
    }
}