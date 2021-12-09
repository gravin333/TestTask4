using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Factory;

namespace CodeBase.Infrastructure.StateMachine
{
  public class BootstrapState : IBaseState
  {
    private GameStateMachine _gameStateMachine;
    private AllServices _allServices;

    public BootstrapState(GameStateMachine gameStateMachine, AllServices allServices)
    {
      _allServices = allServices;
      _gameStateMachine = gameStateMachine;
      RegisterServices();
    }

    private void RegisterServices()
    {
      _allServices.RegisterSingle<IAsset>(new AssetProvider());
      _allServices.RegisterSingle<IUIFactory>(new UIFactory(_allServices.Single<IAsset>()));
    }

    public void Exit()
    {
    }

    public void Enter()
    {
      _gameStateMachine.Enter<MainSceneState>();
    }
    
  }
}