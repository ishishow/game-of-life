using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lifegame;
using Network;
using Network.RequestDto;
using Network.ResponseDto;

namespace UI
{    
    public class GameManager : MonoBehaviour 
    {
        [SerializeField]
        private Stage _stage;
        [SerializeField]
        private Button _play;
        [SerializeField]
        private Button _pause;
        [SerializeField]
        private Button _reset;
        [SerializeField]
        private Button _save;

        private Coroutine _process = null;

        private void Awake() 
        {
            _play.onClick.AddListener(() =>
            {
                _play.interactable = false;
                _pause.interactable = true;
                if(!_stage.IsPause){ _process = StartCoroutine(_stage.Play()); }
                _stage.IsPause = false;
            });
            _pause.onClick.AddListener(() => 
            {
                _play.interactable = true;
                _pause.interactable = false;
                _stage.IsPause = true;
            });
            _reset.onClick.AddListener(() => 
            {
                if(_process != null){ StopCoroutine(_process); }
                _stage.Create(500);
                _play.interactable = true;
                _pause.interactable = true;
            });
            _save.onClick.AddListener(() => 
            {
                var map = new int[_stage.Width * _stage.Height * _stage.Length];
                var url = NetworkManager.Instance.GetMethod(MethodType.PostModelCreate);
                var tmp = 0;
                foreach(var cell in _stage.Map)
                {
                    map[tmp] = Convert.ToInt32(cell.IsAlive);
                }
                var request = new CreateLifeModelRequestDto()
                {
                    name = "test map",
                    map = map,
                };
                StartCoroutine(NetworkManager.Instance.WebRequest.Post<CreateLifeModelRequestDto, NoneResponseDto>(url, request, x =>
                {
                    SceneManager.LoadScene("Menu");
                }, error =>
                {
                    var factory = new DialogFactory();
                    var dialog = factory.Create().GetComponent<Dialog>();
                    dialog.Show(DialogType.AgreeOnly, error);
                }, true));
            });
        }
    }
}