using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	// Fields
	[SerializeField] private GameObject bullet;

	// Methods
	void Awake()
	{
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
			GameObject.Instantiate(bullet , transform.position , Quaternion.identity);
	}

	void FixedUpdate()
	{
	}
}
