using UnityEngine;

namespace Code.Services
{
  public class AssetProvider
  {
    public T Load<T>(string assetKey) where T : Object => 
      Resources.Load<T>(assetKey);
  }
}