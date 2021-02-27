using System;

namespace Framework
{
    public class ECancellationToken
    {
        private Action action;

        public void Register(Action callback)
        {
            this.action = callback;
        }

        public void Cancel()
        {
            action.Invoke();
        }
    }
}