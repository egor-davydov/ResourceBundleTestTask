using Code.Constants;
using Code.Services;
using Code.StaticData.Item;
using Code.StaticData.ResourceBundle;
using Code.UI.Elements;
using UnityEngine;

namespace Code.UI.Services.Factories
{
  public class UIFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly StaticDataService _staticDataService;
    private readonly UIRootProvider _uiRootProvider;

    public UIFactory(AssetProvider assetProvider, StaticDataService staticDataService, UIRootProvider uiRootProvider)
    {
      _assetProvider = assetProvider;
      _staticDataService = staticDataService;
      _uiRootProvider = uiRootProvider;
    }

    public ResourceBundleWindow CreateResourceBundleWindow(ResourceBundleType resourceBundleType)
    {
      ResourceBundleConfig config = _staticDataService.ForResourceBundle(resourceBundleType);
      var resourceBundleWindowPrefab = _assetProvider.Load<ResourceBundleWindow>(AssetPath.ResourceBundleWindow);
      ResourceBundleWindow resourceBundleWindow = Object.Instantiate(resourceBundleWindowPrefab, _uiRootProvider.UIRoot);
      resourceBundleWindow.Construct(this);
      resourceBundleWindow.Initialize(config, _staticDataService.ForResourceBundleIcon(config.BundleIconName).Icon);
      return resourceBundleWindow;
    }

    public Item CreateItem(ItemData itemData, Transform parent)
    {
      ItemConfig itemConfig = _staticDataService.ForItem(itemData.Name);
      var itemPrefab = _assetProvider.Load<Item>(AssetPath.Item);
      Item item = Object.Instantiate(itemPrefab, parent);
      item.Initialize(itemConfig.Icon, itemData.Quantity);
      return item;
    }
  }
}