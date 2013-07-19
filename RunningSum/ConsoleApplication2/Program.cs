using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Sum : IEnumerable
    {
        private double[] m_sum;
        public Sum(double[] pArray)
        {
            m_sum = new double[pArray.Length];
            m_sum[0] = pArray[0];
            for (int i = 1; i < pArray.Length; i++)
            {
                m_sum[i] = pArray[i] + m_sum[i-1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public SumEnum GetEnumerator()
        {
            return new SumEnum(m_sum);
        }
    }

    public class SumEnum : IEnumerator
    {
        public double[] s_sum;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public SumEnum(double[] list)
        {
            s_sum = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < s_sum.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public double Current
        {
            get
            {
                
                    return s_sum[position];
               
                
            }
        }
    }

    class App
    {
        static void Main()
        {
            double[] SumArray = new double[3]
            {
                1.0,
                3.0,
                8.0,
            };

            Sum SumList = new Sum(SumArray);
            foreach (var p in SumList)
                Console.WriteLine(p);
            Console.ReadKey();

        }
    }
}
