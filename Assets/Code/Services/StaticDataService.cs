using System.Collections.Generic;
using System.Linq;
using Code.StaticData;
using Code.UI;
using UnityEngine;

namespace Code.Services
{
  public class StaticDataService
  {
    private const string StaticdataResourcebundles = "StaticData/ResourceBundles";
    
    private Dictionary<ResourceBundleType, ResourceBundleConfig> _resourceBundleConfigs;

    public void Initialize()
    {
      _resourceBundleConfigs = Resources.Load<ResourceBundlesStaticData>(StaticdataResourcebundles).ResourceBundleConfigs.ToDictionary(config => config.ResourceBundleType);
    }

    public ResourceBundleConfig ForResourceBundle(ResourceBundleType resourceBundleType) => 
      _resourceBundleConfigs[resourceBundleType];
  }
}