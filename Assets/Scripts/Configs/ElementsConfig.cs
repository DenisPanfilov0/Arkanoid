using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Ui
{
    [CreateAssetMenu(menuName = nameof(ElementsConfig))]
    public class ElementsConfig : ScriptableObject
    {
        public ElementConfig[] Elements => _elements;
        
        [SerializeField] private ElementConfig[] _elements;
    }
}