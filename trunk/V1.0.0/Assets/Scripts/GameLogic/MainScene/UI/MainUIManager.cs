using UnityEngine;
using System.Collections;

using U3DEventFrame;
using System;

using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainUIManager : UIBases
{

    public static MainUIManager Instance;
    
    public GameObject avatarCellPre;
    public GameObject randomBtnPre;
    public GameObject randomView;
    public GameObject runner;
    public GameObject awards;

    // 添加消息监听及处理
    public override void ProcessEvent(MsgBase msg)
    {
        switch (msg.msgId)
        {
            case (ushort)UIEvents.Initial:
                Debug.Log("BaseUI Initial");
                GetResources();
                break;
            case (ushort)UIEvents.GetResource:
                Debug.Log("BaseUI LoadAsset");
                AssetResponseMsg resMsg = (AssetResponseMsg)msg;

                // 菜单工具栏
                UnityEngine.Object[] menuUI = resMsg.GetBundleRes("UI", "MenuUI.prefab");
                InitialPanle(menuUI[0]).AddComponent<MenuBarView>();

                // 奖励栏
                UnityEngine.Object[] contentAreaUI = resMsg.GetBundleRes("UI", "ContentArea.prefab");
                InitialPanle(contentAreaUI[0]);

                // PPT栏
                UnityEngine.Object[] rankingUI = resMsg.GetBundleRes("UI", "Ranking.prefab");
                InitialPanle(rankingUI[0]);
                // 随机选择栏
                UnityEngine.Object[] randomUI = resMsg.GetBundleRes("UI", "Random.prefab");
                InitialPanle(randomUI[0]);
                // 头像栏预设体
                avatarCellPre = resMsg.GetBundleRes("UI", "AvatarCell.prefab")[0] as GameObject;
                // 随机按钮栏
                UnityEngine.Object[] randomViewUI = resMsg.GetBundleRes("UI", "RandomView.prefab");
                randomView = InitialPanle(randomViewUI[0]);
                randomView.SetActive(false);
                // 随机按钮栏上面的随机按钮
                randomBtnPre = resMsg.GetBundleRes("UI", "RandomBtn.prefab")[0] as GameObject;
                // 奖励框
                UnityEngine.Object[] awardsUI = resMsg.GetBundleRes("UI", "Awards.prefab");
                awards = InitialPanle(awardsUI[0]);
                AwardsManager awardsManager = awards.AddComponent<AwardsManager>();
                awardsManager.IsRun = false;
                awards.SetActive(false);
                // 转轮界面
                UnityEngine.Object[] runnerUI = resMsg.GetBundleRes("UI", "Runner.prefab");
                runner = InitialPanle(runnerUI[0]);
                RunnerManager runnerManager = runner.AddComponent<RunnerManager>();
                runnerManager.IsRun = false;
                runner.SetActive(false);

                AddButtonLisenter("MenuUI", "Pre_n", MenuBarView.Instance.PrePage);
                AddButtonLisenter("MenuUI", "Next_n", MenuBarView.Instance.NextPage);
                AddButtonLisenter("Random", "Random_n", ClickRandomBtn);


                //AddButtonLisenter("Ranking", "Button", delegate() {

                //    print("hello");
                //});
                
                Transform tmpRandomCon = UIManager.instance.GetGameObject("Random", "Content_n").transform;
                for (int i = 0; i < 20; i++)
                {
                    GameObject tmp = Instantiate(avatarCellPre) as GameObject;
                    tmp.AddComponent<RewardBtnManager>();
                    tmp.transform.SetParent(tmpRandomCon);
                }

                tmpRandomCon.GetComponent<RectTransform>().sizeDelta = new Vector2(tmpRandomCon.GetComponent<RectTransform>().sizeDelta.x, tmpRandomCon.GetComponent<RectTransform>().sizeDelta.y);

                Transform tmpRankingCon = UIManager.instance.GetGameObject("Ranking", "Content_n").transform;
                for (int i = 0; i < 20; i++)
                {
                    GameObject tmp = Instantiate(avatarCellPre) as GameObject;
                    tmp.AddComponent<RewardBtnManager>();
                    tmp.transform.SetParent(tmpRankingCon);
                }

                tmpRankingCon.GetComponent<RectTransform>().sizeDelta = new Vector2(tmpRankingCon.GetComponent<RectTransform>().sizeDelta.x, tmpRankingCon.GetComponent<RectTransform>().sizeDelta.y);
                

                Transform tmpRandomView = UIManager.instance.GetGameObject("RandomView", "Content_n").transform;
                for (int i = 0; i < 7; i++)
                {
                    GameObject tmp = Instantiate(randomBtnPre) as GameObject;
                    tmp.AddComponent<RandomBtnManager>();
                    tmp.transform.SetParent(tmpRandomView);
                }

                tmpRandomView.GetComponent<RectTransform>().sizeDelta = new Vector2(tmpRandomView.GetComponent<RectTransform>().sizeDelta.x, tmpRandomView.GetComponent<RectTransform>().sizeDelta.y);

                break;
            default:
                break;
        }
    }

    void ClickRandomBtn()
    {

        randomView.SetActive(!randomView.activeSelf);

        // 测试转盘界面
        //if (!runner.activeSelf)
        //{
        //    runner.SetActive(true);
        //}
    }

    // 注册消息
    void Awake()
    {
        msgIds = new ushort[] {
            (ushort)UIEvents.Initial,
            (ushort)UIEvents.GetResource
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

        string[] bundle = {
            "UI"
        };
        string[][] resName = new string[1][];

        resName[0] = new string[9] {
            "MenuUI.prefab",
            "ContentArea.prefab",
            "Ranking.prefab",
            "Random.prefab",
            "RandomView.prefab",
            "AvatarCell.prefab",
            "Runner.prefab",
            "RandomBtn.prefab",
            "Awards.prefab"
        };

        bool[][] singles = new bool[1][];

        singles[0] = new bool[9] {
            true,true,true,true,true,true,true,true,true
        };
        // 发起资源请求

        AssetRequesetMsg tmpMsg = ObjectPoolManager<AssetRequesetMsg>.Instance.GetFreeObject();
        tmpMsg.ChangeEventMsg((ushort)AssetEvent.HunkMutiRes, (ushort)UIEvents.GetResource, "MainScene", bundle, resName, singles);
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
