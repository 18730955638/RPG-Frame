using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour {

    List<GameObject> objectPool;

    public List<GameObject> ObjectPool
    {
        get
        {
            if (objectPool == null) objectPool = new List<GameObject>();
            return objectPool;
        }

        set
        {
            objectPool = value;
        }
    }

    public void AddObject(GameObject obj)
    {
        ObjectPool.Add(obj);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
