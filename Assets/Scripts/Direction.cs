using UnityEngine;

public class Direction : MonoBehaviour{
    // Fields
	private int directionAngle;

    // Properties
    public int GetDirectionAngle
    {
        get { return directionAngle; }
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
        directionAngle = Mathf.FloorToInt(degree);
    }
}
