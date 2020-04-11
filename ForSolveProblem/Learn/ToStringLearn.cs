using System;
using System.Text;
using System.Threading;

namespace ForSolveProblem
{
    public class ToStringLearn : IProblem
    {
        public void RunProblem()
        {
            OutPutStr();
        }

        private void OutPutStr()
        {
            var binaryStr = Convert.ToString(10, 2);

            var positiveSign = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PositiveSign;
            var negativeSign = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NegativeSign;

            int.Parse("a", System.Globalization.NumberStyles.AllowTrailingWhite);


            var t = new ExEntity()
            {
                I = 10,
                S = "Pyh"
            };

            var s = new AnEntity()
            {
                Age = 100,
                Address = "GodDis"
            };

            var output = $"{s:g}_{s.Age}_{s.Address}";

            output = string.Format("{0:pyh}_{1}_{2}", t, t.I, t.S);

            var sb = new StringBuilder();
            output = $"{t:pyh}";


            //var o = typeof(Object).ToString();

            //var s = typeof(ExEntity).ToString();

            //s = new ExEntity().ToString();

            //var str = new StringBuilder();
            //var t = str.AppendFormat(new BoldInt32s(), "{0} {1} {2:M}", "jeff", 123, DateTime.Now);

        }

        class AnEntity
        {
            public int Age { get; set; }
            public string Address { get; set; }
        }

        class ExEntity : IFormattable
        {
            public int I { get; set; }
            public string S { get; set; }

            public override string ToString()
            {
                return $"{I}_{S}";
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                var res = "";
                switch (format)
                {
                    case "pyh":
                        res = $"{I}_pyh_{S}";
                        break;

                    default:
                        res = $"{I}_def_{S}";
                        break;
                }

                return res;
            }
        }

        internal sealed class BoldInt32s : IFormatProvider, ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                string s;

                var formatable = arg as IFormattable;

                if (formatable == null) s = arg.ToString();
                else s = formatable.ToString(format, formatProvider);

                if (arg.GetType() == typeof(int))
                    return $"<B>{s}</B>";

                return s;
            }

            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter)) return this;

                return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
            }
        }
    }
}
