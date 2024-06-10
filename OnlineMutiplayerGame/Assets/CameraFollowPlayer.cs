using UnityEngine;
using UnityEngine.Networking;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Camera mainCamera;
    public bool isLocalPlayer;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            if (mainCamera != null)
            {
                mainCamera.gameObject.SetActive(false);
            }
            return;
        }

        if (mainCamera != null && playerTransform != null)
        {
            mainCamera.gameObject.SetActive(true);
            offset = mainCamera.transform.position - playerTransform.position;
        }
        else
        {
            Debug.LogError("Player Transform or Main Camera is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer || playerTransform == null || mainCamera == null)
        {
            return;
        }

        // Update the camera position to follow the player
        Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, 3.95f, mainCamera.transform.position.z);
        mainCamera.transform.position = targetPosition;
    }
}