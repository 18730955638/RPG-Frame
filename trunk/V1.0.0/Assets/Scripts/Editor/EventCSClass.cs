using UnityEngine;
using System.Collections;

using U3DEventFrame;
using System;

public class EventCSClass : UIBase
{

    // 添加消息监听及处理
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)0:
                break;

            default:
                break;
        }
    }

    // 注册消息
    void Awake()
    {
        msgIds = new ushort[] {

        };
        RegistSelf(this, msgIds);
    }

    // 释放资源
    private void ReleaseBundle()
    {
        //HunkAssetRes tmpMsg = ObjectPoolManager<HunkAssetRes>.Instance.GetFreeObject();
        //tmpMsg.ChangeReleaseBundleMsg((ushort)AssetEvent.ReleaseBundleAndObject, "scenceName", "bundleName");
        //SendMsg(tmpMsg);
        //ObjectPoolManager<HunkAssetRes>.Instance.ReleaseObject(tmpMsg);
    }

    // 申请资源
    private void GetResources()
    {
        // 申请多个bundle 里面多个资源
        // bundle 对应的名字   以下是二个bundle 包

        // 例子
        /* string[] bundle = {
                                "TestOne","TestThree"
                          };
           string[][] resName = new string[2][];

           第一bundle 包里的资源名字
           resName[0] = new string[2] { "TestOne.prefab", "TestTwo.prefab" };
           第二bundle 包里的
           这里面要加后缀 .prefab .png----------TestTwo多个情况不用加----------
           resName[1] = new string[2] { "chooseLvl", "TestThree.prefab" };
           bool[][] singles = new bool[2][];

           第一bundle 包里的资源 是单个资源还是多个资源true 表示单个
           singles[0] = new bool[2] { true, true };
           第二bundle 包里的资源 是单个资源还是多个资源true 表示单个
           singles[1] = new bool[2] { false, true };
        */

        string[] bundle = { };
        string[][] resName = new string[0][];

        resName[0] = new string[0] { };

        bool[][] singles = new bool[0][];

        singles[0] = new bool[0] { };


        // 发起资源请求

        //AssetRequesetMsg tmpMsg = ObjectPoolManager<AssetRequesetMsg>.Instance.GetFreeObject();
        //tmpMsg.ChangeEventMsg((ushort)AssetEvent.HunkMutiRes, (ushort)BackId, "ScenceName", bundle, resName, singles);
        //SendMsg(tmpMsg);
        //ObjectPoolManager<AssetRequesetMsg>.Instance.ReleaseObject(tmpMsg);
    }


    private void JumpNextView()
    {
        // 跳转界面消息

        //MsgBase tmpMsg = ObjectPoolManager<MsgBase>.Instance.GetFreeObject();
        //tmpMsg.ChangeEventId((ushort)PoleEvent.ReadData);
        //SendMsg(tmpMsg);
        //ObjectPoolManager<MsgBase>.Instance.ReleaseObject(tmpMsg);
    }
}
