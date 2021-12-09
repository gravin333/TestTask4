using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CodeBase.UI
{
  public class DropDownRow : MonoBehaviour, IPointerClickHandler
  {
    private UIResourceField _uiResourceField;
    private TextMeshProUGUI _selfText;
    public Image Image;

    private void Awake()
    {
      _uiResourceField = GetComponentInParent<UIResourceField>();
      _selfText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
      _selfText.text = $"{(int) Random.Range(0, 1000)}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      _uiResourceField.SetField(Image,_selfText);
    }
  }
}
