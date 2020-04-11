using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ForSolveProblem
{
    public class AttributeLearn : IProblem
    {
        public AttributeLearn()
        {
        }

        public void RunProblem()
        {
            var t = GetEnumStrResult();
        }

        private List<string> GetEnumStrResult()
        {
            var fields = typeof(ForTestEnum).GetFields();
            var attDic = fields.ToDictionary(i => i.Name, j => j.GetCustomAttribute<EnumStrAttribute>());

            var res = new List<string>();
            var arr = new ForTestEnum[] { ForTestEnum.One, ForTestEnum.Two, ForTestEnum.Three, ForTestEnum.Four };

            foreach (var arrItem in arr)
            {
                var cusAtt = attDic[arrItem.ToString("G")];
                if (cusAtt == null)
                {
                    res.Add("null");
                    continue;
                }

                switch (cusAtt.CharStr)
                {
                    case 's':
                        res.Add(arrItem.ToString("G"));
                        break;

                    case 'n':
                        res.Add(arrItem.ToString("D"));
                        break;

                    case 'a':
                        res.Add(arrItem.ToString("G") + "_" + arrItem.ToString("D"));
                        break;
                }
            }

            return res;
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        class EnumStrAttribute : Attribute
        {
            public EnumStrAttribute(char c)
            {
                CharStr = c;
            }

            public char CharStr { get; }
        }

        public enum ForTestEnum
        {
            [EnumStr('s')]
            One = 10,

            [EnumStr('n')]
            Two = 20,

            [EnumStr('a')]
            Three = 30,

            Four = 40
        }
    }
}
