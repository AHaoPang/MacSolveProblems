using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem232 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 用栈来实现队列
        /// 思路：
        ///     1.引入一个主栈，一个临时栈用来倒腾
        ///     2.依据队列和栈的性质，当需要新增元素的时候，就一定是要放在栈的最下层的，因此需要一个临时的栈来倒腾
        ///     3.push --> O(n)，每新加一个元素，就把现有的倒腾出去，放入新的以后，再把原来的倒腾回来
        ///     4.pop --> O(1)
        ///     5.peek --> O(1)
        ///     6.empty --> O(1)
        /// </summary>
        public class MyQueue
        {
            private Stack<int> m_stack;

            /** Initialize your data structure here. */
            public MyQueue()
            {
                m_stack = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                Stack<int> tempStack = new Stack<int>();

                while (m_stack.Any()) tempStack.Push(m_stack.Pop());

                m_stack.Push(x);

                while (tempStack.Any()) m_stack.Push(tempStack.Pop());
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return m_stack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return m_stack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return !m_stack.Any();
            }
        }

        /// <summary>
        /// 用栈来实现队列
        /// 思路：
        ///     1.使用两个栈来模拟，栈的职责分别是Output和input
        ///     2.push --> 直接往input中加入 O(1)
        ///     3.pop --> 直接从output中取，若没了，再去input中倒腾 O(n)
        ///     4.peek --> 同pop
        ///     5.empty --> 检测两个 stack 
        /// </summary>
        public class MyQueue1
        {
            private Stack<int> m_InputStack;
            private Stack<int> m_OutputStack;

            /** Initialize your data structure here. */
            public MyQueue1()
            {
                m_InputStack = new Stack<int>();
                m_OutputStack = new Stack<int>();
            }

            private void InputToOutput()
            {
                while (m_InputStack.Any()) m_OutputStack.Push(m_InputStack.Pop());
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                m_InputStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (m_OutputStack.Any()) return m_OutputStack.Pop();

                InputToOutput();

                return m_OutputStack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (m_OutputStack.Any()) return m_OutputStack.Peek();

                InputToOutput();

                return m_OutputStack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return !m_InputStack.Any() && !m_OutputStack.Any();
            }
        }
    }
}
