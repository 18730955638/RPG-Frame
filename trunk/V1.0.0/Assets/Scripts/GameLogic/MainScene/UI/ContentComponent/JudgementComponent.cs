using System;
using UnityEngine;
using UnityEngine.UI;

public class JudgementComponent : AbsTeachComponent
{


    public JudgementComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Render the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,  float aspectRatio)
    {
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject judgementTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/JudgementTemplate", typeof(GameObject))) as GameObject;
        GameObject judgementTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["JudgementTemplate"]) as GameObject;
        judgementTmp.transform.SetParent(parentTransform);
        renderPosition(judgementTmp, res, aspectRatio);
        //
        Button correctBtn= judgementTmp.transform.Find("CorrectBtn").GetComponent<Button>();
        Button inCorrectBtn = judgementTmp.transform.Find("InCorrectBtn").GetComponent<Button>();
        

        correctBtn.onClick.AddListener(delegate () {
            
        });

        inCorrectBtn.onClick.AddListener(delegate () {

        });
        return judgementTmp;
    }


}