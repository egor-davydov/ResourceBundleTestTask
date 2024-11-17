using Code.Services;
using Code.UI.Elements;
using Code.UI.Services;
using Code.UI.Services.Factories;
using UnityEngine;

namespace Code.Infrastructure
{
  public class Bootstrap : MonoBehaviour
  {
    [SerializeField] private Transform _uiRoot;
    [SerializeField] private OpenResourceBundleWindowButton _openStarterPack;
    [SerializeField] private OpenResourceBundleWindowButton _openWoodBundle;
    private void Awake()
    {
      var uiRootProvider = new UIRootProvider
      {
        UIRoot = _uiRoot
      };
      var assetProvider = new AssetProvider();
      var staticDataService = new StaticDataService();
      staticDataService.Initialize();
      var uiFactory = new UIFactory(assetProvider,staticDataService,uiRootProvider);
      
      _openStarterPack.Construct(uiFactory);
      _openWoodBundle.Construct(uiFactory);
    }
  }
}