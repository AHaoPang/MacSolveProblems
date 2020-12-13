using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class AsyncOneManyLockLearn : IProblem
    {
        public AsyncOneManyLockLearn()
        {
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        private enum OneManyMode { Exclusive, Shared }

        private sealed class AsyncOneManyLock
        {
            #region 锁的代码
            private SpinLock m_lock = new SpinLock(true);
            private void Lock() { var taken = false; m_lock.Enter(ref taken); }
            private void UnLock() { m_lock.Exit(); }
            #endregion

            #region 锁的状态和辅助方法
            private int m_state = 0;
            private bool IsFree { get => m_state == 0; }
            private bool IsOwnedByWriter { get => m_state == -1; }
            private bool IsOwnedByReaders { get => m_state > 0; }
            private int AddReaders(int count) => m_state += count;
            private int SubtractReader() => --m_state;
            private void MakeWriter() => m_state = -1;
            private void MakeFree() => m_state = 0;
            #endregion

            //目的是在非竞态条件时增强性能和减少内存消耗
            private readonly Task m_noContentionAccessGranter;

            //每个等待的 writer 都通过它们在这里排队的 TaskCompletionSource来唤醒
            private readonly Queue<TaskCompletionSource<object>> m_qWaitingWriters = new Queue<TaskCompletionSource<object>>();

            //一个 TaskCompletionSource 收到信号,所有等待的 Reader 都唤醒
            private TaskCompletionSource<object> m_waitingReadersSignal = new TaskCompletionSource<object>();

            private int m_numWaitingReaders = 0;

            public AsyncOneManyLock() => m_noContentionAccessGranter = Task.FromResult<object>(null);


            public Task WaitAsync(OneManyMode mode)
            {
                Task accessGranter = m_noContentionAccessGranter;

                Lock();

                switch (mode)
                {
                    case OneManyMode.Exclusive:
                        if (IsFree)
                        {
                            MakeWriter();
                        }
                        else
                        {
                            var tcs = new TaskCompletionSource<object>();
                            m_qWaitingWriters.Enqueue(tcs);
                            accessGranter = tcs.Task;
                        }
                        break;

                    case OneManyMode.Shared:
                        if (IsFree || (IsOwnedByReaders && m_qWaitingWriters.Count == 0))
                        {
                            AddReaders(1);
                        }
                        else
                        {
                            m_numWaitingReaders++;
                            accessGranter = m_waitingReadersSignal.Task.ContinueWith(i => i.Result);
                        }

                        break;
                }

                UnLock();

                return accessGranter;
            }

            public void Release()
            {
                TaskCompletionSource<object> accessGranter = null;

                Lock();

                if (IsOwnedByWriter) MakeFree();
                else SubtractReader();

                if (IsFree)
                {
                    if (m_qWaitingWriters.Count > 0)
                    {
                        MakeWriter();
                        accessGranter = m_qWaitingWriters.Dequeue();
                    }
                    else if (m_numWaitingReaders > 0)
                    {
                        AddReaders(m_numWaitingReaders);
                        m_numWaitingReaders = 0;
                        accessGranter = m_waitingReadersSignal;

                        m_waitingReadersSignal = new TaskCompletionSource<object>();
                    }
                }

                UnLock();

                if (accessGranter != null) accessGranter.SetResult(null);
            }
        }
    }
}
