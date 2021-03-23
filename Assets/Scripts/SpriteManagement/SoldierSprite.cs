using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoldierSprite : MonoBehaviour {
    // Fields
	[SerializeField] private Direction direction;
    [SerializeField] private SpriteManager spriteManager;
	[SerializeField] private SpriteRenderer headSpriteRenderer;
	[SerializeField] private SpriteRenderer bodySpriteRenderer;
	[SerializeField] private SpriteRenderer legsSpriteRenderer;
    private HeadState headState;
    private BodyState bodyState;
    private LegsState legsState;

    // Properties
    public SpriteRenderer HeadSpriteRenderer {
        get { return headSpriteRenderer; }
    }

    public SpriteRenderer BodySpriteRenderer
    {
        get { return bodySpriteRenderer; }
    }

    public SpriteRenderer LegsSpriteRenderer
    {
        get { return legsSpriteRenderer; }
    }

    // Methods
    static void InitilizeStates()
    {
        HeadState.InitializeHeadList();
        BodyState.InitializeBodyList();
        LegsState.InitializelegsList();
    }

    void Start ()
    {
        SoldierSprite.InitilizeStates();
        SetIdelStates();
        Fire.OnFire += OnFireChangeSprite;
    }

    void SetIdelStates()
    {
        headState = HeadState.headList["Head-Idle"];
        bodyState = BodyState.bodyList["Body-Idle"];
        legsState = LegsState.legsList["Legs-Idle"];
    }

    void Update () {
		ChangeSprite(direction.GetAngle);
	}

	void ChangeSprite(int directionAngle)
	{
        bodyState.ChangeSprite(directionAngle , this);
        headState.ChangeSprite(directionAngle , this);
        legsState.ChangeSprite(directionAngle , this);
	}

    void OnFireChangeSprite()
    {
        headState = HeadState.headList["Head-Ready"];
        bodyState = BodyState.bodyList["Body-Ready"];
        StopCoroutine("AfterFireChangeSprite");
        StartCoroutine("AfterFireChangeSprite");
    }

    IEnumerator AfterFireChangeSprite()
    {
        yield return new WaitForSeconds(2.5f);
        SetIdelStates();
    }
}
