using UnityEngine;

public class PanelChange : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    
    public void SwitchToPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
