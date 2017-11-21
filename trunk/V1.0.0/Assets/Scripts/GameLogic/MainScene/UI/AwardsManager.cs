using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardsManager : MonoBehaviour {

    bool isRun;

    float timer;

    public bool IsRun
    {
        get
        {
            return isRun;
        }

        set
        {
            isRun = value;
        }
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
