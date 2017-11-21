using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SingleSortingComponent : AbsTeachComponent
{
    public SingleSortingComponent(Transform tra)
    {
        parentTransform = tra;
    }

    private SingleContainerInfo info;
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
        //GameObject container = sortTmp.transform.parent.Find("SingleContainerTemplate(Clone)").gameObject;
        //设置字体和字体颜色及大小
        renderPosition(sortTmp, res, aspectRatio);
        Vector2 sizeDelta = sortTmp.GetComponent<RectTransform>().sizeDelta;
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

        SingleSortingComponent thiz = this;
        btn.onClick.AddListener(delegate () {
            if (btn.transform.parent == sortTmp.transform)
            {
                List<GameObject> infos = sortTmp.transform.parent.GetComponent<ComponentManager>().ObjectPool;
                bool isSet = false;
                // 有选中的空格则将词加入选中的空格中
                for (int i = 0; i < infos.Count; i++)
                {
                    info = infos[i].GetComponent<SingleContainerInfo>();
                    if (info.IsSelected)
                    {
                        isSet = true;
                        info.IsActive = true;
                        info.IsSelected = false;
                        btn.transform.SetParent(info.transform);
                        btn.transform.position = info.transform.position;
						var rt = btn.GetComponent<RectTransform>();
						rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeDelta.x);  
						rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeDelta.y); 
                        break;
                    }
                }
                // 没有选中的空格时，将词加入空着的空格中
                if (!isSet)
                {
                    for (int i = 0; i < infos.Count; i++)
                    {
                        info = infos[i].GetComponent<SingleContainerInfo>();
                        if (!info.IsActive)
                        {
                            info.IsActive = true;
                            info.IsSelected = false;
                            btn.transform.SetParent(info.transform);
                            btn.transform.position = info.transform.position;
                            btn.GetComponent<RectTransform>().sizeDelta = sizeDelta;
                            break;
                        }
                    }
                }
            }
            else
            {
                info.IsActive = false;
                GameObject.Destroy(btn.gameObject);
                GameObject.Destroy(sortTmp);
                render(cat, res, aspectRatio);
            }
        });
        return sortTmp;
    }


}