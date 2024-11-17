using System;
using Code.UI.Elements.ResourceBundleWindow.View;

namespace Code.UI.Elements.ResourceBundleWindow.Model
{
  public class ResourceBundleWindowMarketingModel : ResourceBundleWindowModel
  {
    public ResourceBundleWindowMarketingModel(IResourceBundleWindowView view) : base(view)
    {
    }

    public override void SetupPrice(float price, int discountPercent)
    {
      bool discounted = discountPercent != 0;
      var priceWithDiscount = CalculatePriceWithDiscount(price, discountPercent);
      View.SetupPrice(price, priceWithDiscount, discountPercent, discounted);
    }

    private float CalculatePriceWithDiscount(float price, int discountPercent)
    {
      var priceWithDiscount = (float)Math.Round(price - price / 100 * discountPercent, 1);
      priceWithDiscount -= 0.01f;
      return priceWithDiscount;
    }
  }
}