using System;
using Code.StaticData.Item;

namespace Code.UI.Elements.ResourceBundleWindow.View
{
  public interface IResourceBundleWindowView
  {
    event Action OnBuy;
    void SetupTitleAndDescription(string titleText, string description);
    void SetupItems(ItemData[] items);
    void SetupIcon(string iconName);
    void SetupPrice(float price, float priceWithDiscount, int discountPercent, bool discounted);
  }
}