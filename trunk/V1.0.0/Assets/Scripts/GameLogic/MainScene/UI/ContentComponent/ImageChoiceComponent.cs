using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// 
/// </summary>
public class ImageChoiceComponent : AbsTeachComponent
{

    public ImageChoiceComponent(Transform tra)
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
        //GameObject imgChoiceTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/ImageChoiceTemplate", typeof(GameObject))) as GameObject;
        GameObject imgChoiceTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["ImageChoiceTemplate"]) as GameObject;
        imgChoiceTmp.transform.SetParent(parentTransform);
        Button imgBtn = imgChoiceTmp.transform.Find("Button").GetComponent<Button>();
        Image btnImage = imgBtn.GetComponent<Image>(); 
        btnImage.sprite = getImageSprite(res.path);
        //------------------------------------------------------------------ 
        //定位
        renderPosition(imgChoiceTmp, res, aspectRatio);

        //----------------------------
        //选中
        imgBtn.onClick.AddListener(delegate () {
            //单选题
            if (cat.question.questionType.Equals("single-choice"))
            {
                //还原选项的状态
                GameObject[] arr = GameObject.FindGameObjectsWithTag("ImageChoiceBtn");
                for (int i = 0; i < arr.Length; i++)
                {
                    Button btn = arr[i].GetComponent<Button>();
                    //去掉按钮的点击效果
                }
                //当前点击的按钮置为高亮状态 
                //imgBtn.
            }
        });
        return imgChoiceTmp;
    }
}