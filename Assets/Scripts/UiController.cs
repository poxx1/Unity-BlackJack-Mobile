using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Button buttonDeal;
    public Button buttonHit;
    public Button buttonStand;

    private void Start()
    {
        DisableAll();
    }

    public void DisableAll()
    {
        buttonDeal.interactable = false;
        buttonHit.interactable = false;
        buttonStand.interactable = false;
    }
}
