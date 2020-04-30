using CommonDelegate;

using System;
using System.Threading;

namespace Test
{
    internal class Program
    {
        private enum MyEnum
        {
            Red,
            Bule
        }
        public delegate string TakesAwhileDel(int data, int ms);

        private static void Main(string[] args)
        {
            //TakesAwhileDel dl = TakesAwhile;
            //dl.BeginInvoke(1, 6000, AsyncCallbackImpl, dl);
            //System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoSomething doSomething = CommonDelegate.CommonDelegate.DoSomethingMethod;
            doSomething.BeginInvoke(null, null);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Console.ReadLine();
        }
        public static void AsyncCallbackImpl(IAsyncResult ar)
        {
            TakesAwhileDel dl = ar.AsyncState as TakesAwhileDel;
            string re = dl.EndInvoke(ar);
            Console.WriteLine("结果{0}", re);
            //TakesAwhileDel d2 = TakesAwhile;
            dl.BeginInvoke(1, 6000, AsyncCallbackImpl, dl);
        }

        private static string TakesAwhile(int data, int ms)
        {

            Console.WriteLine("开始调用");
            System.Threading.Thread.Sleep(ms);
            Console.WriteLine("完成调用");
            string str = "测试成功";
            return str;
        }
    }
}
