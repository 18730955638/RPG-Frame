using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using U3DEventFrame;

public class RandomBtnManager : MonoBehaviour {

    Button btn;
    GameObject runner;
    GameObject randomView;
	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickBtn);
        randomView = MainUIManager.Instance.randomView;
        runner = MainUIManager.Instance.runner;
    }

    void ClickBtn()
    {
        randomView.SetActive(false);
        if (!runner.activeSelf)
        {
            runner.SetActive(true);
        }
    }
}
