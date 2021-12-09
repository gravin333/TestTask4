using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameRunner : MonoBehaviour
  {
    [SerializeField] private GameObject BootstrapPrefab;

    private void Awake()
    {
      if (!FindObjectOfType<GameBootstrap>())
      {
        Instantiate(BootstrapPrefab);
      }

      gameObject.SetActive(false);
    }
  }
}