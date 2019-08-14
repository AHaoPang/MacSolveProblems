﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions
{
    public class Problem393 : IProblem
    {
        public void RunProblem()
        {
            var temp = ValidUtf8(new int[] { 197, 130, 1 });

            temp = ValidUtf8(new int[] { 235, 140, 4 });
        }

        public bool ValidUtf8(int[] data)
        {
            /*
             * 校验给定字节序列是否满足UTF-8的格式要求
             * 思路：
             *  1.传入的是一个数组，每个元素表示一个UTF-8的元素，所以要取出这8个位
             *  2.查看其头标识，满足1的个数为：0、2、3、4
             *  3.从后面拿指定数量的元素：0、1、2、3
             *  4.校验每个元素，都是已10开头的
             */

            for (int i = 0; i < data.Length; i++)
            {
                //取8个位
                int headTemp = GetDataEightPos(data[i]);

                //校验头部1的位数
                int oneCount = GetFirstOneAmount(headTemp);
                if (oneCount == 1 || oneCount > 4) return false;
                if (oneCount == 0) continue;

                //取后面的几个元素
                int getCount = oneCount - 1;
                if (i + getCount >= data.Length) return false;
                for (int j = i + 1; j <= i + getCount; j++)
                {
                    int body = GetDataEightPos(data[j]);

                    int bodyOneCount = GetFirstOneAmount(body);
                    if (bodyOneCount != 1) return false;
                }

                //校验通过，开始下个轮回
                i = i + getCount;
            }

            return true;
        }

        private int GetDataEightPos(int data)
        {
            return 0xFF & data;
        }

        private int GetFirstOneAmount(int data)
        {
            int t = 0x80;
            int countOne = 0;
            while ((t & data) != 0)
            {
                countOne++;
                if (countOne > 4) break;

                t = t >> 1;
            }

            return countOne;
        }
    }
}
