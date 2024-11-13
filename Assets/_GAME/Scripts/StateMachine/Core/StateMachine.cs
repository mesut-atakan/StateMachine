using Sirenix.OdinInspector;
using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State[] states;
        [SerializeField, ReadOnly] private State currentState;

        private int _currentStateIndex = 0;
        private int NextStateIndex => (++_currentStateIndex) % states.Length;

        private void Awake()
        {
            _currentStateIndex = 0;
        }

        private void Update()
        {
            currentState?.OnUpdate();
        }

        public void ChangeToState(StateType stateType)
        {
            State changeState = null;
            foreach (State state in states)
            {
                if (state.stateType == stateType)
                {
                    changeState = null;
                    break;
                }
            }

            if (changeState == null)
            {
                Debug.LogWarning("Aranan State Bulunamadi!", gameObject);
                return;
            }
            
            if (currentState != null)
            {
                currentState.OnExit();
            }
            currentState = changeState;
            currentState.OnEnter();
        }

        public void ChangeState(State state)
        {
            if (currentState != null && state != null)
            {
                currentState.OnExit();
            }

            currentState = state;
            currentState.OnEnter();
        }

        public void ChangeToNextState()
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = states[NextStateIndex];
            if (currentState != null)
            {
                currentState.OnEnter();
            }
        }
    }
}