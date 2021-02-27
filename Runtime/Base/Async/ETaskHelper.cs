using System.Collections.Generic;

namespace Framework
{
    public static class ETaskHelper
    {
        private class CoroutineBlocker
        {
            private int count;

            private List<ETaskCompletionSource> tcss = new List<ETaskCompletionSource>();

            public CoroutineBlocker(int count)
            {
                this.count = count;
            }

            public async ETask WaitAsync()
            {
                --this.count;
                if (this.count < 0)
                {
                    return;
                }

                if (this.count == 0)
                {
                    List<ETaskCompletionSource> t = this.tcss;
                    this.tcss = null;
                    foreach (ETaskCompletionSource ttcs in t)
                    {
                        ttcs.SetResult();
                    }

                    return;
                }

                ETaskCompletionSource tcs = new ETaskCompletionSource();
                tcss.Add(tcs);
                await tcs.Task;
            }
        }

        public static async ETask WaitAny<T>(ETask<T>[] tasks)
        {
            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(2);
            foreach (ETask<T> task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async EVoid RunOneTask(ETask<T> task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }
        }

        public static async ETask WaitAny(ETask[] tasks)
        {
            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(2);
            foreach (ETask task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async EVoid RunOneTask(ETask task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }
        }

        public static async ETask WaitAll<T>(ETask<T>[] tasks)
        {
            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Length + 1);
            foreach (ETask<T> task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async EVoid RunOneTask(ETask<T> task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }
        }

        public static async ETask WaitAll(ETask[] tasks)
        {
            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Length + 1);
            foreach (ETask task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async EVoid RunOneTask(ETask task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }
        }
    }
}