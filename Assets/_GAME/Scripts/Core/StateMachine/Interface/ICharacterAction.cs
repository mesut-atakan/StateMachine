using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public interface ICharacterAction
    {
        public void Execute(GameObject character);
    }
}