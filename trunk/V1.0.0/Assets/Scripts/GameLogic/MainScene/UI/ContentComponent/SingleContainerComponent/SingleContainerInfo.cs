using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleContainerInfo : MonoBehaviour
{
    byte id;
    bool isActive;
    bool isSelected;



    public byte Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
        }
    }

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }

        set
        {
            isSelected = value;
        }
    }

    public void OnMouseClick()
    {
        List<GameObject> infos = transform.parent.GetComponent<ComponentManager>().ObjectPool;
        Debug.Log(infos.Count);
        for (int i = 0; i < infos.Count; i++)
        {
            infos[i].GetComponent<SingleContainerInfo>().IsSelected = false;
        }
        IsSelected = true;
        Debug.Log("Click info");
    }
}
