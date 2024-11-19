using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class StateMachine
    {
        private State _currentState;
        
        public void ChangeState(State newState)
        {
            _currentState = newState;
        }

        public void Update(GameObject character)
        {
            _currentState?.Execute(character);
        }
    }
}