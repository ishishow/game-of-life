using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lifegame.Rules;

namespace Lifegame
{    
    public class Cell : MonoBehaviour 
    {
        private List<Cell> _aroundCells = new List<Cell>();
        private bool _isNextAlive = false;

        public IEnumerable<Cell> AroundCells { get { return _aroundCells; }}
        public bool IsAlive 
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }
        public Vector3 Pos { get; set; }

        private void Awake() 
        {
            IsAlive = false;
        }

        public void AddAroundCell(Cell cell)
        {
            _aroundCells.Add(cell);
        }

        public void SetNextAlive(IRule rule)
        {
            _isNextAlive = rule.NextAlive(this);
        }

        public void Next()
        {
            IsAlive = _isNextAlive;
            _isNextAlive = false;
        }
    }
}