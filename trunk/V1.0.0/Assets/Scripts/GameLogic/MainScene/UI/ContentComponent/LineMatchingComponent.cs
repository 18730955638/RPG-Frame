using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;
using System.Threading;
using UnityEngine.EventSystems;
/// <summary>
/// 
/// </summary>
public class LineMatchingComponent : AbsTeachComponent
{
    private VectorLine line;
    //是否可以开始画了
    private bool isDraw = false;

    private GameObject lineMatchTmp;
     
    /// <summary>
    /// 转换之后的GUI坐标
    /// </summary>
    public Vector3 lineMatchRectPos;
    /// <summary>
    /// 
    /// </summary>
    public TeachResourceModel teachRes;

    private Transform scrollview;

    private Vector3 offsetDir;
    private Vector3 startPos;
    private float offsetY;
    public LineMatchingComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Renderer the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,  float aspectRatio)
    {
        // Scroll View
        scrollview = parentTransform.parent.parent.parent;
        teachRes = res; 
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载
        //lineMatchTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/LineMatchTemplate", typeof(GameObject))) as GameObject;
        lineMatchTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["LineMatchTemplate"]) as GameObject;
        lineMatchTmp.transform.SetParent(parentTransform);
        Button btn = lineMatchTmp.transform.Find("Button").GetComponent<Button>();
        Text btnText = lineMatchTmp.transform.Find("Button/Text").GetComponent<Text>();
        //文本内容是空白的，代表是图片
        if (res.text.Equals(""))
        {
            Image btnImage = btn.GetComponent<Image>();
            btnImage.sprite = getImageSprite(res.path);
        }
        else
        {
            btnText.text = res.text;
        }
        //定位
        renderPosition(lineMatchTmp, res, aspectRatio);
        //
        lineMatchRectPos = lineMatchTmp.GetComponent<RectTransform>().localPosition; 
        //接收update画面刷新通知
        NotifacitionCenter.Instance.registerObserver(NotifyType.UPDATE, ObserveUpdate);
        //接收结束画线刷新通知
        NotifacitionCenter.Instance.registerObserver(NotifyType.LINE_MATCH_END, ObserveEndDraw);
        //
         btn.onClick.AddListener(delegate () {
             LineMatchModel lm = hasLine(cat, res);
            //已经有线
            if (lm != null)
            {
                //删除这条线
                VectorLine lineTemp = lm.line;
                cat.question.lineMathList.Remove(lm);
                VectorLine.Destroy(ref lineTemp);
            }
             //开始画线
             LineMatchModel lining = getLiningLine(cat, res);
            if (lining == null)
            {
                //开始画新的线
                startLining(cat, res);
            }
            //结束画线
            else
            {
                //点已经存在了
                lining.endRes = res;
                //线条结束
                lining.lineState = 1;
                //通知开始按钮 
                Dictionary<string, System.Object> dic = new Dictionary<string, System.Object>();
                dic.Add("startRes",lining.startRes);
                dic.Add("endPosVect", lineMatchRectPos);
                NotifacitionCenter.Instance.postNotification(new NotifyEvent(NotifyType.LINE_MATCH_END, dic));
            }
        });
        return lineMatchTmp;
    } 

    /// <summary>
    /// 开始画一条线
    /// </summary>
    /// <param name="cat"></param>
    /// <param name="res"></param>
    /// <param name="screenPos"></param>
    public void startLining(CatalogModel cat, TeachResourceModel res) {
        offsetDir = parentTransform.position - scrollview.position;
        LineMatchModel lineMatch = new LineMatchModel();
        lineMatch.startRes = res;
        lineMatch.lineState = 0;
        lineMatch.line = getLine();
        isDraw = true; 
        line.points2.Add(lineMatchRectPos);
        line.points2.Add(Vector2.zero);
        cat.question.lineMathList.Add(lineMatch);
        startPos = line.points2[0];
    } 
    /// <summary>
    /// 判断是否是有线
    /// </summary>
    /// <returns></returns>
    public LineMatchModel hasLine(CatalogModel cat, TeachResourceModel res)
    {
        for (int i = 0; i < cat.question.lineMathList.Count; i++)
        {
            LineMatchModel lm = cat.question.lineMathList[i] as LineMatchModel;
            if ((lm.startRes != null && lm.startRes.rid == res.rid) || (lm.endRes != null && lm.endRes.rid == res.rid))
            {
                return lm;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取正在画的线
    /// </summary>
    /// <param name="cat"></param>
    /// <param name="res"></param>
    /// <returns></returns>
    public LineMatchModel getLiningLine(CatalogModel cat, TeachResourceModel res)
    { 
        for (int i = 0; i < cat.question.lineMathList.Count; i++)
        {
            LineMatchModel lm = cat.question.lineMathList[i] as LineMatchModel;
            //一个时刻只存在一条线，所有只要有一条线正在画就表示现在点击是要结束
            if (lm.lineState == 0)
            {
                return lm;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取一条线q
    /// </summary>
    public VectorLine getLine() {
        line = new VectorLine("Line", new List<Vector2>(), null, 4.0f);
        line.SetCanvas(parentTransform.GetComponent<Canvas>());  
        line.drawTransform = parentTransform;
        return line;
    }

    /// <summary>
    /// 结束画线的通知
    /// </summary>
    /// <param name="evt"></param>
    public void ObserveEndDraw(NotifyEvent evt) {
        
        //终点改成 
        if (line!=null) { 
            Dictionary<string,System.Object> dic = (Dictionary<string, System.Object>)evt.Sender; 
            System.Object endPosVect,startRes;
            dic.TryGetValue("endPosVect", out endPosVect);
            dic.TryGetValue("startRes", out startRes);
            Vector3 endPos = (Vector3)endPosVect;
            if (((TeachResourceModel)startRes).rid == teachRes.rid)
            {
                isDraw = false;
                line.points2[1] = new Vector3(endPos.x, endPos.y - offsetY,0f);
                line.Draw();
            }
        }
    }
    /// <summary>
    /// 监听来自menubarview的update事件
    /// </summary>
    /// <param name="evt"></param>
    public void ObserveUpdate(NotifyEvent evt)
    { 
        if (isDraw) {
            offsetY = Mathf.Abs(Vector3.Distance(parentTransform.position - scrollview.position, offsetDir));
            Vector3 mousePos = parentTransform.InverseTransformPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y - offsetY, 0f);
            line.points2[1] = mousePos;
            line.points2[0] = new Vector3(startPos.x, startPos.y - offsetY, 0f);
            line.Draw(); 
        }
    } 
}