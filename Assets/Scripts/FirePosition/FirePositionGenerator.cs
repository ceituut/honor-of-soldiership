using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

public class FirePositionGenerator : MonoBehaviour {
	// Fields
    public GameObject body, firePosition;
	public  GameObject bodySpriteContainer;
	public  FirePositionContainer firePositionContainer;
    [SerializeField] private Dictionary<int, Vector3> firePositionsDic;
    [Range(-180, 180) , SerializeField] private int angle;
    [Range(-180, 180)] private int currentAngle;

    // Properties
    public int Angle {
        get { return angle; }
        set { angle = value; }
    }

    // Methods
    public void NextBody(int nextAngle)
    {
        SpriteRenderer[] bodyReadySpriteRenderers = bodySpriteContainer.GetComponentsInChildren<SpriteRenderer>();
        Vector3 position = firePosition.transform.position;
        Load(nextAngle, bodyReadySpriteRenderers);
        currentAngle = nextAngle - 1;
        SavePosition(position, currentAngle);
    }

    public void PreviousBody(int previousAngle)
	{
		SpriteRenderer[] bodyReadySpriteRenderers = bodySpriteContainer.GetComponentsInChildren<SpriteRenderer>();
        Vector3 position = firePosition.transform.position;
        Load(previousAngle, bodyReadySpriteRenderers);
        currentAngle = previousAngle + 1;
        SavePosition(position, currentAngle);
    }

    public void Load(int angle)
    {
        SpriteRenderer[] bodyReadySpriteRenderers = bodySpriteContainer.GetComponentsInChildren<SpriteRenderer>();
        body.GetComponent<SpriteRenderer>().sprite = ChangeSprite(angle, bodyReadySpriteRenderers);
        LoadFirePosition(angle);
    }

    void Load(int angle, SpriteRenderer[] bodyReadySpriteRenderers)
    {
        body.GetComponent<SpriteRenderer>().sprite = ChangeSprite(angle, bodyReadySpriteRenderers);
        LoadFirePosition(angle);
    }
    
    private void SavePosition(Vector3 position, int angle)
    {
        if (firePositionsDic.ContainsKey(angle))
            firePositionsDic[angle] = position;
        else
            firePositionsDic.Add(angle, position);
    }

    void LoadFirePosition(int angle)
    {
        Vector3 position;
        if(firePositionsDic.ContainsKey(angle))
            position = firePositionsDic[angle];
        else
            position = firePosition.transform.position;
        firePosition.transform.position = position;
    }

	Sprite ChangeSprite(int directionAngle , SpriteRenderer[] spriteRenderers)
    {
        int spriteIndex = 0; 
        if (-180 <= directionAngle && directionAngle < -90)
            spriteIndex = directionAngle + 90 + 360; 
        if (-90 <= directionAngle && directionAngle <= 180)
            spriteIndex = directionAngle + 90;
        return spriteRenderers[spriteIndex].sprite;
    }

    public void InitializeFirePositions()
    {
        firePositionsDic = new Dictionary<int, Vector3>();
    }

    public void SaveData()
    {
        Vector3 newPosition;
        firePositionContainer.FirePositions = new List<Vector3>();
        foreach(int index in firePositionsDic.Keys)
        {
            newPosition = new Vector3(firePositionsDic[index].x, firePositionsDic[index].y, firePositionsDic[index].z);
            firePositionContainer.FirePositions.Add(newPosition);
        }
    }

    public void LoadData()
    {
        int angle;
        Vector3 position;
        firePositionsDic = new Dictionary<int, Vector3>();
        for(int index = 0; index < firePositionContainer.FirePositions.Count; index++)
        {
            angle = index - 180;
            position = firePositionContainer.FirePositions[index];
            firePositionsDic.Add(angle , position);
        }
    }
}




[CustomEditor(typeof(FirePositionGenerator))]
public class FirePositionGeneratorEditor : Editor {
    // Fields
    FirePositionGenerator script;

    // Methods
	public override void OnInspectorGUI()
    {
        script = target as FirePositionGenerator;
        base.DrawDefaultInspector();
        ShowLoadButton();
        ShowMoveButtons();
        ShowLoadDataButton();
        ShowSaveDataButton();
        ShowInitializeButton();
    }

    private void ShowLoadButton()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Just Load this angle :  " + script.Angle))
            script.Load(script.Angle);
        EditorGUILayout.EndHorizontal();
    }

    void ShowMoveButtons()
    {
		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("Save and Go Previous"))
			script.PreviousBody(--script.Angle);
		if(GUILayout.Button("Save and Go Next"))
			script.NextBody(++script.Angle);
		EditorGUILayout.EndHorizontal();
    }

    private void ShowLoadDataButton()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Load Position Datas from Container"))
            script.LoadData();
        EditorGUILayout.EndHorizontal();
    }

    private void ShowSaveDataButton()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save Position Datas to Container"))
            script.SaveData();
        EditorGUILayout.EndHorizontal();
    }

    void ShowInitializeButton()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("Assign New FirePositions"))
            script.InitializeFirePositions();
		EditorGUILayout.EndHorizontal();
    }
}
#endif