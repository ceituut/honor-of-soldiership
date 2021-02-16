using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	// Fields
	private float horizontal;
	private float vertical;
	private Vector2 moveVector;
	[SerializeField] private float speed;
	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private Animator legsAnimator;
	[SerializeField] private Direction direction;
	private AnimateLegs animateLegs;

	// Methods
	void Awake()
	{
		animateLegs = new AnimateLegs();
	}
	
	void Update () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		moveVector = new Vector2(horizontal,vertical);
	}

	void FixedUpdate()
	{
		rigidBody.velocity = moveVector.normalized * speed;
	}

	void LateUpdate()
	{
		animateLegs.WalkAnimationSpeed += 0.2f;
		animateLegs.Animate(moveVector , legsAnimator , direction);
	}
}
