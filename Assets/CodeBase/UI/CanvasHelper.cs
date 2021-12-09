using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
  public static readonly UnityEvent ONOrientationChange = new UnityEvent();
  public static readonly UnityEvent ONResolutionChange = new UnityEvent();
  public static bool IsLandscape { get; private set; }

  private static List<CanvasHelper> helpers = new List<CanvasHelper>();

  private static bool _screenChangeVarsInitialized = false;
  private static ScreenOrientation _lastOrientation = ScreenOrientation.Portrait;
  private static Vector2 _lastResolution = Vector2.zero;
  private static Rect _lastSafeArea = Rect.zero;

  private Canvas _canvas;
  private RectTransform _rectTransform;

  [SerializeField] private RectTransform safeAreaTransform;

  void Awake()
  {
    if (!helpers.Contains(this))
      helpers.Add(this);

    _canvas = GetComponent<Canvas>();
    _rectTransform = GetComponent<RectTransform>();

    if (!_screenChangeVarsInitialized)
    {
      _lastOrientation = Screen.orientation;
      _lastResolution.x = Screen.width;
      _lastResolution.y = Screen.height;
      _lastSafeArea = Screen.safeArea;

      _screenChangeVarsInitialized = true;
    }
  }

  void Start()
  {
    ApplySafeArea();
  }

  void Update()
  {
    if (helpers[0] != this)
      return;

    if (Application.isMobilePlatform)
    {
      if (Screen.orientation != _lastOrientation)
        OrientationChanged();

      if (Screen.safeArea != _lastSafeArea)
        SafeAreaChanged();
    }
    else
    {
      if (Screen.width != _lastResolution.x || Screen.height != _lastResolution.y)
        ResolutionChanged();
    }
  }

  void ApplySafeArea()
  {
    if (safeAreaTransform == null)
      return;

    var safeArea = Screen.safeArea;

    var anchorMin = safeArea.position;
    var anchorMax = safeArea.position + safeArea.size;
    var pixelRect = _canvas.pixelRect;
    anchorMin.x /= pixelRect.width;
    anchorMin.y /= pixelRect.height;
    anchorMax.x /= pixelRect.width;
    anchorMax.y /= pixelRect.height;

    safeAreaTransform.anchorMin = anchorMin;
    safeAreaTransform.anchorMax = anchorMax;
  }

  void OnDestroy()
  {
    if (helpers != null && helpers.Contains(this))
      helpers.Remove(this);
  }

  private static void OrientationChanged()
  {
    _lastOrientation = Screen.orientation;
    _lastResolution.x = Screen.width;
    _lastResolution.y = Screen.height;

    IsLandscape = _lastOrientation == ScreenOrientation.LandscapeLeft || _lastOrientation == ScreenOrientation.LandscapeRight || _lastOrientation == ScreenOrientation.Landscape;
    ONOrientationChange.Invoke();
  }

  private static void ResolutionChanged()
  {
    if (_lastResolution.x == Screen.width && _lastResolution.y == Screen.height)
      return;

    _lastResolution.x = Screen.width;
    _lastResolution.y = Screen.height;

    IsLandscape = Screen.width > Screen.height;
    ONResolutionChange.Invoke();
  }

  private static void SafeAreaChanged()
  {
    if (_lastSafeArea == Screen.safeArea)
      return;

    _lastSafeArea = Screen.safeArea;

    for (int i = 0; i < helpers.Count; i++)
    {
      helpers[i].ApplySafeArea();
    }
  }

  private static Vector2 GetCanvasSize()
  {
    return helpers[0]._rectTransform.sizeDelta;
  }

  public static Vector2 GetSafeAreaSize()
  {
    for (int i = 0; i < helpers.Count; i++)
    {
      if (helpers[i].safeAreaTransform != null)
      {
        return helpers[i].safeAreaTransform.sizeDelta;
      }
    }

    return GetCanvasSize();
  }
}