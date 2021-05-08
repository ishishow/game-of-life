using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Lifegame;

namespace UI.StageEditor
{    
    public class TargetSelector : MonoBehaviour 
    {
        [SerializeField]
        private PosSelector _x;
        [SerializeField]
        private PosSelector _y;
        [SerializeField]
        private PosSelector _z;

        private Cell _targetCell = null;

        public Cell TargetCell{ get{ return _targetCell; } }
        public UnityEvent onChangeTarget{ get; set; } = new UnityEvent();

        private void Awake() 
        {
            _x.onValueChanged.AddListener(() => 
            {
                TargetSelect();
            });
            _y.onValueChanged.AddListener(() => 
            {
                TargetSelect();
            });
            _z.onValueChanged.AddListener(() => 
            {
                TargetSelect();
            });
        }

        private void TargetSelect()
        {
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            _targetCell = stage.Map[_x.Index, _y.Index, _z.Index];
            onChangeTarget.Invoke();
        }
    }
}