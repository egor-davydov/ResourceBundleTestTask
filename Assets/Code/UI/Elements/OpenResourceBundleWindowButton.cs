using Code.UI.Services.Factories;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
  public class OpenResourceBundleWindowButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private ResourceBundleType _resourceBundleType;
    
    private UIFactory _uiFactory;

    public void Construct(UIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }

    private void Awake()
    {
      _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
      _uiFactory.CreateResourceBundleWindow(_resourceBundleType);
    }
  }
}