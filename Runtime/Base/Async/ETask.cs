using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Framework
{
    [AsyncMethodBuilder(typeof (EAsyncTaskMethodBuilder))]
    public struct ETask
    {
        public static ETaskCompleted CompletedTask => new ETaskCompleted();

        private readonly ETaskCompletionSource awaiter;

        [DebuggerHidden]
        public ETask(ETaskCompletionSource awaiter)
        {
            this.awaiter = awaiter;
        }

        [DebuggerHidden]
        public ETaskCompletionSource GetAwaiter()
        {
            return this.awaiter;
        }

        [DebuggerHidden]
        public void Coroutine()
        {
            InnerCoroutine().Coroutine();
        }

        [DebuggerHidden]
        private async EVoid InnerCoroutine()
        {
            await this;
        }
    }

    [AsyncMethodBuilder(typeof (EAsyncTaskMethodBuilder<>))]
    public struct ETask<T>
    {
        private readonly ETaskCompletionSource<T> awaiter;

        [DebuggerHidden]
        public ETask(ETaskCompletionSource<T> awaiter)
        {
            this.awaiter = awaiter;
        }

        [DebuggerHidden]
        public ETaskCompletionSource<T> GetAwaiter()
        {
            return this.awaiter;
        }

        [DebuggerHidden]
        public void Coroutine()
        {
            InnerCoroutine().Coroutine();
        }

        private async EVoid InnerCoroutine()
        {
            await this;
        }
    }
}