using UnityEngine;

namespace NotsGame.Core.NSM
{
    public abstract class State : ScriptableObject
    {
        public Transform stateOwner;
        public virtual void OnEnter(Transform stateOwner)
        {
            if (stateOwner != null)
            {
                this.stateOwner = stateOwner;
            }
        }

        public virtual void OnExit()
        {
            if (stateOwner != null)
            {
                stateOwner = null;
            }
        }

        public virtual void OnUpdate() { }
        
        public virtual void OnFixedUpdate() { }
    }
}