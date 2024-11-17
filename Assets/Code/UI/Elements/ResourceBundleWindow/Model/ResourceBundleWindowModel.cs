using Code.UI.Elements.ResourceBundleWindow.View;

namespace Code.UI.Elements.ResourceBundleWindow.Model
{
  public abstract class ResourceBundleWindowModel
  {
    public readonly IResourceBundleWindowView View;

    protected ResourceBundleWindowModel(IResourceBundleWindowView view)
    {
      View = view;
    }

    public abstract void SetupPrice(float price, int discountPercent);
  }
}