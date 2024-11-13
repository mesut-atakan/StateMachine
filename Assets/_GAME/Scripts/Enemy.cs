using NotsGame.Core.StateSystem;
using UnityEngine;

namespace NotsGame.GamePlay.CharacterSystem
{
    [RequireComponent(typeof(StateMachine), typeof(PatrolState))]
    public class Enemy : MonoBehaviour
    {

        private StateMachine _stateMachine;
        private PatrolState _patrolState;

        private void Awake()
        {
            _stateMachine = GetComponent<StateMachine>();
            _patrolState = GetComponent<PatrolState>();
            
            _stateMachine.ChangeState(_patrolState);
        }
    }
}