using Code.StaticData.ResourceBundle;
using Code.UI.Elements.ResourceBundleWindow.Model;
using Code.UI.Elements.ResourceBundleWindow.View;
using UnityEngine;

namespace Code.UI.Elements.ResourceBundleWindow.Controller
{
  public abstract class ResourceBundleWindowController
  {
    protected readonly ResourceBundleWindowModel Model;

    public ResourceBundleWindowController(ResourceBundleWindowModel model)
    {
      Model = model;
    }

    public abstract void BuyBundle();
  }

  class ResourceBundleWindowUnityController : ResourceBundleWindowController
  {
    public ResourceBundleWindowUnityController(ResourceBundleWindowModel model) : base(model)
    {
    }

    public void Initialize(ResourceBundleConfig config)
    {
      IResourceBundleWindowView view = Model.View;
      view.OnBuy += BuyBundle;
      view.SetupIcon(config.BundleIconName);
      view.SetupTitleAndDescription(config.TitleText, config.DescriptionText);
      view.SetupItems(config.Items);
      Model.SetupPrice(config.Price, config.DiscountPercent);
    }
    
    public override void BuyBundle()
    {
      Debug.Log("OnBuyButtonClick");
    }
  }
}