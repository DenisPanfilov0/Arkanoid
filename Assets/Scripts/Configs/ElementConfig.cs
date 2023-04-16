using System;
using UnityEngine;

namespace DefaultNamespace.Ui
{
    [Serializable]
    public class ElementConfig
    {
        public ElementName Name;
        public Material Material;
        public string LayerName = "Default";
    }
}