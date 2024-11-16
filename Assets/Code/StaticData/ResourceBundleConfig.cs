using System;
using System.Collections.Generic;
using Code.UI;
using UnityEngine;

namespace Code.StaticData
{
  [Serializable]
  public class ResourceBundleConfig
  {
    [field: SerializeField] public ResourceBundleType ResourceBundleType { get; private set; }
    [field: SerializeField] public string TitleText { get; private set; }
    [field: SerializeField] public string DescriptionText { get; private set; }
    [field: SerializeField] public ItemConfig[] ItemConfigs { get; private set; }
    [field: SerializeField] public float Price { get; private set; }
    [field: SerializeField, Range(0, 100)] public int DiscountPercent { get; private set; }
    [field: SerializeField] public string BundleIconName { get; private set; }
  }
}