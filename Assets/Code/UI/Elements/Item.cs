using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
  public class Item : MonoBehaviour
  {
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _quantity;

    public void Initialize(Sprite icon, int quantity)
    {
      _iconImage.sprite = icon;
      _quantity.text = quantity.ToString();
    }
  }
}