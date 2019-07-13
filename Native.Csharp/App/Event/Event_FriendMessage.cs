using Native.Csharp.App.Interface;
using Native.Csharp.App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Native.Csharp.App.Event
{
	public class Event_FriendMessage : IEvent_FriendMessage
	{
        string temFolder = "c:\\users\\yorkin\\Desktop";
        string programRet;

        #region --公开方法--
        /// <summary>
        /// Type=201 好友已添加<para/>
        /// 处理好友已经添加事件
        /// </summary>
        /// <param name="sender">事件的触发对象</param>
        /// <param name="e">事件的附加参数</param>
        public void ReceiveFriendIncrease (object sender, FriendIncreaseEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息



			e.Handled = false;   // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=301 收到好友添加请求<para/>
		/// 处理收到的好友添加请求
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveFriendAddRequest (object sender, FriendAddRequestEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息



			e.Handled = false;   // 关于返回说明, 请参见 "Event_ReceiveMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=21 好友消息<para/>
		/// 处理收到的好友消息
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveFriendMessage (object sender, PrivateMessageEventArgs e)
		{
            // 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
            // 这里处理消息

            //Common.CqApi.SendPrivateMessage(e.FromQQ, Common.CqApi.CqCode_At (e.FromQQ) + "你发送了这样的消息:" + e.Msg);
            string code = "";
            string[] msg = e.Msg.Split(Environment.NewLine.ToCharArray());
            if (msg[0].Trim() == "run19132")    // 如果此属性不为null, 则消息来自于匿名成员
            {
                for (int i = 1; i < msg.Length; ++i)
                    code += msg[i] + Environment.NewLine;

                Random random = new Random();
                long programID = e.FromQQ;
                if (File.Exists(temFolder +"\\"+programID+".exe"))
                {
                    Common.CqApi.SendPrivateMessage(e.FromQQ, Common.CqApi.CqCode_At(e.FromQQ) + " 你的上一个程序正在运行，请等待其结束再操作");
                }
                else
                {
                    Common.CqApi.SendPrivateMessage(e.FromQQ, Common.CqApi.CqCode_At(e.FromQQ) + Environment.NewLine + " 正在试图编译...");
                    File.WriteAllText(temFolder + "\\"+programID.ToString() + ".cpp", code);

                    Thread runthread = new Thread(new ParameterizedThreadStart(RunThread));
                    Thread monitorthread = new Thread(new ParameterizedThreadStart(MonitorThread));
                    ThreadMsg threadMsg = new ThreadMsg()
                    {
                        args = e,
                        programID = programID,
                        RunThread = runthread,
                        MonitorThread = monitorthread
                    };
                    runthread.Start(threadMsg);
                    monitorthread.Start(threadMsg);
                }
            }
                e.Handled = true;
			// e.Handled 相当于 原酷Q事件的返回值
			// 如果要回复消息，请调用api发送，并且置 true - 截断本条消息，不再继续处理 //注意：应用优先级设置为"最高"(10000)时，不得置 true
			// 如果不回复消息，交由之后的应用/过滤器处理，这里置 false  - 忽略本条消息
		}

        void RunThread(object Msg)
        {
            ThreadMsg msg = (ThreadMsg)Msg;
            Process Compilar = new Process();
            Compilar.StartInfo = new ProcessStartInfo()
            {
                FileName = "c:\\windows\\system32\\cmd.exe",
                Arguments = "/c g++ " + temFolder +"\\"+ msg.programID.ToString() + ".cpp -o " + temFolder + "\\" + msg.programID.ToString() + ".exe",
                RedirectStandardError = true,
                UseShellExecute = false
            };
            Compilar.Start();
            Compilar.WaitForExit();
            string CompilarRet = Compilar.StandardError.ReadToEnd();
            if (CompilarRet == "") CompilarRet = "编译成功,运行中...";
            Compilar.Close();
            Common.CqApi.SendPrivateMessage(msg.args.FromQQ, Common.CqApi.CqCode_At(msg.args.FromQQ) + Environment.NewLine + CompilarRet);

            if (CompilarRet == "编译成功,运行中...")
            {
                Process program = new Process();
                program.StartInfo = new ProcessStartInfo()
                {
                    FileName = "c:\\windows\\system32\\cmd.exe",
                    Arguments = "/c " + temFolder + "\\" + msg.programID.ToString() + ".exe",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };
                program.Start();
                program.WaitForExit();
                programRet = program.StandardOutput.ReadToEnd();
                program.Close();
            }
        }

        void MonitorThread(object Msg)
        {
            ThreadMsg msg = (ThreadMsg)Msg;
            bool quit = false;
            Process[] processes = Process.GetProcessesByName(msg.programID.ToString() + ".exe");
            DateTime begin = DateTime.Now;
            double during = 0;
            do
            {
                if (processes.Length > 0)
                {
                    if (processes[0].WorkingSet64 / 1048576 > 4) quit = true;
                }
                else
                { 
                    processes = Process.GetProcessesByName(msg.programID.ToString() + ".exe");
                }
                during = (DateTime.Now - begin).TotalMilliseconds;
                if (during > 60*1000 || msg.RunThread.ThreadState == System.Threading.ThreadState.Stopped) quit = true;
             
            }while(!quit);

            if(msg.RunThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                msg.RunThread.Abort();
                Process cmd = new Process();
                cmd.StartInfo = new ProcessStartInfo
                {
                    FileName = "c:\\windows\\system32\\cmd.exe",
                    Arguments = "/c taskkill -f -im " + msg.programID + ".exe"
                };
                cmd.Start();
                cmd.WaitForExit();
                cmd.Close();
                Common.CqApi.SendPrivateMessage(msg.args.FromQQ, Common.CqApi.CqCode_At(msg.args.FromQQ) + "程序已被强制退出：超时或过大的内存占用");
            }
            else
            {
                Common.CqApi.SendPrivateMessage(msg.args.FromQQ, Common.CqApi.CqCode_At(msg.args.FromQQ) + Environment.NewLine + " 运行用时" + during +"ms" + Environment.NewLine + programRet);
                programRet = "";
            }
            File.Delete(temFolder + "\\" + msg.programID + ".exe");
            File.Delete(temFolder + "\\" + msg.programID + ".cpp");

        }
        #endregion
    }

    public class ThreadMsg
    {
        public long programID;
        public PrivateMessageEventArgs args;
        public Thread RunThread;
        public Thread MonitorThread;
    }
}
