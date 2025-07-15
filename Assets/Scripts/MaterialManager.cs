using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public BallController ballController;

    public void SetSteel()
    {
        ballController.SetFriction(0.50f); // 얼음
    }

    public void SetGlass()
    {
        ballController.SetFriction(0.50f);  // 나무
    }

    public void SetWood()
    {
        ballController.SetFriction(0.35f);  // 모래
    }

    public void SetSand()
    {
        ballController.SetFriction(0.55f);
    }

    public void SetIce()
    {
        ballController.SetFriction(0.05f);
    }

    // 필요 시 더 추가
}
