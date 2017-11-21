using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SortingComponent : AbsTeachComponent
{
    public SortingComponent(Transform tra)
    {
        parentTransform = tra;
    }
    /// <summary>
    /// Renderer the specified res, parentArea and aspectRatio.
    /// </summary>
    /// <param name="res">Res.</param>
    /// <param name="parentArea">Parent area.</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    public override GameObject render(CatalogModel cat, TeachResourceModel res, float aspectRatio)
    {
        //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载  
        //GameObject sortTmp = GameObject.Instantiate(Resources.Load("ContentTemplate/SortingTemplate", typeof(GameObject))) as GameObject;
        GameObject sortTmp = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["SortingTemplate"]) as GameObject;
        sortTmp.transform.SetParent(parentTransform);
        Button btn = sortTmp.transform.Find("Button").GetComponent<Button>();
        GameObject container = sortTmp.transform.parent.Find("ContainerTemplate(Clone)").gameObject;
        Transform containerTransform = container.transform; 
        //设置字体和字体颜色及大小
        renderPosition(sortTmp, res, aspectRatio);
        Vector2 sizeDelta = sortTmp.GetComponent<RectTransform>().rect.size;
        //是图片
         if ("".Equals(res.text))
        { 
            btn.GetComponent<Image>().sprite = getImageSprite(res.path);
        }
        else
        {
            Text btnText = sortTmp.transform.Find("Button/Text").GetComponent<Text>();
            btnText.text = res.text;
        } 

        SortingComponent thiz = this;
        btn.onClick.AddListener(delegate () {
            if (btn.transform.parent == sortTmp.transform)
            {
                //Tweener tweener = btn.GetComponent<RectTransform>().DOMove(container.GetComponent<RectTransform>().position, 0.2f);

                //tweener.onComplete = delegate () {
                   btn.transform.SetParent(container.transform);
                   btn.GetComponent<RectTransform>().sizeDelta = sizeDelta;
               // };
                 
            }
            else
            {
              // btn.transform.SetParent(sortTmp.transform);
                GameObject.Destroy(btn.gameObject);
                 GameObject.Destroy(sortTmp);
                 render(cat, res, aspectRatio);
            }
        });
        return sortTmp;
    }  

    
}