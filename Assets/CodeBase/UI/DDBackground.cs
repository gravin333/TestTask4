using System;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Factory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
  public class DDBackground : MonoBehaviour, IPointerClickHandler
  {
    private IUIFactory _uiFactory;

    private void Awake()
    {
      _uiFactory = AllServices.Container.Single<IUIFactory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      _uiFactory.DestroyDDPanel();
      gameObject.SetActive(false);
    }
  }
}
