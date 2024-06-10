using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UINetworkManager : MonoBehaviour
{
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    void Start()
    {
        HostButton.onClick.AddListener(OnClickHostButton);
        ClientButton.onClick.AddListener(OnClickClientButton);
    }

    private void OnClickClientButton()
    {
        NetworkManager.Singleton.StartClient();
        Display.displays[1].Activate();
    }

    private void OnClickHostButton()
    {
        NetworkManager.Singleton.StartHost();
        Display.displays[0].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
