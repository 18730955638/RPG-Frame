using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageComponent:AbsTeachComponent{


    public ImageComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Render the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,float aspectRatio){
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject imageTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/ImageTemplate", typeof(GameObject))) as GameObject; 
        GameObject imageTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["ImageTemplate"]) as GameObject;
        imageTmp.transform.SetParent(parentTransform); 
		imageTmp.GetComponent <Image>().sprite = getImageSprite(res.path);
		renderPosition (imageTmp, res, aspectRatio);
        return imageTmp;
 	}
}