using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class RunningState : State
    {
        public override StateType stateType => StateType.Running;

        public override void OnEnter()
        {
            Debug.Log("Karakter Kosmaya basladi!");
        }

        public override void OnUpdate()
        {
            Debug.Log("Karakter Kosmaya Devam Ediyor!");
        }

        public override void OnExit()
        {
            Debug.Log("Karakter Kosmayi Bitirdi!");
        }
    }
}