using System.Collections.Generic;
using System.Linq;
using Code.StaticData.Item;
using Code.StaticData.ResourceBundle;
using Code.UI;
using UnityEngine;

namespace Code.Services
{
  public class StaticDataService
  {
    private const string ResourceBundlesPath = "StaticData/ResourceBundles";
    private const string ResourceBundleIconsPath = "StaticData/ResourceBundleIcons";
    private const string ItemsPath = "StaticData/Items";

    private Dictionary<ResourceBundleType, ResourceBundleConfig> _resourceBundleConfigs;
    private Dictionary<string, ItemConfig> _items;
    private Dictionary<string, ResourceBundleIconConfig> _resourceBundleIcons;

    public void Initialize()
    {
      _resourceBundleConfigs = Resources.Load<ResourceBundlesStaticData>(ResourceBundlesPath).ResourceBundleConfigs.ToDictionary(config => config.ResourceBundleType);
      _items = Resources.Load<ItemsStaticData>(ItemsPath).ItemConfigs.ToDictionary(config => config.Name);
      _resourceBundleIcons = Resources.Load<ResourceBundleIconsData>(ResourceBundleIconsPath).Configs.ToDictionary(config => config.Name);
    }

    public ItemConfig ForItem(string itemName)
    {
      return _items.TryGetValue(itemName, out ItemConfig item)
        ? item
        : default;
    }

    public ResourceBundleIconConfig ForResourceBundleIcon(string iconName)
    {
      return _resourceBundleIcons.TryGetValue(iconName, out ResourceBundleIconConfig icon) 
        ? icon 
        : default;
    }

    public ResourceBundleConfig ForResourceBundle(ResourceBundleType resourceBundleType) =>
      _resourceBundleConfigs[resourceBundleType];
  }
}