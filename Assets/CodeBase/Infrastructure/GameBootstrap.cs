using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameBootstrap : MonoBehaviour
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      _game.GameStateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(this);
    }
  }
}
