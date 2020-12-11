using System;
namespace ForSolveProblem
{
    public class ReadonlyStructLearn : IProblem
    {
        public ReadonlyStructLearn()
        {
        }

        public void RunProblem()
        {
            var t = new FromStructureTypesDocument();

            t.Test1();
        }

        public class FromReadOnlyStructMembersDocument
        {
            /*
             * 可以为结构体的成员添加 readonly 修饰符，表明这个成员不修改数据；
             * 这是比直接为 struct 添加 readonly 修饰符更加细粒度的控制；
             * 这样写可以表达一种意图，基于此种意图编译器可以做一些优化，而且编译器也会去强制此种意图的落实；
             * 
             * 非常有趣，这是又增加了编译器与作者的一种写作约定了~
             */
            public struct Point
            {
                public double X { get; set; }

                public double Y { get; set; }

                public readonly double Distance => Math.Sqrt(X * X + Y * Y);

                public readonly override string ToString() =>
                    $"{X},{Y} is {Distance} from the origin";

                //public readonly void Translate(int xOffset, int yOffset)
                //{
                //    X += xOffset;
                //    Y += yOffset;
                //}
            }
        }

        public class FromStructureTypesDocument
        {
            private struct Coords
            {
                public Coords(double x, double y)
                {
                    X = x;
                    Y = y;
                    MyC = new MyClass() { IX = 1, IY = 2 };
                }

                public double X { get; }
                public double Y { get; }

                public override string ToString() => $"({X},{Y})";

                public MyClass MyC { get; set; }
            }

            private class MyClass
            {
                public int IX { get; set; }
                public int IY { get; set; }
            }

            public void Test1()
            {
                /*
                 * 值类型，确实是会做拷贝的，但是必然是浅拷贝~
                 * 相比引用类型只是拷贝一个地址，值类型会拷贝每一个成员的值，如果这个值是本身，那么就是副本
                 * 如果这个值本身是个引用，那么就是引用了
                 * 
                 * 值类型与引用类型，在拷贝上的含义来看，都是在拷贝变量自己了
                 * 值类型的变量，本身就存储了自己的值；
                 * 引用类型的变量，本身只存储了自己的地址；
                 * 所以都是拷贝自己，只是拷贝后的效果不同，在拷贝这个操作看来，是没差了~
                 */

                var v1 = new Coords(10, 20);

                var v2 = v1;

                v2.MyC.IX = 3;
            }

            /*
             * 有趣的只读结构体，从逻辑上也保证了“只读”
             * 1.字段必须是只读的，那么除了构造函数，没有地方能修改了；
             * 2.属性只能是只读的了，即使是自动属性，也只能写 get;了
             * 3.那么方法本身也折腾不出啥了~
             * 相当豪横的一种 readonly 方式了
             * 相较而言，只读成员 确实更加的细粒度了~
             */
            private readonly struct CoordReadOnly
            {
                public CoordReadOnly(double x, double y)
                {
                    X = x;
                    Y = y;
                    Z = 10;
                    W = 20;
                }

                public double X { get; }
                public double Y { get; }

                public override string ToString() => $"({X},{Y})";

                public double Z { get; }

                public readonly double W;
            }
        }
    }


}
