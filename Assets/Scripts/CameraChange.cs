using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public GameObject panel; // �г� ������Ʈ �޾ƿ���

    public void SwitchToCamera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
        panel.SetActive(false); // �г� ��Ȱ��ȭ
    }
}
