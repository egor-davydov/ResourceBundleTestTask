using System;
using System.Globalization;
using Code.StaticData.Item;
using Code.StaticData.ResourceBundle;
using Code.UI.Services.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
  public class ResourceBundleWindow : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Transform _itemsContainer;
    [SerializeField] private Image _iconImage;
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

    public void Initialize(ResourceBundleConfig config, Sprite icon)
    {
      _title.text = config.TitleText;
      _description.text = config.DescriptionText;
      SetupItems(config.Items);
      SetupIcon(icon);
      SetupPrice(config.Price, config.DiscountPercent);
    }

    private void SetupItems(ItemData[] items)
    {
      foreach (ItemData itemData in items)
        _uiFactory.CreateItem(itemData, _itemsContainer);
    }

    private void SetupIcon(Sprite icon)
    {
      _iconImage.sprite = icon;
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
        var priceWithDiscount = CalculatePriceWithDiscount(price, discountPercent);
        _priceAfterDiscount.text = GetPriceText(priceWithDiscount);
      }
    }

    private float CalculatePriceWithDiscount(float price, int discountPercent)
    {
      var priceWithDiscount = (float)Math.Round(price - price / 100 * discountPercent, 1);
      priceWithDiscount -= 0.01f;
      return priceWithDiscount;
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