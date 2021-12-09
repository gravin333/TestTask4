using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine GameStateMachine;

    public Game()
    {
      GameStateMachine = new GameStateMachine(AllServices.Container,new SceneLoader());
    }
  }
}