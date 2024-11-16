using System;
using Code.Services;
using Code.StaticData.Item;
using Code.StaticData.ResourceBundle;
using UnityEditor;

namespace Code.Editor
{
  [CustomEditor(typeof(ResourceBundlesStaticData))]
  public class ResourceBundlesStaticDataEditor : UnityEditor.Editor
  {
    private const int MinimumItemsLength = 3;
    private const int MaximumItemsLength = 6;
    
    private StaticDataService _staticDataService;
    private ResourceBundlesStaticData _resourceBundlesStaticData;

    private StaticDataService StaticDataService
    {
      get
      {
        if (_staticDataService == null)
        {
          _staticDataService = new StaticDataService();
          _staticDataService.Initialize();
        }

        return _staticDataService;
      }
    }

    private void OnEnable()
    {
      _resourceBundlesStaticData = ((ResourceBundlesStaticData)target);
    }

    public void OnValidate()
    {
      CheckItems();
      CheckIcons();
      CheckItemsLength();
    }

    private void CheckItems()
    {
      foreach (ResourceBundleConfig resourceBundleConfig in _resourceBundlesStaticData.ResourceBundleConfigs)
      {
        foreach (ItemData itemData in resourceBundleConfig.Items)
        {
          string itemDataName = itemData.Name;
          if (StaticDataService.ForItem(itemDataName) == null)
            throw new Exception($"No config found for item \"{itemDataName}\" in {resourceBundleConfig.ResourceBundleType}");
        }
      }
    }

    private void CheckIcons()
    {
      foreach (ResourceBundleConfig resourceBundleConfig in _resourceBundlesStaticData.ResourceBundleConfigs)
      {
        string bundleIconName = resourceBundleConfig.BundleIconName;
        if (StaticDataService.ForResourceBundleIcon(bundleIconName) == null)
          throw new Exception($"No resource bundle icon found for name \"{bundleIconName}\" in {resourceBundleConfig.ResourceBundleType}");
      }
    }

    private void CheckItemsLength()
    {
      foreach (ResourceBundleConfig resourceBundleConfig in _resourceBundlesStaticData.ResourceBundleConfigs)
      {
        int itemsLength = resourceBundleConfig.Items.Length;
        if (itemsLength >= MinimumItemsLength && itemsLength <= MaximumItemsLength)
          continue;
        throw new Exception($"Items length is {itemsLength} in resource bundle {resourceBundleConfig.ResourceBundleType}." +
                            $"Must be between {MinimumItemsLength} and {MaximumItemsLength}");
      }
    }
  }
}