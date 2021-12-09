using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.StateMachine
{
  public class MainSceneState : IBaseState
  {
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private IAsset _asset;

    public MainSceneState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IAsset asset)
    {
      _asset = asset;
      _sceneLoader = sceneLoader;
      _gameStateMachine = gameStateMachine;
    }

    public void Exit()
    {
    }

    public void Enter()
    {
      _sceneLoader.LoadScene(SceneAssetPath.MainScreen,OnLoadScene);
    }

    private void OnLoadScene()
    {
      
    }
  }
}