using UnityEngine;

namespace Code.StaticData
{
  [CreateAssetMenu(fileName = "ResourceBundles", menuName = "StaticData/ResourceBundles", order = 0)]
  public class ResourceBundlesStaticData : ScriptableObject
  {
    [field: SerializeField] public ResourceBundleConfig[] ResourceBundleConfigs { get; private set; }
  }
}