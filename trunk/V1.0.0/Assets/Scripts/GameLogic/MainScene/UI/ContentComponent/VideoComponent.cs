using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;

public class VideoComponent : AbsTeachComponent
{
    private MovieTexture movieTexture;


    /// <summary>
    /// 构造器
    /// </summary>
    /// <param name="mono"></param>
    public VideoComponent(Transform tra)
    {
        parentTransform = tra;
    } 
    /// <summary>
    /// Render the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res, float aspectRatio)
    {
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject videoTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/VideoTemplate", typeof(GameObject))) as GameObject;
        GameObject videoTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["VideoTemplate"]) as GameObject;
        videoTmp.transform.SetParent(parentTransform);
        string streamingPath = Application.streamingAssetsPath; 
        MediaPlayer mediaPlayer= videoTmp.transform.Find("Media/MediaPlayer").GetComponent<MediaPlayer>();
        mediaPlayer.m_VideoPath = streamingPath + "/" + res.path;

        //视频控制组件显示隐藏
        bool Isshow = true;
        Transform m_controller = videoTmp.transform.Find("Controller");
        mediaPlayer.transform.parent.GetComponent<Button>().onClick.AddListener(delegate() {
            Isshow = !Isshow;
            m_controller.gameObject.SetActive(Isshow);
        });

        //音量
        Button m_VolumeCon = videoTmp.transform.Find("Controller/Container/VolumeControl").GetComponent<Button>();       
        Slider m_VolumeSlider = m_VolumeCon.transform.GetComponentInChildren<Slider>();
        m_VolumeCon.transform.GetChild(0).gameObject.SetActive(false);
        m_VolumeCon.onClick.AddListener(delegate()
        {
            m_VolumeCon.transform.GetChild(0).gameObject.SetActive(!m_VolumeCon.transform.GetChild(0).gameObject.activeSelf);
        });
        m_VolumeSlider.onValueChanged.AddListener(delegate(float value) {
            value = m_VolumeSlider.value;
            mediaPlayer.Control.SetVolume(value);
        });

        //进度条
        Slider m_Progress = videoTmp.transform.Find("Controller/Container/Progress").GetComponent<Slider>();
        m_Progress.onValueChanged.AddListener(delegate(float value) {
            mediaPlayer.Control.SeekFast(m_Progress.value);
        });

        //播放
        bool Isplay = false;
        Button playBtn = videoTmp.transform.Find("Controller/PlayBtn").GetComponent<Button>();
        playBtn.GetComponent<Image>().sprite = getSprite("播放");     
        playBtn.onClick.AddListener(delegate()
        {
            Isplay = !Isplay;
            if (Isplay)
            {
                mediaPlayer.Control.Play();
                mediaPlayer.Control.SetVolume(m_VolumeSlider.value);
                //更改图片  
                playBtn.GetComponent<Image>().sprite = getSprite("暂停");
                return;
            }
            mediaPlayer.Control.Pause();
            playBtn.GetComponent<Image>().sprite = getSprite("播放");

        });

        

        ////全屏
        //Button fullScene = m_controller.transform.Find("FullSceneBtn").GetComponent<Button>();
        //bool Isfull = false;
        //RectTransform rect = videoTmp.transform as RectTransform;
        //Vector2 temp = rect.sizeDelta;
        //Transform par = videoTmp.transform.parent;
        //Vector3 parv = (videoTmp.transform as RectTransform).localPosition;
        //List<Transform> All = new List<Transform>();
        //foreach (Transform item in GameObject.Find("Canvas").transform)
        //{
        //    if (item.name != "Background" && item.gameObject.activeInHierarchy) All.Add(item);
        //}           
        //fullScene.onClick.AddListener(delegate() {
        //    Isfull = !Isfull;            
        //    videoTmp.transform.parent = GameObject.Find("Canvas").transform.Find("Background");
        //    videoTmp.transform.localPosition = Vector3.zero;
           
        //    if (Isfull)
        //    {
        //        rect.sizeDelta = new Vector2(Screen.width,Screen.height);
        //        for (int i = 0; i < All.Count; i++)
        //        {
        //            All[i].gameObject.SetActive(false);
        //        }

        //        return;
        //    }
        //    for (int i = 0; i < All.Count; i++)
        //    {
        //        All[i].gameObject.SetActive(true);
        //        videoTmp.transform.parent = par;
        //        (videoTmp.transform as RectTransform).localPosition = parv;
        //    }
        //    rect.sizeDelta = temp;

        //});

        renderPosition(videoTmp, res, aspectRatio);
        return videoTmp;
    }

    
    /// <summary>
    /// 通过路径获取Sprite
    /// </summary>
    /// <param name="imgPath"></param>
    /// <returns></returns>
    public Sprite getSprite(String imgPath)
    {
        string Path = Application.dataPath;
        WWW www = new WWW("file://" + Path + "/"+"Art/Scences/MainScene/UI/Texture/tex/" + imgPath+".png");
        //
        Texture2D img = www.texture;
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));//后面Vector2就是你Anchors的Pivot的x/y属性值
    }
}