using System.Collections.Generic;

namespace Framework
{
    public class CoroutineLockQueue: Entity
    {
        private readonly Queue<ETaskCompletionSource<CoroutineLock>> queue = new Queue<ETaskCompletionSource<CoroutineLock>>();

        public void Enqueue(ETaskCompletionSource<CoroutineLock> tcs)
        {
            this.queue.Enqueue(tcs);
        }

        public ETaskCompletionSource<CoroutineLock> Dequeue()
        {
            return this.queue.Dequeue();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            
            base.Dispose();
            
            this.queue.Clear();
        }
    }
}