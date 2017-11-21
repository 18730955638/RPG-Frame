using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Game.Network;
using System.Text;

using HTTP_ON_DATAERROR = System.Action<string,System.Action,System.Action>;


//  HttpSession.cs
//	Author: Yuxh
//	2017-09-22


namespace Game.Network
{

    /// <summary>
    /// HTTP会话
    /// </summary>
    public class HTTPSession
    {
        private string m_strURL = "";   //主地址

		public HTTP_ON_DATAERROR onDataError = null;
		public Dictionary<string,string> m_cHeader = null;

        public HTTPSession(string url)
        {
            this.m_strURL = url;
        }

        /// <summary>
        /// Sends the GET data.
        /// </summary>
        /// <param name="packet">Packet.</param>
        /// <param name="callback">Callback.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendGET<T>(HTTPPacketRequest packet ,System.Action<T>  callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
        {
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction() + packet.ToParam() , null , null , this.m_cHeader , onDataError , callback);
        }

		/// <summary>
		/// Post the specified packet and callback.
		/// </summary>
		/// <param name="packet">Packet.</param>
		/// <param name="callback">Callback.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendPOST<T>(HTTPPacketRequest packet ,System.Action<T> callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
		{ 
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction(), packet.ToForm() , null , this.m_cHeader , onDataError , callback);
		}



        /// <summary>
        /// 把模型转成对象发送出去
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="packet"></param>
        /// <param name="callback"></param>
        /// <param name="process"></param>
        public void SendJSON<T>(HTTPPacketRequest packet, System.Action<T> callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
        {
            HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction(), null, Encoding.Default.GetBytes(JsonUtility.ToJson(packet)), this.m_cHeader, onDataError, callback);
        }

        /// <summary>
        /// Sends the Bytes Data.
        /// </summary>
        /// <param name="packet">Packet.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="headers">Headers.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void SendBYTE<T>(HTTPPacketRequest packet ,System.Action<T> callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
		{
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction(), null , packet.ToMsgPacketByte() , this.m_cHeader , onDataError , callback);
		}
    }


}