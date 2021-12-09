
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Factory
{
  public interface IUIFactory
  {
    Task<bool> CreateDDPanel(Transform transform);
    void DestroyDDPanel();
  }
}