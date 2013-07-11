using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SortTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] obj1 = Sort.GetIntArray(), obj2 = obj1, obj3 = obj1;
            Sort s_instance = new Sort();

            //选择排序
            s_instance.StartTimer();
            Sort.MaxSort(obj1);
            s_instance.StopTimer();

            //冒泡排序
            s_instance.StartTimer();
            Sort.BubbleSort(obj2);
            s_instance.StopTimer();

            //新组排序
            s_instance.StartTimer();
            Sort.InsertSort(obj3);
            s_instance.StopTimer();

            Console.ReadKey();

            Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();
            foreach (int i in obj1)
            {
                s.Push(i);
            }
            foreach (int i in obj1)
            {
                q.Enqueue(i);
            }
            foreach (int i in s)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
            foreach (int i in q)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

            LinkedList<int> L = new LinkedList<int>();
            foreach (int i in obj1)
            {
                L.AddLast(i);
            }

            foreach (int i in L)
            {
                Console.WriteLine(i);
                
            }
            Console.WriteLine("First:"+L.First.Value);
            Console.WriteLine("555:"+L.ElementAt(555));
            Console.WriteLine("Last:"+L.Last.Value);
            Console.ReadKey();
        }
    }

    public class Sort
    {
        private Stopwatch timer;

        //动态生成数组
        public static int[] GetIntArray()
        {
            int[] result = { };
            List<int> temp_re = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int temp = r.Next(1, 10000);
                while (temp_re.Contains(temp))
                {
                    temp = r.Next(1, 10000);
                    if (temp_re.Count == 9999)
                    {
                        break;
                    }
                }
                temp_re.Add(temp);
            }
            result = temp_re.ToArray();
            return result;
        }

        /// <summary>
        /// 冒泡排序 效率相对较低
        /// </summary>
        /// <param name="arr_obj"></param>
        public static void BubbleSort(int[] arr_obj)
        {
            for (int j = 0; j < arr_obj.Length; j++)
            {
                for (int i = 0; i < arr_obj.Length; i++)
                {
                    if (arr_obj[i] > arr_obj[j])
                    {
                        int temp;
                        temp = arr_obj[i];
                        arr_obj[i] = arr_obj[j];
                        arr_obj[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 选择排序 效率相对中等
        /// </summary>
        /// <param name="arr_obj"></param>
        public static void MaxSort(int[] arr_obj)
        {
            int max;
            int maxIndex;
            for (int i = 0; i < arr_obj.Length; i++)
            {
                max = 0;
                maxIndex = 0;
                for (int j = 0; j < arr_obj.Length - i; j++)
                {
                    if (arr_obj[j] > max)
                    {
                        max = arr_obj[j];
                        maxIndex = j;
                    }
                }
                Sort.ChangeArray(arr_obj, maxIndex, arr_obj.Length - i - 1);
            }
        }

        public static void InsertSort(int[] arr_obj)
        {
            int max;
            int maxIndex;
            List<int> temp = new List<int>();
            for (int i = 0; i < arr_obj.Length; i++)
            {
                max = 0;
                maxIndex = 0;
                for (int j = 0; j < arr_obj.Length - i; j++)
                {
                    if (arr_obj[j] > max)
                    {
                        max = arr_obj[j];
                        maxIndex = j;
                    }
                }
                temp.Add(max);
            }
            temp.Reverse();
            arr_obj = temp.ToArray();
        }

        private static void ChangeArray(int[] arr_obj, int i, int j)
        {
            int temp = arr_obj[i];
            arr_obj[i] = arr_obj[j];
            arr_obj[j] = temp;
        }

        /// <summary>
        /// 从索引0开始逐个查找
        /// </summary>
        /// <param name="arr_obj"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int NormalSearch(int[] arr_obj, int obj)
        {
            int result = 0;
            for (int i = 0; i < arr_obj.Length; i++)
            {
                if (arr_obj[i] == obj)
                {
                    result = i;
                }
            }
            return result;
        }

        public static void HalfSearch(int[] arr_obj)
        {

        }

        /// <summary>
        /// show result
        /// </summary>
        /// <param name="arr_obj">obj array</param>
        public static void ShowResult(int[] arr_obj)
        {
            Console.WriteLine("Result : ");
            foreach (int i in arr_obj)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static void ShowSearchResult(int position)
        {
            Console.WriteLine("Search Result : ");
            Console.WriteLine(position);
        }

        public void StartTimer()
        {
            timer = new Stopwatch();
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
