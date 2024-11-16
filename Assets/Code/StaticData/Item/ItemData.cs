using System;
using UnityEngine;

namespace Code.StaticData.Item
{
  [Serializable]
  public struct ItemData
  {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, Min(1)] public int Quantity { get; private set; }
  }
}