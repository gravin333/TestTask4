using System;
using UnityEngine;

namespace CodeBase.UI
{
  public class ResourceTopPanel : MonoBehaviour
  {
    private Camera _camera;
    [SerializeField] private DDBackground _ddBackground;
    public DDBackground DDBackground => _ddBackground;
  }
}