using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	// Fields
	public static event Action OnFire;
	[SerializeField] private GameObject bullet;
	[SerializeField] private FirePositionContainer firePositionContainer;
	private SpriteRenderer bulletSpriteRenderer;
	private Direction direction;
	private bool isFired;
	private int soldierSpriteInitialSortingOrder;
	[SerializeField] private float fireRate;

	// Properties
	private Vector2 GetFirePosition { 
		get {
			int angle = direction.GetAngle;
			return firePositionContainer.GetPosition(angle) + transform.position; 
		} 
	}

	// Methods
	void Awake()
	{
		direction = GetComponent<Direction>();
		soldierSpriteInitialSortingOrder = GetComponent<SoldierSprite>().HeadSpriteRenderer.sortingOrder;
		bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        isFired = Input.GetKeyDown(KeyCode.Mouse0);
	}

	void FixedUpdate()
	{
        if (isFired)
			FireBasedOnDirection();
	}

	void FireBasedOnDirection()
	{
		GameObject curretnBullet = GameObject.Instantiate(bullet , GetFirePosition , Quaternion.identity) as GameObject;
		curretnBullet.transform.SetParent(transform);
		Vector2 bulletVelocity = Quaternion.Euler(0, 0, direction.GetAngle) * curretnBullet.transform.right;
		curretnBullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity * fireRate;
		SetBulletSpriteOrder();
		if(OnFire != null)
			OnFire();
	}

	void SetBulletSpriteOrder()
	{
		if(0 <= direction.GetAngle && direction.GetAngle <= 180)
			bulletSpriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder - 1;
		else
			bulletSpriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder + 1;
	}
}
