using Sirenix.OdinInspector;
using UnityEngine;

namespace NotsGame.Core.NSM
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State[] states;
        [SerializeField, ReadOnly] private State currentState;

        private void Start()
        {
            ChangeToFirstState();
        }

        private void ChangeToState(State state)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }
            currentState = state;
            if (currentState != null)
            {
                currentState.OnEnter(transform);
            }
        }

        private void ChangeToNextState()
        {
            State state;
            state = states[NextStateIndex()];
            ChangeToState(state);
        }

        private void ChangeToFirstState()
        {
            ChangeToState(states[0]);
        }

        private void Update()
        {
            currentState?.OnUpdate();
        }

        private void FixedUpdate()
        {
            currentState?.OnFixedUpdate();
        }

        private int NextStateIndex()
        {
            int index = IndexOfCurrentState();
            return (index + 1) % states.Length;
        }

        private int IndexOfCurrentState()
        {
            int index = -1;
            if (currentState == null)
            {
                return index;
            }

            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] == currentState)
                {
                    return i;
                }
            }
            return index;
        }
    }
}