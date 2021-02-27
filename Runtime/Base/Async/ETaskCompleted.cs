using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Framework
{
    [AsyncMethodBuilder(typeof (AsyncETaskCompletedMethodBuilder))]
    public struct ETaskCompleted: ICriticalNotifyCompletion
    {
        [DebuggerHidden]
        public ETaskCompleted GetAwaiter()
        {
            return this;
        }

        [DebuggerHidden]
        public bool IsCompleted => true;

        [DebuggerHidden]
        public void GetResult()
        {
        }

        [DebuggerHidden]
        public void OnCompleted(Action continuation)
        {
        }

        [DebuggerHidden]
        public void UnsafeOnCompleted(Action continuation)
        {
        }
    }
}