using System.Collections.Generic;
using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class State
    {
        public List<ICharacterAction> actions = new List<ICharacterAction>();

        public State(List<ICharacterAction> actions)
        {
            this.actions = actions;
        }

        public void Execute(GameObject character)
        {
            foreach (var action in actions)
            {
                action.Execute(character);
            }
        }
    }
}