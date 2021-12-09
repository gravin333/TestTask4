using System.Threading.Tasks;
using CodeBase.Infrastructure.Assets;
using UnityEngine;

namespace CodeBase.UI.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly IAsset _asset;

    private GameObject _ddPanel;


    public UIFactory(IAsset asset) =>
      _asset = asset;

    public GameObject RootUI { get; private set; }

    private async Task CreateRootCanvasIfNotExist()
    {
      if (RootUI == null)
        RootUI = await _asset.Instantiate(UIAssetPath.RootCanvas);
    }

    public async Task<bool> CreateDDPanel(Transform transform)
    {
      if (_ddPanel == null)
      {
        _ddPanel = await _asset.Instantiate(UIAssetPath.DDPanel, transform);
        return true;
      }
      else
      {
        DestroyDDPanel();
        return false;
      }
    }

    public void DestroyDDPanel()
    {
      if (_ddPanel != null)
        Object.Destroy(_ddPanel);
    }
  }
}