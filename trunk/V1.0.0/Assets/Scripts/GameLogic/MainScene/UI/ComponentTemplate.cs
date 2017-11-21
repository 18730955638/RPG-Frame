using UnityEngine;
using System.Collections;

using U3DEventFrame;
using System;
using System.Collections.Generic;

public class ComponentTemplate : UIBases
{

    public static ComponentTemplate Instance;
    Dictionary<string, GameObject> templateDic;
    public Dictionary<string, GameObject> TemplateDic
    {
        get
        {
            if (templateDic == null) templateDic = new Dictionary<string, GameObject>();
            return templateDic;
        }
    }

    public void AddTemplate(string name,GameObject template)
    {
        TemplateDic.Add(name, template);
    }

    string[] templateName;
    // 添加消息监听及处理
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)LoadTemplate.Initial:
                GetConfig();
                break;

            case (ushort)LoadTemplate.GetConfig:

                Debug.Log("Config Load");
                AssetResponseMsg configMsg = (AssetResponseMsg)msg;
                UnityEngine.Object[] configTxt = configMsg.GetBundleRes("Config", "TemplateConfig.txt");
                TextAsset config = (TextAsset)configTxt[0];
                templateName = config.text.Split('|');
                Debug.Log("templateName Length===============================" + templateName.Length);
                GetResources();
                break;
            case (ushort)LoadTemplate.GetResource:
                AssetResponseMsg resMsg = (AssetResponseMsg)msg;
                for (int i = 0; i < templateName.Length; i++)
                {
                    UnityEngine.Object[] tempPre = resMsg.GetBundleRes("ContentTemplate", templateName[i]);
                    AddTemplate(templateName[i].Replace(".prefab", ""), tempPre[0] as GameObject);
                }
                break;
            default:
                break;
        }
    }

    // 注册消息
    void Awake()
    {
        msgIds = new ushort[] {
            (ushort)LoadTemplate.Initial,
            (ushort)LoadTemplate.GetConfig,
            (ushort)LoadTemplate.GetResource
        };
        RegistSelf(this, msgIds);

        Instance = this;
    }

    // 释放资源
    private void ReleaseBundle()
    {
        //HunkAssetRes tmpMsg = ObjectPoolManager<HunkAssetRes>.Instance.GetFreeObject();
        //tmpMsg.ChangeReleaseBundleMsg((ushort)AssetEvent.ReleaseBundleAndObject, "scenceName", "bundleName");
        //SendMsg(tmpMsg);
        //ObjectPoolManager<HunkAssetRes>.Instance.ReleaseObject(tmpMsg);
    }

    private void GetConfig()
    {
        string[] bundle = { "Config" };
        string[][] resName = new string[1][];

        resName[0] = new string[1] { "TemplateConfig.txt" };

        bool[][] singles = new bool[1][];

        singles[0] = new bool[1] { true };
        
        AssetRequesetMsg tmpMsg = ObjectPoolManager<AssetRequesetMsg>.Instance.GetFreeObject();
        tmpMsg.ChangeEventMsg((ushort)AssetEvent.HunkMutiRes, (ushort)LoadTemplate.GetConfig, "MainScene", bundle, resName, singles);
        SendMsg(tmpMsg);
        ObjectPoolManager<AssetRequesetMsg>.Instance.ReleaseObject(tmpMsg);
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

        string[] bundle = { "ContentTemplate" };
        string[][] resName = new string[1][];

        resName[0] = templateName;

        bool[][] singles = new bool[1][];

        List<bool> boolList = new List<bool>();
        for (int i = 0; i < templateName.Length; i++)
        {
            boolList.Add(true);
        }
        singles[0] = boolList.ToArray();


        // 发起资源请求

        AssetRequesetMsg tmpMsg = ObjectPoolManager<AssetRequesetMsg>.Instance.GetFreeObject();
        tmpMsg.ChangeEventMsg((ushort)AssetEvent.HunkMutiRes, (ushort)LoadTemplate.GetResource, "MainScene", bundle, resName, singles);
        SendMsg(tmpMsg);
        ObjectPoolManager<AssetRequesetMsg>.Instance.ReleaseObject(tmpMsg);
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
