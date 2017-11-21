using System.Collections; 
using System.IO; 
using NAudio;
using NAudio.Wave;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 音频组件
/// </summary>
public class AudioComponent:AbsTeachComponent
{
	IWavePlayer waveOutDevice;   
	AudioFileReader audioFileReader;
    TeachResourceModel teachRes;

    bool isPlay = false;

    public AudioComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Audio
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,float aspectRatio){
        teachRes = res;
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject audioTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/AudioTemplate", typeof(GameObject))) as GameObject;
        GameObject audioTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["AudioTemplate"]) as GameObject;
        audioTmp.transform.SetParent(parentTransform); 
        EventTrigger eventTrigger = audioTmp.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //UI事件类型
        entry.eventID = EventTriggerType.PointerClick;
        //添加响应函数
        entry.callback.AddListener(EventTriggerClick);
        //将事件对象压入eventTrigger的triggers中
        eventTrigger.triggers.Add(entry);
        //
        renderPosition (audioTmp, res, aspectRatio);

        string filePath = Application.streamingAssetsPath + "/" + teachRes.path;
        //string filePath = Application.streamingAssetsPath+"E:/yuworkspace/QjKetangbao/Assets/StreamingAssets/JJ1-61-V1.0-2017101800/1.mp3";
        waveOutDevice = new WaveOut();
        audioFileReader = new AudioFileReader(filePath);

        return audioTmp;
	}

    /// <summary>
    /// 点击播放
    /// </summary>
    /// <param name="data"></param>
    private void EventTriggerClick(BaseEventData data)
    {
        if (isPlay)
        {
            Debug.Log("播放暂停");
            isPlay = false;
            waveOutDevice.Pause();
        }
        else
        {
            if (waveOutDevice.PlaybackState == PlaybackState.Stopped)
            {
                string filePath = Application.streamingAssetsPath + "/" + teachRes.path;
                Debug.Log("音频路径" + filePath);
                //string filePath = Application.streamingAssetsPath+"E:/yuworkspace/QjKetangbao/Assets/StreamingAssets/JJ1-61-V1.0-2017101800/1.mp3";
                waveOutDevice = new WaveOut();
                audioFileReader = new AudioFileReader(filePath);
                //waveOutDevice.PlaybackStopped += new System.EventHandler<StoppedEventArgs>()
                waveOutDevice.Init(audioFileReader);
            }
            isPlay = true;
            waveOutDevice.Play();
        }
    }
}