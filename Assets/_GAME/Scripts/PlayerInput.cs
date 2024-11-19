using System.Collections.Generic;
using NotsGame.Core.StateSystem;
using UnityEngine;

namespace NotsGame.GamePlay
{
    public class PlayerInput : MonoBehaviour
    {
        private StateMachine stateMachine = new StateMachine();

        private State _walkState;
        private State _sitState;

        private void Start()
        {
            _walkState = new State(new List<ICharacterAction> { new WalkAction(Vector2.up) });
            _sitState = new State(new List<ICharacterAction> { new SitAction() });

            stateMachine.ChangeState(_walkState);


        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                stateMachine.ChangeState(_walkState);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                stateMachine.ChangeState(_sitState);
            }

            stateMachine.Update(gameObject);
        }
    }
}