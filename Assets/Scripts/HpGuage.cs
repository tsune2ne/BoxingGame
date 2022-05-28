using UnityEngine;

public class HpGuage : MonoBehaviour
{
    Vector2 baseSize;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        baseSize = rect.sizeDelta;
    }

    public void UpdateHpGuage(float hpRate)
    {
        rect.sizeDelta = new Vector2(baseSize.x * hpRate, baseSize.y);
    }
}
