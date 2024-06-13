using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.UI;

public class UINetworkManager : MonoBehaviour
{
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    [SerializeField] private Button StartButton;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        // if (AuthenticationService.Instance.PlayerId == LobbyManager.Instance.hostLobby.HostId)
        // {
        //     StartButton.gameObject.SetActive(true);
        // }
        // else StartButton.gameObject.SetActive(false);

        HostButton.onClick.AddListener(OnClickHostButton);
        ClientButton.onClick.AddListener(OnClickClientButton);
        StartButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        gameManager.isStart = true;
    }

    private void OnClickClientButton()
    {
        NetworkManager.Singleton.StartClient();
        // Display.displays[1].Activate();
    }

    private void OnClickHostButton()
    {
        NetworkManager.Singleton.StartHost();
        // Display.displays[0].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
