using System;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UI
{
  public class UIResourceField : MonoBehaviour , IPointerClickHandler
  {
    public TextMeshProUGUI TextMeshProUGUI;
    public Image Image;
    public Image Arrow;

    private IUIFactory _uiFactory;
    private ResourceTopPanel _resourceTopPanel;

    private void Awake()
    {
      _uiFactory = AllServices.Container.Single<IUIFactory>();
      _resourceTopPanel = GetComponentInParent<ResourceTopPanel>();
    }

    public async void SetField(Image image, TextMeshProUGUI textMeshProUGUI)
    {
      Image.sprite = image.sprite;
      TextMeshProUGUI.text = textMeshProUGUI.text;

      bool DDcreated = await _uiFactory.CreateDDPanel(transform);
      _resourceTopPanel.DDBackground.gameObject.SetActive(DDcreated);
    }

    public async void OnPointerClick(PointerEventData eventData)
    {
      bool DDcreated = await _uiFactory.CreateDDPanel(transform);
      _resourceTopPanel.DDBackground.gameObject.SetActive(DDcreated);
    }
  }
}
