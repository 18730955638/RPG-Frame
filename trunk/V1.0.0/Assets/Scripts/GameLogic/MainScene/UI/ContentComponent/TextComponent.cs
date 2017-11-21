using System;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent:AbsTeachComponent{

    public TextComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Renderer the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,float aspectRatio){
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject textTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/TextTemplate", typeof(GameObject))) as GameObject; 
        GameObject textTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["TextTemplate"]) as GameObject;
        textTmp.transform.SetParent(parentTransform);
		//设置字体和字体颜色及大小
		textTmp.GetComponent<Text> ().text = "<color="+res.color+"><size="+res.fontSize * aspectRatio+">"+res.text+"</size></color>";
		//设置对齐
		//UpperLeft, UpperCenter, UpperRight, MiddleLeft, MiddleCenter,MiddleRight,LowerLeft,LowerCenter,LowerRight
		if(res.alignment.Equals("UpperLeft")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.UpperLeft;
		}else if(res.alignment.Equals("UpperCenter")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
		}else if(res.alignment.Equals("UpperRight")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.UpperRight;
		}else if(res.alignment.Equals("MiddleLeft")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
		}else if(res.alignment.Equals("MiddleCenter")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.MiddleCenter;
		}else if(res.alignment.Equals("MiddleRight")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.MiddleRight;
		}else if(res.alignment.Equals("LowerLeft")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.LowerLeft;
		}else if(res.alignment.Equals("LowerCenter")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.LowerCenter;
		}else if(res.alignment.Equals("LowerRight")){
			textTmp.GetComponent<Text> ().alignment = TextAnchor.LowerRight;
		} 
		//定位
		renderPosition (textTmp,res,aspectRatio);
        return textTmp;
	}
}