using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Assets;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.StateMachine
{
  public class GameStateMachine
  {
    private Dictionary<Type, IBaseState> _states;
    private IExitableState _activeState;
    public GameStateMachine(AllServices allServices, SceneLoader sceneLoader)
    {
      _states = new Dictionary<Type, IBaseState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this,allServices),
        [typeof(MainSceneState)] = new MainSceneState(this,sceneLoader,allServices.Single<IAsset>()),
      };
    }

    public void Enter<TState>() where TState : class,IBaseState
    {
      var state = ChangeState<TState>();
      state.Enter();
    }

    private TState ChangeState<TState>() where TState : class,IExitableState
    {
      _activeState?.Exit();
      var state = GetState<TState>();
      _activeState = state;
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState
    {
      return _states[typeof(TState)] as TState;
    }
  }
}