using UnityEngine;

public class Direction : MonoBehaviour{
    // Fields
	private int angle;

    // Properties
    public int GetAngle
    {
        get { return angle; }
    }

    // Methods
    void Update()
    {
        UpdateDirection();
    }
    public void UpdateDirection()
    {
        float horizontalCursorDistance = Input.mousePosition.x - (Screen.width / 2);
        float verticalCursorDistance = Input.mousePosition.y - (Screen.height / 2);
        float radian = Mathf.Atan2(verticalCursorDistance, horizontalCursorDistance);
        float degree = radian * Mathf.Rad2Deg;
        angle = Mathf.FloorToInt(degree);
    }
}
