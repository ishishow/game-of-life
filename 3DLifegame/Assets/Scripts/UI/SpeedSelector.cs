using UnityEngine;
using UnityEngine.UI;
using Lifegame;

namespace UI
{    
    public class SpeedSelector : MonoBehaviour 
    {
        [SerializeField]
        private Slider _slider;

        private void Awake()
        {
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            stage.FrameDuration =  _slider.value;
            _slider.onValueChanged.AddListener(x => 
            {
                stage = GameObject.Find("Stage").GetComponent<Stage>();
                stage.FrameDuration =  _slider.value;
            });
        }
    }
}