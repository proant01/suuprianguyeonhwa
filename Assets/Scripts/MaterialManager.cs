using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public BallController ballController;
    public SlopeController SlopeController; // 경사면 색 변경용
    public SlopeColorController SlopeColorController;
    public void SetSteel()
    {
        Debug.Log("Steel function!");
        ballController.SetFriction(0.50f);
        SlopeController.SetSlopeColor(new Color32(206, 213, 219, 255)); // 회색 계열
        SlopeColorController.SetSlopeColor(new Color32(206, 213, 219, 255)); // 회색 계열
    }

    public void SetGlass()
    {
        Debug.Log("Glass function!");
        ballController.SetFriction(0.50f);
        SlopeController.SetSlopeColor(new Color32(247, 247, 249, 255));
        SlopeColorController.SetSlopeColor(new Color32(247, 247, 249, 255));
    }

    public void SetWood()
    {
        Debug.Log("Wood function!");
        ballController.SetFriction(0.35f);
        SlopeController.SetSlopeColor(new Color32(111, 79, 40, 255)); // 갈색
        SlopeColorController.SetSlopeColor(new Color32(111, 79, 40, 255)); // 갈색
    }

    public void SetSand()
    {
        Debug.Log("Sand function!");
        ballController.SetFriction(0.55f);
        SlopeController.SetSlopeColor(new Color32(243, 229, 171, 255));
        SlopeColorController.SetSlopeColor(new Color32(243, 229, 171, 255));
    }

    public void SetIce()
    {
        Debug.Log("Ice function!");
        ballController.SetFriction(0.05f);
        SlopeController.SetSlopeColor(new Color32(165, 242, 243, 255)); // 연한 하늘색
        SlopeColorController.SetSlopeColor(new Color32(165, 242, 243, 255)); // 연한 하늘색
    }
}
