using System;
using System.Globalization;
using Code.Helpers;
using Code.StaticData;
using Code.UI.Services.Factories;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
  public class ResourceBundleWindow : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Transform _itemsContainer;
    [SerializeField] private GameObject _withoutDiscountObject;
    [SerializeField] private GameObject _withDiscountObject;
    [SerializeField] private TextMeshProUGUI _priceWithoutDiscount;
    [SerializeField] private TextMeshProUGUI _discount;
    [SerializeField] private TextMeshProUGUI _priceBeforeDiscount;
    [SerializeField] private TextMeshProUGUI _priceAfterDiscount;

    private UIFactory _uiFactory;

    public void Construct(UIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }

    public void Initialize(ResourceBundleConfig config)
    {
      _title.text = config.TitleText;
      _description.text = config.DescriptionText;
      SetupPrice(config.Price, config.DiscountPercent);
      foreach (ItemConfig itemConfig in config.ItemConfigs) 
        _uiFactory.CreateItem(itemConfig, _itemsContainer);
    }

    private void SetupPrice(float price, int discountPercent)
    {
      bool discounted = discountPercent != 0;
      WithDiscount(discounted);
      var priceText = GetPriceText(price);
      if (!discounted)
      {
        _priceWithoutDiscount.text = priceText;
      }
      else
      {
        _discount.text = $"-{discountPercent}%";
        
        _priceBeforeDiscount.text = priceText;
        float priceWithDiscount = MathHelper.RoundDown(price - price / 100 * discountPercent, 2);
        _priceAfterDiscount.text = GetPriceText(priceWithDiscount);
      }
    }

    private string GetPriceText(float price) =>
      $"${price.ToString(CultureInfo.CurrentCulture)}";

    private void WithDiscount(bool discounted)
    {
      _withDiscountObject.SetActive(discounted);
      _withoutDiscountObject.SetActive(!discounted);
    }
  }
}