using UnityEngine;
using UnityEngine.UI;
using Lifegame;

namespace UI.StageEditor
{    
    public class DeathOrAliver : MonoBehaviour 
    {
        [SerializeField]
        private Button _death;
        [SerializeField]
        private Button _alive;
        [SerializeField]
        private TargetSelector _targetSelector;

        private void Awake() 
        {
            _targetSelector.onChangeTarget.AddListener(() => 
            {
                var cell = _targetSelector.TargetCell;
                _death.interactable = cell.IsAlive;
                _alive.interactable = !cell.IsAlive;
            });
            _death.onClick.AddListener(() =>
            {
                var cell = _targetSelector.TargetCell;
                cell.IsAlive = false;
                _death.interactable = cell.IsAlive;
                _alive.interactable = !cell.IsAlive;
            });
            _alive.onClick.AddListener(() =>
            {
                var cell = _targetSelector.TargetCell;
                cell.IsAlive = true;
                _death.interactable = cell.IsAlive;
                _alive.interactable = !cell.IsAlive;
            });
        }
    }
}