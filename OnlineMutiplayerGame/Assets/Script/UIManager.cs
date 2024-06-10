using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text speedText; // don't know if it gonna work online 
    [SerializeField] TMP_Text timeText; // don't know if it gonna work online 
    float time;
    
    private PlayerController player;
    private GameManager gameManager;
  
    private void Start() 
    {
        player = FindAnyObjectByType<PlayerController>().GetComponent<PlayerController>();
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void Update() 

    {
        if (!player)
        {
            //player = FindAnyObjectByType<PlayerController>().GetComponent<PlayerController>();
        }
        else
        {
            speedText.text = "Speed : " + Mathf.Round(player.currentSpeed).ToString();
        }
        
        if(!gameManager)
        {
            gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        }
        else
        {
            if (gameManager.isStart)
                time += Time.deltaTime;

            timeText.text = "Time : " + Mathf.Round(time).ToString();
        }
        
    }
}
