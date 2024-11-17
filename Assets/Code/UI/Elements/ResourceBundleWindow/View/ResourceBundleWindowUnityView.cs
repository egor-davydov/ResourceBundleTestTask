using System;
using System.Globalization;
using Code.Services;
using Code.StaticData.Item;
using Code.UI.Services.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements.ResourceBundleWindow.View
{
  public class ResourceBundleWindowUnityView : MonoBehaviour, IResourceBundleWindowView
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
    [SerializeField] private Button _buyButton;

    private UIFactory _uiFactory;
    private StaticDataService _staticDataService;

    public void Construct(UIFactory uiFactory, StaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _uiFactory = uiFactory;
    }

    public event Action OnBuy;

    private void Awake()
    {
      _buyButton.onClick.AddListener(() => OnBuy?.Invoke());
    }

    public void SetupTitleAndDescription(string titleText, string description)
    {
      _title.text = titleText;
      _description.text = description;
    }
    public void SetupItems(ItemData[] items)
    {
      foreach (ItemData itemData in items)
        _uiFactory.CreateItem(itemData, _itemsContainer);
    }

    public void SetupIcon(string iconName)
    {
      _iconImage.sprite = _staticDataService.ForResourceBundleIcon(iconName).Icon;
    }

    public void SetupPrice(float price, float priceWithDiscount, int discountPercent, bool discounted)
    {
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