using UnityEngine;
using UnityEngine.UI;
using Lifegame;

namespace UI
{    
    public class IntervalSelector : MonoBehaviour 
    {
        [SerializeField]
        private Slider _slider;

        private void Awake() 
        {
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            _slider.onValueChanged.AddListener(x => 
            {
                stage.CellsInterval = _slider.value;
            });
        }
    }
}