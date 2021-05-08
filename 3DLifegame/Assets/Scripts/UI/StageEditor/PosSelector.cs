using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace UI.StageEditor
{    
    public class PosSelector : MonoBehaviour 
    {
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private TextMeshProUGUI _index;

        public int Index{ get{ return int.Parse(_index.text); } }
        public UnityEvent onValueChanged{ get; set;} = new UnityEvent();

        private void Awake() 
        {
            _slider.onValueChanged.AddListener(x =>
            {
                _index.text = _slider.value.ToString();
                onValueChanged.Invoke();
            });
        }
    }
}