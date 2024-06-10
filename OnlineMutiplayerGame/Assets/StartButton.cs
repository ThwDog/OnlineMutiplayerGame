using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;
    private GameManager gameManager;
    void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        gameManager.isStart = true;
    }

    
}
