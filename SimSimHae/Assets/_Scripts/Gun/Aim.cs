using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform handlePos;
    public Transform aimPos;
    public Transform gunTrm;

    public Camera mainCam;
    public Camera gunCam;

    public float maimCamFov = 60.0f;
    public float gunCamFoV = 40.0f;
    public float zoomFoV = 45.0f;
    public float gunCamZoomFoV = 30.0f;

    public float ads = 0.25f;

    private void Start()
    {
        gunTrm.localPosition = handlePos.localPosition;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            gunTrm.localPosition = Vector3.Lerp(gunTrm.localPosition, aimPos.localPosition, ads);
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, zoomFoV, ads);
            gunCam.fieldOfView = Mathf.Lerp(gunCam.fieldOfView, gunCamZoomFoV, ads);
        }
        else
        {
            gunTrm.localPosition = Vector3.Lerp(gunTrm.localPosition, handlePos.localPosition, ads);
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, maimCamFov, ads);
            gunCam.fieldOfView = Mathf.Lerp(gunCam.fieldOfView, gunCamFoV, ads);
        }
    }
}