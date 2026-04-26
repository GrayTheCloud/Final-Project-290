using UnityEngine;

public class WiggleUI : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float rotationAngle = 10f;

    public float floatSpeed = 3f;
    public float floatAmount = 10f;

    private RectTransform rectTransform;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Wiggle (rotation)
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;
        rectTransform.rotation = Quaternion.Euler(0, 0, rotation);

        // Up and down movement
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        rectTransform.anchoredPosition = new Vector2(startPos.x, startPos.y + yOffset);
    }
}