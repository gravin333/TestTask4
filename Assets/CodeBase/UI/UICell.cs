using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UICell : MonoBehaviour
    {
        public Sprite sprite;
        public string cellName;
        private Image _image;
        private TextMeshProUGUI _textMeshProUGUI;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        

        public void SetCell()
        {
            _image = GetComponentInChildren<Image>();
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            _textMeshProUGUI.text = cellName;
            _image.sprite = sprite;
        }
    }
}
