using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public BallController ballController;

    public void SetSteel()
    {
        ballController.SetFriction(0.50f); // ����
    }

    public void SetGlass()
    {
        ballController.SetFriction(0.50f);  // ����
    }

    public void SetWood()
    {
        ballController.SetFriction(0.35f);  // ��
    }

    public void SetSand()
    {
        ballController.SetFriction(0.55f);
    }

    public void SetIce()
    {
        ballController.SetFriction(0.05f);
    }

    // �ʿ� �� �� �߰�
}
