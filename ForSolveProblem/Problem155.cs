using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem155 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 最小栈的实现，它比普通的栈多一个功能，即获取当前栈中最小的元素
        /// 思考：
        ///     1.只是想知道最小的元素，并不需要对元素本身做操作；
        ///     2.每个栈被加入的都是，都可以知道截止它加入的时候，栈中全局的状态，比如说最小值；
        ///     3.因此，只要问最后一个加入栈的元素就可以做到了，于是我们就需要在元素加入的时候，就让它去维护这样的信息
        ///     
        /// 考察点：
        ///     1.对栈这种结构的理解，先入后出
        /// </summary>
        public class MinStack
        {
            class StackItem
            {
                public int MinValue { get; set; }
                public int CurValue { get; set; }
            }

            private Stack<StackItem> m_interStack;

            /** initialize your data structure here. */
            public MinStack()
            {
                m_interStack = new Stack<StackItem>();
            }

            public void Push(int x)
            {
                int minValue = x;
                if (m_interStack.Any() && m_interStack.Peek().MinValue < x)
                    minValue = m_interStack.Peek().MinValue;

                m_interStack.Push(new StackItem()
                {
                    CurValue = x,
                    MinValue = minValue
                });
            }

            public void Pop()
            {
                if (m_interStack.Any()) m_interStack.Pop();
            }

            public int Top()
            {
                return m_interStack.Peek().CurValue;
            }

            public int GetMin()
            {
                return m_interStack.Peek().MinValue;
            }
        }
    }
}
