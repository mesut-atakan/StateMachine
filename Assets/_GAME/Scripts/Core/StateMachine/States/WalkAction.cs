using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class WalkAction : ICharacterAction
    {
        private Vector3 _direction;

        public WalkAction(Vector3 direction)
        {
            _direction = direction;
        }

        public void Execute(GameObject character)
        {
            character.transform.Translate(_direction * Time.deltaTime);
        }
    }
}