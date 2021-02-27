using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace Framework
{
    public struct EAsyncTaskMethodBuilder
    {
        public ETaskCompletionSource Tcs;

        // 1. Static Create method.
        [DebuggerHidden]
        public static EAsyncTaskMethodBuilder Create()
        {
            EAsyncTaskMethodBuilder builder = new EAsyncTaskMethodBuilder() { Tcs = new ETaskCompletionSource() };
            return builder;
        }

        // 2. TaskLike Task property.
        [DebuggerHidden]
        public ETask Task => this.Tcs.Task;

        // 3. SetException
        [DebuggerHidden]
        public void SetException(Exception exception)
        {
            this.Tcs.SetException(exception);
        }

        // 4. SetResult
        [DebuggerHidden]
        public void SetResult()
        {
            this.Tcs.SetResult();
        }

        // 5. AwaitOnCompleted
        [DebuggerHidden]
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        // 6. AwaitUnsafeOnCompleted
        [DebuggerHidden]
        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        // 7. Start
        [DebuggerHidden]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        // 8. SetStateMachine
        [DebuggerHidden]
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }

    public struct EAsyncTaskMethodBuilder<T>
    {
        public ETaskCompletionSource<T> Tcs;

        // 1. Static Create method.
        [DebuggerHidden]
        public static EAsyncTaskMethodBuilder<T> Create()
        {
            EAsyncTaskMethodBuilder<T> builder = new EAsyncTaskMethodBuilder<T>() { Tcs = new ETaskCompletionSource<T>() };
            return builder;
        }

        // 2. TaskLike Task property.
        [DebuggerHidden]
        public ETask<T> Task => this.Tcs.Task;

        // 3. SetException
        [DebuggerHidden]
        public void SetException(Exception exception)
        {
            this.Tcs.SetException(exception);
        }

        // 4. SetResult
        [DebuggerHidden]
        public void SetResult(T ret)
        {
            this.Tcs.SetResult(ret);
        }

        // 5. AwaitOnCompleted
        [DebuggerHidden]
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        // 6. AwaitUnsafeOnCompleted
        [DebuggerHidden]
        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        // 7. Start
        [DebuggerHidden]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        // 8. SetStateMachine
        [DebuggerHidden]
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }
}