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
            List<int> obj2_list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int temp = r.Next(1, 10000);
                while (obj2_list.Contains(temp))
                {
                    temp = r.Next(1, 10000);
                    if (obj2_list.Count == 9999)
                    {
                        break;
                    }
                }
                obj2_list.Add(temp);
            }
            int[] obj2 = obj2_list.ToArray();
            //Sort.BubbleSort(obj);
            //Sort.ShowResult(obj);
            Sort s_instance = new Sort();
            s_instance.StartTimer();
            Sort.ShowSearchResult(Sort.NormalSearch(obj2, 55));
            s_instance.StopTimer();
            Console.ReadKey();
        }
        
    }

    public class Sort
    {
        private Stopwatch timer;
        /// <summary>
        /// 冒泡排序
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
        /// 从索引0开始逐个查找
        /// </summary>
        /// <param name="arr_obj"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int NormalSearch(int[] arr_obj,int obj)
        {
            int result=0;
            for (int i =0;i<arr_obj.Length;i++)
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
