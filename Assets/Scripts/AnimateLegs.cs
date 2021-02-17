using UnityEngine;

public class AnimateLegs {
	// Fields
	private bool isUpMoving , isDownMoving , isRightMoving , isLeftMoving , isDirectionUp , isDirectionDown , isDirectionRight , isDirectionLeft;
	private float walkAnimationSpeed;

	// Properties
    public float WalkAnimationSpeed
    {
        get { return walkAnimationSpeed; }
        set { 
			if(value > 1) 
				value = 1 ;
			walkAnimationSpeed = value; 
		}
    }

	// Constructor
	public AnimateLegs()
	{
		walkAnimationSpeed = 0f;
	}
	
    // Methods
	bool isMoving(Vector2 moveVector)
	{
		return moveVector.normalized.magnitude != 0;
	}
	void SetMovingAndDirectionConditions(Vector2 moveVector , Direction direction)
	{
		isUpMoving = moveVector.y > 0 && moveVector.x == 0;
		isDownMoving = moveVector.y < 0 && moveVector.x == 0;
		isRightMoving = moveVector.y == 0 && moveVector.x > 0;
		isLeftMoving = moveVector.y == 0 && moveVector.x < 0;
		isDirectionUp = 0 <= direction.GetDirectionAngle && direction.GetDirectionAngle <= 180;
		isDirectionDown = -180 <= direction.GetDirectionAngle && direction.GetDirectionAngle < 0;
		isDirectionRight = -90 <= direction.GetDirectionAngle && direction.GetDirectionAngle <= 90;
		isDirectionLeft = (90 <= direction.GetDirectionAngle && direction.GetDirectionAngle <= 180) || (-180 <= direction.GetDirectionAngle && direction.GetDirectionAngle <= -90);
	}
	public void Animate(Vector2 moveVector , Animator legsAnimator , Direction direction)
	{
		if(isMoving(moveVector))
        {
            SetMovingAndDirectionConditions(moveVector, direction);
            legsAnimator.enabled = true;
            AnimateBasedOnMovingInOneDirection(moveVector, legsAnimator, direction);
        }
        else
			legsAnimator.enabled = false;
	}

    private void AnimateBasedOnMovingInOneDirection(Vector2 moveVector, Animator legsAnimator, Direction direction)
    {
        if (isUpMoving && isDirectionUp)
            PlayLegsAnimation(legsAnimator, "OnWalkBack", true);
        else if (isUpMoving && isDirectionDown)
            PlayLegsAnimation(legsAnimator, "OnWalkFront", false);
        else if (isDownMoving && isDirectionUp)
            PlayLegsAnimation(legsAnimator, "OnWalkBack", false);
        else if (isDownMoving && isDirectionDown)
            PlayLegsAnimation(legsAnimator, "OnWalkFront", true); ////////// horizontal :
        else if (isRightMoving && isDirectionRight)
            PlayLegsAnimation(legsAnimator, "OnWalkRight", true);
        else if (isRightMoving && isDirectionLeft)
            PlayLegsAnimation(legsAnimator, "OnWalkLeft", false);
        else if (isLeftMoving && isDirectionRight)
            PlayLegsAnimation(legsAnimator, "OnWalkRight", false);
        else if (isLeftMoving && isDirectionLeft)
            PlayLegsAnimation(legsAnimator, "OnWalkLeft", true);
        else
            AnimateBasedOnCursorDirection(moveVector, legsAnimator, direction);
    }

    private void AnimateBasedOnCursorDirection(Vector2 moveVector, Animator legsAnimator, Direction direction)
    {
        if (-25 <= direction.GetDirectionAngle && direction.GetDirectionAngle <= 25)
            PlayLegsAnimation(legsAnimator, "OnWalkRight", moveVector.x > 0);
        if (25 < direction.GetDirectionAngle && direction.GetDirectionAngle <= 155)
            PlayLegsAnimation(legsAnimator, "OnWalkBack", moveVector.y > 0);
        if (155 < direction.GetDirectionAngle && direction.GetDirectionAngle <= 180 || -180 <= direction.GetDirectionAngle && direction.GetDirectionAngle < -155)
            PlayLegsAnimation(legsAnimator, "OnWalkLeft", moveVector.x < 0);
        if (-155 <= direction.GetDirectionAngle && direction.GetDirectionAngle < -25)
            PlayLegsAnimation(legsAnimator, "OnWalkFront", moveVector.y < 0);
    }

    void PlayLegsAnimation(Animator legsAnimator , string triggerName , bool isForwardAnimation)
	{
		if(isForwardAnimation)
			legsAnimator.SetFloat("walkSpeed" , Mathf.Abs(walkAnimationSpeed));
		else
			legsAnimator.SetFloat("walkSpeed" , -Mathf.Abs(walkAnimationSpeed));
		ResetAllTriggers(legsAnimator);
		legsAnimator.SetTrigger(triggerName);	
	}

	void ResetAllTriggers(Animator legsAnimator)
	{
		legsAnimator.ResetTrigger("OnWalkFront");
		legsAnimator.ResetTrigger("OnWalkBack");
		legsAnimator.ResetTrigger("OnWalkRight");
		legsAnimator.ResetTrigger("OnWalkLeft");
	}
}
