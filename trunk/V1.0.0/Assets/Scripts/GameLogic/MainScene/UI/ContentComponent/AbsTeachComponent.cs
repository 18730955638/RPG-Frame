using System;
using UnityEngine;

/// <summary>
/// I teach component.
/// </summary>
public abstract class AbsTeachComponent
{
    protected Transform parentTransform;  

    /// <summary>
    /// Render the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public abstract GameObject render(CatalogModel cat, TeachResourceModel res,float aspectRatio);
 
    /// <summary>
    /// 图片转成Sprite
    /// </summary>
    /// <param name="imgPath"></param>
    /// <returns></returns>
    public Sprite getImageSprite(String imgPath) {
        string streamingPath = Application.streamingAssetsPath;
        WWW www = new WWW("file://" + streamingPath + "/" + imgPath);
        //
        Texture2D img = www.texture;
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));//后面Vector2就是你Anchors的Pivot的x/y属性值
    }

	/// <summary>
	/// 定位
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="res">Res.</param>
	/// <param name="aspectRatio">Aspect ratio.</param>
	public void renderPosition(GameObject obj, TeachResourceModel res,float aspectRatio){
        //aspectRatio = 1.2f;

        //按照比例进行缩放
        float pStartX = res.pointStart.x * aspectRatio;
        float pStartY = res.pointStart.y * aspectRatio;
        //结束坐标
        float pEndX = res.pointEnd.x * aspectRatio;
        float pEndY = res.pointEnd.y * aspectRatio; 
         //
        obj.transform.localPosition = new Vector3(pStartX + (pEndX-pStartX)/2, pStartY + (pEndY - pStartY) / 2, 0f);
         //设置组件的高度和宽度
 		obj.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Abs(pEndX - pStartX),Mathf.Abs(pEndY - pStartY)); 
        //设置缩放比例 
        obj.transform.localScale = new Vector3 (1.0f,1.0f,1.0f);
        //设置显示层级关系
        obj.transform.SetSiblingIndex(res.layer);
    }
}