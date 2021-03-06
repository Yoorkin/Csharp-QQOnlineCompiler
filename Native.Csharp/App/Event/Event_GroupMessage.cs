﻿using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Native.Csharp.App.Model;
using Native.Csharp.App.Interface;
using System.Diagnostics;

namespace Native.Csharp.App.Event
{
	public class Event_GroupMessage : IEvent_GroupMessage
	{
		#region --公开方法--
		/// <summary>
		/// Type=2 群消息<para/>
		/// 处理收到的群消息
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupMessage (object sender, GroupMessageEventArgs e)
		{
            //string code = "";
            //string[] msg = e.Msg.Split(Environment.NewLine.ToCharArray());
            //if (msg[0].Trim() == "run")    // 如果此属性不为null, 则消息来自于匿名成员
            //{
            //    Common.CqApi.SendGroupMessage(e.FromGroup, Common.CqApi.CqCode_At(e.FromQQ) + " 正在试图编译并运行...");
            //    for (int i = 1; i < msg.Length; ++i)
            //        code += msg[i] + Environment.NewLine;
            //    System.IO.File.WriteAllText("C:\\Users\\Yorkin\\Desktop\\temp.cpp", code);
            //    Process Compilar = new Process();
            //    ProcessStartInfo Compilarinfo = new ProcessStartInfo();
            //    Compilarinfo.FileName = "C:\\Windows\\System32\\cmd.exe";
            //    Compilarinfo.Arguments = "/c c:\\mingw64\\bin\\g++ C:\\Users\\Yorkin\\Desktop\\temp.cpp -o C:\\Users\\Yorkin\\Desktop\\temp.exe";
            //    Compilarinfo.UseShellExecute = false;
            //    Compilarinfo.RedirectStandardError = true;
            //    //Compilarinfo.CreateNoWindow = true;
            //    Compilar.StartInfo = Compilarinfo;
            //    Compilar.Start();
            //    Compilar.WaitForExit();
            //    string CompilarRet = Compilar.StandardError.ReadToEnd();
            //    if (CompilarRet == "") CompilarRet = "编译成功";
            //    Compilar.Close();
            //    Common.CqApi.SendGroupMessage(e.FromGroup, Common.CqApi.CqCode_At(e.FromQQ) + Environment.NewLine + CompilarRet);

            //    if (CompilarRet == "编译成功")
            //    {
            //        Process program = new Process();
            //        ProcessStartInfo programinfo = new ProcessStartInfo();
            //        programinfo.FileName = "C:\\Windows\\System32\\cmd.exe";
            //        programinfo.Arguments = "/c c:\\Users\\Yorkin\\Desktop\\temp.exe";
            //        programinfo.RedirectStandardOutput = true;
            //        programinfo.UseShellExecute = false;
            //        programinfo.CreateNoWindow = true;
            //        program.StartInfo = programinfo;
            //        program.Start();
            //        program.WaitForExit();
            //        string programRet = program.StandardOutput.ReadToEnd();
            //        program.Close();
            //        Common.CqApi.SendGroupMessage(e.FromGroup, Common.CqApi.CqCode_At(e.FromQQ) + Environment.NewLine + programRet);
            //    }
            //}
            e.Handled = false;   // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=21 群私聊<para/>
		/// 处理收到的群私聊消息
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupPrivateMessage (object sender, PrivateMessageEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息


			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=11 群文件上传事件<para/>
		/// 处理收到的群文件上传结果
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupFileUpload (object sender, FileUploadMessageEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息
			// 关于文件信息, 触发事件时已经转换完毕, 请直接使用



			e.Handled = false;   // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=101 群事件 - 管理员增加<para/>
		/// 处理收到的群管理员增加事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupManageIncrease (object sender, GroupManageAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=101 群事件 - 管理员减少<para/>
		/// 处理收到的群管理员减少事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupManageDecrease (object sender, GroupManageAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=103 群事件 - 群成员增加 - 主动入群<para/>
		/// 处理收到的群成员增加 (主动入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupMemberJoin (object sender, GroupMemberAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用，请注意使用对象等需要初始化(CoInitialize,CoUninitialize)。
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=103 群事件 - 群成员增加 - 被邀入群<para/>
		/// 处理收到的群成员增加 (被邀入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupMemberInvitee (object sender, GroupMemberAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用, 请注意使用对象等需要初始化(ConIntialize, CoUninitialize).
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=102 群事件 - 群成员减少 - 成员离开<para/>
		/// 处理收到的群成员减少 (成员离开) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupMemberLeave (object sender, GroupMemberAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用, 请注意使用对象等需要初始化(ConIntialize, CoUninitialize).
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=102 群事件 - 群成员减少 - 成员移除<para/>
		/// 处理收到的群成员减少 (成员移除) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupMemberRemove (object sender, GroupMemberAlterEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用, 请注意使用对象等需要初始化(ConIntialize, CoUninitialize).
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=302 群事件 - 群请求 - 申请入群<para/>
		/// 处理收到的群请求 (申请入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupAddApply (object sender, GroupAddRequestEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用, 请注意使用对象等需要初始化(ConIntialize, CoUninitialize).
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}

		/// <summary>
		/// Type=302 群事件 - 群请求 - 被邀入群 (机器人被邀)<para/>
		/// 处理收到的群请求 (被邀入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
		public void ReceiveGroupAddInvitee (object sender, GroupAddRequestEventArgs e)
		{
			// 本子程序会在酷Q【线程】中被调用, 请注意使用对象等需要初始化(ConIntialize, CoUninitialize).
			// 这里处理消息



			e.Handled = false;  // 关于返回说明, 请参见 "Event_FriendMessage.ReceiveFriendMessage" 方法
		}
		#endregion
	}
}
