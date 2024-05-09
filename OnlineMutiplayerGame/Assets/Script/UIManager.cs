using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text speedText; // don't know if it gonna work online 
    
    private PlayerController player;
  
    private void Start() 
    {
        player = FindAnyObjectByType<PlayerController>().GetComponent<PlayerController>();
    }

    private void Update() 
    {
        speedText.text = "Speed : "+ Mathf.Round(player.currentSpeed).ToString();
    }
}
