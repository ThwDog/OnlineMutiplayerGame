using Cinemachine;
using UnityEngine;

public class ScreenBoundarie : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public CinemachineVirtualCamera C_cam;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        C_cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        C_cam.Follow = this.gameObject.transform;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    void Update()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x + objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 - objectHeight , screenBounds.y + objectHeight);
        transform.position = viewPos;
    }
}
