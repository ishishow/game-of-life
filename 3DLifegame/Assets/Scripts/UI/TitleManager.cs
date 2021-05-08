using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Network.RequestDto;
using Network.ResponseDto;

namespace UI
{    
    public class TitleManager : MonoBehaviour 
    {
        [SerializeField]
        private Button _startButton;
        [SerializeField]
        private TMP_InputField _inputField;

        private void Awake() 
        {
            _inputField.interactable = !AuthtokenManager.CanLoad;
            _inputField.onValueChanged.AddListener(x => 
            {
                _startButton.interactable =  !string.IsNullOrEmpty(_inputField.text);
            });
            _startButton.interactable = AuthtokenManager.CanLoad || !string.IsNullOrEmpty(_inputField.text);
            _startButton.onClick.AddListener(() => 
            {
                if(AuthtokenManager.CanLoad)
                {
                    var url = NetworkManager.Instance.GetMethod(MethodType.GetUser);
                    var token = AuthtokenManager.Load();
                    NetworkManager.Instance.WebRequest.SetToken(token);
                    StartCoroutine(NetworkManager.Instance.WebRequest.Get<UserGetResponseDto>(url, response =>
                    {
                        SceneManager.LoadScene("Menu");
                    }, error => 
                    {
                        var factory = new DialogFactory();
                        var dialog = factory.Create().GetComponent<Dialog>();
                        dialog.Show(DialogType.AgreeOnly, error);
                        _inputField.interactable = true;
                        _startButton.onClick.RemoveAllListeners();
                        _startButton.onClick.AddListener(() => { CreateUser(); });
                    }));
                }
                else
                {
                    CreateUser();
                }
            });
        }

        private void CreateUser()
        {
            var request = new UserCreateRequestDto()
            {
                name = _inputField.text,
            };
            var url = NetworkManager.Instance.GetMethod(MethodType.PostUserCreate);
            _inputField.interactable = true;
            StartCoroutine(NetworkManager.Instance.WebRequest.Post<UserCreateRequestDto, UserCreateResponseDto>(url, request, response =>
            {
                var token = response.token;
                NetworkManager.Instance.WebRequest.SetToken(token);
                AuthtokenManager.Save(token);
                SceneManager.LoadScene("Menu");
            }, Debug.LogError));
        }
    }
}