using System;
using UnityEngine;

namespace Code.StaticData.ResourceBundle
{
  [Serializable]
  public class ResourceBundleIconConfig
  {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
  }
}