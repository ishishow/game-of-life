using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lifegame;
using Lifegame.Rules;

namespace UI
{    
    public class RuleSelector : MonoBehaviour 
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        private List<IRule> _rules = new List<IRule>();


        private void Awake() 
        {
            var options = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(p => p.Namespace == "Lifegame.Rules" && p.Name != "IRule").Select(s => s);
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            foreach(var type in types)
            {
                var rule = Activator.CreateInstance(type) as IRule;
                _rules.Add(rule);
                options.Add(rule.GetType().Name);
            }
            _dropdown.ClearOptions();
            _dropdown.AddOptions(options);
            stage.Rule = _rules[_dropdown.value];
            _dropdown.onValueChanged.AddListener(x =>
            {
                stage = GameObject.Find("Stage").GetComponent<Stage>();
                stage.Rule = _rules[_dropdown.value];
            });
        }
    }
}