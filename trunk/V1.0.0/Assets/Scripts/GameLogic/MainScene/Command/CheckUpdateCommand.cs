using UnityEngine; 
using Game.Network;
using System;

/// <summary>
/// 检查相应的更新Command
/// </summary>
public class CheckUpdateCommand
{

    // Use this for initialization
    void CheckUpdate()
    {
        //testA.Test ();

        //检测是否有网络,无网络的情况
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {

        }
        else//有网络的情况
        {
            //Step1检测软件是否有更新
            CheckAppUpdateModel model = new CheckAppUpdateModel();
            HttpUtils.Post(HttpUtils.CHECK_UPDATE_URL, model, new HttpUtils.ReqSuccess(reqSuccess), new HttpUtils.ReqFailed(reqFailed));
            //Step2是否处于登录状态
        }
    }

    private void reqSuccess(HTTPPacketAck ack)
    {
        Debug.Log(ack.desc);
    }

    private void reqFailed(string error, System.Action resendAction, System.Action closeAction)
    {
    }
}