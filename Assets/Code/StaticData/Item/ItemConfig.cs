using System;
using UnityEngine;

namespace Code.StaticData.Item
{
  [Serializable]
  public class ItemConfig
  {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
  }
}