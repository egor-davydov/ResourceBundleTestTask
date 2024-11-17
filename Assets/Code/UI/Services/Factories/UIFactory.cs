using Code.Constants;
using Code.Services;
using Code.StaticData.Item;
using Code.StaticData.ResourceBundle;
using Code.UI.Elements;
using Code.UI.Elements.ResourceBundleWindow.Controller;
using Code.UI.Elements.ResourceBundleWindow.Model;
using Code.UI.Elements.ResourceBundleWindow.View;
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

    public ResourceBundleWindowUnityView CreateResourceBundleWindow(ResourceBundleType resourceBundleType)
    {
      ResourceBundleConfig config = _staticDataService.ForResourceBundle(resourceBundleType);
      var resourceBundleWindowPrefab = _assetProvider.Load<ResourceBundleWindowUnityView>(AssetPath.ResourceBundleWindow);
      ResourceBundleWindowUnityView view = Object.Instantiate(resourceBundleWindowPrefab, _uiRootProvider.UIRoot);
      view.Construct(this, _staticDataService);
      var model = new ResourceBundleWindowMarketingModel(view);
      var controller = new ResourceBundleWindowUnityController(model);
      controller.Initialize(config);

      return view;
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