using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardBtnManager : MonoBehaviour
{

    Button rewardBtn;
    GameObject awards;

    // Use this for initialization
    void Start()
    {
        rewardBtn = transform.GetChild(1).GetComponent<Button>();
        rewardBtn.onClick.AddListener(ClickBtn);
        awards = MainUIManager.Instance.awards;
    }

    void ClickBtn()
    {
        Debug.Log("click rewardBtn" + transform);
        if (!awards.activeSelf)
        {
            awards.SetActive(true);
        }
    }
}
