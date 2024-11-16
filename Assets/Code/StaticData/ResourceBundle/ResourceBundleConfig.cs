using System;
using Code.StaticData.Item;
using Code.UI;
using UnityEngine;

namespace Code.StaticData.ResourceBundle
{
  [Serializable]
  public struct ResourceBundleConfig
  {
    [field: SerializeField] public ResourceBundleType ResourceBundleType { get; private set; }
    [field: SerializeField] public string TitleText { get; private set; }
    [field: SerializeField] public string DescriptionText { get; private set; }
    [field: SerializeField] public ItemData[] Items { get; private set; }
    [field: SerializeField, Min(0)] public float Price { get; private set; }
    [field: SerializeField, Range(0, 100)] public int DiscountPercent { get; private set; }
    [field: SerializeField] public string BundleIconName { get; private set; }
  }
}