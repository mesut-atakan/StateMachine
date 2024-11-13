using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public abstract class State : MonoBehaviour, IState
    {
        public abstract StateType stateType { get; }
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}