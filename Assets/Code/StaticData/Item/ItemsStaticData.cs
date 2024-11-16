using UnityEngine;

namespace Code.StaticData.Item
{
  [CreateAssetMenu(fileName = "Items", menuName = "StaticData/Items", order = 0)]
  public class ItemsStaticData : ScriptableObject
  {
    [field: SerializeField] public ItemConfig[] ItemConfigs { get; private set; }
  }
}