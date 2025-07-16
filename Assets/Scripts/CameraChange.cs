using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public GameObject panel; // 패널 오브젝트 받아오기

    public void SwitchToCamera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
        panel.SetActive(false); // 패널 비활성화
    }
}
