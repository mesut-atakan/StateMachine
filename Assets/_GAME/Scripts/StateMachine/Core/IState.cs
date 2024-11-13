namespace NotsGame.Core.StateSystem
{
    public interface IState
    {
        public void OnEnter();
        public void OnUpdate();
        public void OnExit();
    }
}