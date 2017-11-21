using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Network;

public class HttpUtils
{

	// 成功回调
	public  delegate void ReqSuccess (HTTPPacketAck act);

	// 失败回调
	public delegate void ReqFailed (string error, System.Action resendAction, System.Action closeAction);

	//	Author: Yxh
	// 2017-09-21
	// POST 请求
	public static void Post (string url, HTTPPacketRequest requestModel, ReqSuccess succ, ReqFailed error)
	{
		HTTPSession session = new HTTPSession (url);
		session.onDataError = error.Invoke;
		Dictionary<string,string> head = new Dictionary<string,string> ();
        head["Content-Type"] = "application/json";
        head["Scope"] = SCOPE_NAME;
		session.m_cHeader = head;
		session.SendJSON (requestModel, (HTTPPacketAck ack) => {
			succ (ack);
		}); 
	}

	//	HTTPPacketRequest.cs
	//	Author: Yxh
	// 2017-09-21
	//  请求
	public static void Get (string url, HTTPPacketRequest requestModel, ReqSuccess succ, ReqFailed error)
	{
		HTTPSession session = new HTTPSession (url);
		session.onDataError = error.Invoke;
		Dictionary<string,string> head = new Dictionary<string,string> ();
		//head["Cookie"] = "ok=123";
		//head["token"] = "123";
		session.m_cHeader = head;
		session.SendGET(requestModel, (HTTPPacketAck ack) => {
			succ (ack);
		});
	} 

    /// <summary>
    /// 全局包名
    /// </summary>
    public static string SCOPE_NAME = "com.zhl.ketang.web";
    /// <summary>
    ///   检测软件是否有更新URL
    /// </summary> 
    public static string CHECK_UPDATE_URL = "http://zhl-education.xxfz.com.cn/api/resource/app/getapkversioninfo";
}