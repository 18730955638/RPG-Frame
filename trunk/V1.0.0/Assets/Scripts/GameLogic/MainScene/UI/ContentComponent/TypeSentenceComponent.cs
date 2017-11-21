using System;
using UnityEngine;
using UnityEngine.UI;

public class TypeSentenceComponent : AbsTeachComponent
{


    public TypeSentenceComponent(Transform tra)
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
        //GameObject judgementTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/FillBlankTemplate", typeof(GameObject))) as GameObject;
        GameObject typesentenceTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["TypeSentenceTemplate"]) as GameObject;
        typesentenceTmp.transform.SetParent(parentTransform);
        renderPosition(typesentenceTmp, res, aspectRatio);
        return typesentenceTmp;
    }

}