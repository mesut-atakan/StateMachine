using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class TargetState : State
    {
        public override StateType stateType => StateType.Target;

        public override void OnEnter()
        {
            Debug.Log("Karakter Takibe basladi");
        }

        public override void OnUpdate()
        {
            Debug.Log("Karakter Takibe Devam Ediyor");
        }

        public override void OnExit()
        {
            Debug.Log("Karakter Takibi Bitirdi");
        }
    }
}