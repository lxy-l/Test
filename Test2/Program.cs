using CommonDelegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        public delegate string TakesAwhileDel(int data, int ms);
        static void Main(string[] args)
        {
            //TakesAwhileDel dl = TakesAwhile;
            //dl.BeginInvoke(1, 6000, AsyncCallbackImpl, dl);
            //System.Threading.Thread.Sleep(1000);

            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoSomething doSomething = CommonDelegate.CommonDelegate.DoSomethingMethod;
            //doSomething.BeginInvoke(null, null);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);


            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoSomethingReturn doSomething = new DoSomethingReturn(CommonDelegate.CommonDelegate.DoSomethingReturnMethod);
            //IAsyncResult iasyncResult = doSomething.BeginInvoke(null, null);
            //int result = doSomething.EndInvoke(iasyncResult);
            //Console.WriteLine("result={0}", result);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);

            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoMore doMore = new DoMore(CommonDelegate.CommonDelegate.DoMoreMethod);
            //doMore.BeginInvoke(16, "guo", null, null);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);

            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoMoreReturn doMoreReturn = new DoMoreReturn(CommonDelegate.CommonDelegate.DoMoreReturnMethod);
            //IAsyncResult iasyncResult = doMoreReturn.BeginInvoke(16, "guo", null, null);
            //int result = doMoreReturn.EndInvoke(iasyncResult);
            //Console.WriteLine("result={0}", result);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);

            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoMoreReturn doMore = new DoMoreReturn(CommonDelegate.CommonDelegate.DoMoreReturnMethod);
            //doMore.BeginInvoke(16, "guo", Callback, "wulala");
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);

            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoMore doMore = new DoMore(CommonDelegate.CommonDelegate.DoMoreMethod);
            //IAsyncResult iasyncResult = doMore.BeginInvoke(16, "guo", null, null);
            ////无参或参数为-1表示无限等等
            ////iasyncResult.AsyncWaitHandle.WaitOne();
            ////iasyncResult.AsyncWaitHandle.WaitOne(-1);
            ////表示等待1000ms
            //iasyncResult.AsyncWaitHandle.WaitOne(1000);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);


            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //DoMoreReturn doMoreReturn = new DoMoreReturn(CommonDelegate.CommonDelegate.DoMoreReturnMethod);
            //IAsyncResult iasyncResult = doMoreReturn.BeginInvoke(16, "guo", null, null);
            //while (!iasyncResult.IsCompleted)
            //{
            //    Console.WriteLine("正在执行......");
            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);



            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //ThreadStart threadStart = new ThreadStart(CommonDelegate.CommonDelegate.DoSomethingMethod);
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);



            ////Thread默认不支持返回值
            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //Func<int> func = new Func<int>(CommonDelegate.CommonDelegate.DoSomethingReturnMethod);
            //Func<int> beginInvokeFunc = BeginInvoke<int>(func);
            //Console.WriteLine("Main-Other-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //Thread.Sleep(2000);
            //Console.WriteLine("Main-Other-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            ////想获取计算结果必须等待
            //int result = beginInvokeFunc.Invoke();
            //Console.WriteLine("result=" + result);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);


            ////Thread默认不支持回调
            //Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //ThreadStart threadStart = new ThreadStart(CommonDelegate.CommonDelegate.DoSomethingMethod);
            //Action callback = new Action(() =>
            //{
            //    Console.WriteLine("Callback-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Callback-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //});
            //BeginInvoke(threadStart, callback);
            //Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);






            Console.ReadLine();
        }


        /// <summary>
        /// 基于Thread封装一个支持返回值的方法
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="callback"></param>
        private static Func<T> BeginInvoke<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart start = new ThreadStart(() =>
            {
                //func.Invoke()等价于func()表示同步执行
                t = func.Invoke();
            });
            Thread thread = new Thread(start);
            thread.Start();
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });

        }

        /// <summary>
        /// 基于Thread封装一个支持回调的方法
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="callback"></param>
        private static void BeginInvoke(ThreadStart threadStart, Action callback)
        {
            ThreadStart start = new ThreadStart(() =>
            {
                //threadStart.Invoke()等价于threadStart()表示同步执行
                threadStart.Invoke();
                callback.Invoke();
            });
            Thread thread = new Thread(start);
            thread.Start();
        }
        public static void AsyncCallbackImpl(IAsyncResult ar)
        {
            TakesAwhileDel dl = ar.AsyncState as TakesAwhileDel;
            string re = dl.EndInvoke(ar);
            Console.WriteLine("结果{0}:", re);
            dl.BeginInvoke(1, 6000, AsyncCallbackImpl, dl);
        }
        public static string TakesAwhile(int data, int ms)
        {

            Console.WriteLine("开始调用");
            System.Threading.Thread.Sleep(ms);
            Console.WriteLine("完成调用");
            string str = "测试成功";


            return str;
        }


        private static void Callback(IAsyncResult iasyncResult)
        {
            Console.WriteLine("Callback-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            AsyncResult asyncResult = (AsyncResult)iasyncResult;
            //获取回调方法的参数
            string parameter = asyncResult.AsyncState.ToString();
            //获取委托的返回值
            DoMoreReturn doMore = (DoMoreReturn)asyncResult.AsyncDelegate;
            int result = doMore.EndInvoke(asyncResult);
            Thread.Sleep(3000);
            Console.WriteLine("result={0},parameter={1}", result, parameter);
            Console.WriteLine("Callback-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }
        /// <summary>
        /// 委托生成树形结构
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static List<TreeModel> GetTree(Dictionary<int, TreeModel> keyValues)
        {
            Func<int, List<TreeModel>> func = null;
            func = m => {
                List<TreeModel> list = new List<TreeModel>();
                foreach (var item in keyValues.Where(kv => kv.Value.ParentId == m))
                {
                    var childs = func(item.Value.Id);
                    list.Add(item.Value);
                }
                return list;
            };
            return func(0);
        }
    }
}
