using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class IdleState : State
    {
        public override StateType stateType => StateType.Idle;

        public override void OnEnter()
        {
            Debug.Log("Karakter Beklemeye Gecti!");
        }

        public override void OnUpdate()
        {
            Debug.Log("Karakter Beklemeye Gecti!");
        }

        public override void OnExit()
        {
            Debug.Log("Karakter Beklemeyi Bitirdi!");
        }
    }
}