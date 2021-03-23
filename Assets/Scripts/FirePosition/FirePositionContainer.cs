using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirePositionContainer", 
menuName = "Assets/HOS/FirePositionContainer", order = 0)]
public class FirePositionContainer : ScriptableObject {
    // Fields
    [SerializeField] private List<Vector3> firePositions;

    // Properties
    public List<Vector3> FirePositions {
        get { return firePositions; }
        set { firePositions = value; }
    }

    // Methods
    public Vector3 GetPosition(int angle)
    {
        int currentIndex = angle + 180;
        return firePositions[currentIndex];
    }
}