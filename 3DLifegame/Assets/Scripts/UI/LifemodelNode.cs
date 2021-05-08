using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Network;

namespace UI
{    
    public class LifemodelNode : MonoBehaviour, IPointerClickHandler 
    {
        [SerializeField]
        private TextMeshProUGUI _rank;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private LoadStageData _out;

        private LifeModel _model;

        public void Init(int rank, LifeModel model)
        {
            _model = model;
            _rank.text = rank.ToString();
            _name.text = model.name;
        }

        public void Init(LifeModel model)
        {
            _model = model;
            _rank.text = "";
            _name.text = model.name;
        }

        public void OnPointerClick(PointerEventData e)
        {
            _out.Copy(_model);
        }
    }
}