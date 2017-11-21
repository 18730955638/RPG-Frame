using UnityEngine;
using System.Collections;
using U3DEventFrame;

using System.IO;
using System;
using UnityEngine.UI;

public class MainOthers : AssetBase
{

    public bool openDebug = true;

    public bool IsUsingLua = true;
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)CheckAssetEvents.CheckFinish:
                {
                    gameObject.AddComponent<ILoadManager>();

                    if (IsUsingLua)
                    {
                        gameObject.AddComponent<LuaClient>();
                    }

                    gameObject.AddComponent<ComponentTemplate>();
                    MsgBase loadTemp = ObjectPoolManager<MsgBase>.Instance.GetFreeObject();
                    loadTemp.ChangeEventId((ushort)LoadTemplate.Initial);
                    SendMsg(loadTemp);
                    ObjectPoolManager<MsgBase>.Instance.ReleaseObject(loadTemp);


                    gameObject.AddComponent<MainUIManager>();
                    MsgBase showUI = ObjectPoolManager<MsgBase>.Instance.GetFreeObject();
                    showUI.ChangeEventId((ushort)UIEvents.Initial);
                    SendMsg(showUI);
                    ObjectPoolManager<MsgBase>.Instance.ReleaseObject(showUI);

                }
                break;
        }
    }
    public void SetPathTools()
    {

#if UNITY_ANDROID

        IPathTools.pathTargetPlatform = 2;
 
#endif

#if UNITY_IPHONE
           IPathTools.pathTargetPlatform = 3;

#endif

#if UNITY_STANDALONE_WIN

        IPathTools.pathTargetPlatform = 1;

#endif
    }
    
    void Awake()
    {
        msgIds = new ushort[]
            {
               (ushort)CheckAssetEvents.CheckFinish
            };

        RegistSelf(this, msgIds);
        
        SetPathTools();

        gameObject.AddComponent<LuaAndCMsgCenter>();

        gameObject.AddComponent<NativeLoadRes>();
        gameObject.AddComponent<NativeLoadMutiRes>();
        
        gameObject.AddComponent<GameLogic>();

        
    }

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 40;

        
    }
    void Update()
    {

    }
}
