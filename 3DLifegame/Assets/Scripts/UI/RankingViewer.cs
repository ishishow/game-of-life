using UnityEngine;
using UnityEngine.UI;
using Network;
using Network.RequestDto;
using Network.ResponseDto;

namespace UI
{
    public class RankingViewer : MonoBehaviour
    {
        [SerializeField]
        private Button _close;
        [SerializeField]
        private Transform _contents;

        private void Awake()
        {
            _close.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });
            Show();
        }

        private void Show()
        {
            foreach (Transform tf in _contents)
            {
                Destroy(tf.gameObject);
            }
            var url = NetworkManager.Instance.GetMethod(MethodType.GetRanking);
            StartCoroutine(NetworkManager.Instance.WebRequest.Get<RankingLifeModelResponseDto>(url, response =>
            {
                var rank = 1;
                var factory = new LifemodelNodeFactory();
                foreach (var model in response.life_model_list)
                {
                    var obj = factory.Create();
                    var node = obj.GetComponent<LifemodelNode>();
                    node.Init(rank++, model);
                    obj.transform.SetParent(_contents);
                    obj.transform.localScale = Vector3.one;
                }
            },error =>
            {
                var factory = new DialogFactory();
                var dialog = factory.Create().GetComponent<Dialog>();
                dialog.Show(DialogType.AgreeOnly, error);
            }));
        }
    }
}