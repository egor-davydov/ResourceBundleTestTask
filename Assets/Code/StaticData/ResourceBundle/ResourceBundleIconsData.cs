using UnityEngine;

namespace Code.StaticData.ResourceBundle
{
  [CreateAssetMenu(fileName = "ResourceBundleIcons", menuName = "StaticData/ResourceBundleIcons", order = 0)]
  public class ResourceBundleIconsData : ScriptableObject
  {
    [field: SerializeField] public ResourceBundleIconConfig[] Configs { get; private set; }
  }
}