using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChoiceComponent : AbsTeachComponent{

    public TextChoiceComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Renderer the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res,  float aspectRatio){
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject textChoiceTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/TextChoiceTemplate", typeof(GameObject))) as GameObject;
        GameObject textChoiceTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["TextChoiceTemplate"]) as GameObject;
        textChoiceTmp.transform.SetParent(parentTransform);
        Button btn = textChoiceTmp.transform.Find("Button").GetComponent<Button>(); 
        Text btnText = textChoiceTmp.transform.Find("Button/Text").GetComponent<Text>();
        btnText.text = res.text;
        //定位
        renderPosition(textChoiceTmp, res, aspectRatio);

        //----------------------------
        //选中
        btn.onClick.AddListener(delegate () {
            //单选题
            if (cat.question.questionType.Equals("single-choice"))
            {
                //还原选项的状态
                GameObject[] arr = GameObject.FindGameObjectsWithTag("TextChoiceBtn");
                for (int i=0;i<arr.Length;i++)
                {
                   Text cText = arr[i].transform.Find("Text").GetComponent<Text>();
                    cText.color = Color.black;
                }
                //当前点击的按钮置为高亮状态
                btnText.color = Color.red; 
            }
        });
        return textChoiceTmp;
    }
}