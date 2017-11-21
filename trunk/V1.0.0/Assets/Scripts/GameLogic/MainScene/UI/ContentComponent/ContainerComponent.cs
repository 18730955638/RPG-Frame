using System;
using UnityEngine;
using UnityEngine.UI;

public class ContainerComponent : AbsTeachComponent
{

    public ContainerComponent(Transform tra)
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
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject containerTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/ContainerTemplate", typeof(GameObject))) as GameObject;
        GameObject containerTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["ContainerTemplate"]) as GameObject;
        containerTmp.transform.SetParent(parentTransform); 
        renderPosition(containerTmp, res, aspectRatio);
        return containerTmp;
    }
}