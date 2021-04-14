using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public abstract class HeadState
{
    // Fields
    public static Dictionary<string,HeadState> headList;
    private static readonly int startIndexOfSprites = 1;
    private static readonly int endIndexOfSprites = 181;
    protected Sprite[] headSpriteList;

    // Properties
    public abstract string StateName { get;}

    // Methods
    public static void InitializeHeadList()
    {
        var headTypes = Assembly.GetAssembly(typeof(HeadState)).GetTypes().Where(thisHeadState => typeof(HeadState).IsAssignableFrom(thisHeadState) && thisHeadState.IsAbstract == false);
        headList = new Dictionary<string, HeadState>();
        foreach(var thisHeadType in headTypes)
        {
            HeadState newHeadState = System.Activator.CreateInstance(thisHeadType) as HeadState;
            headList.Add(newHeadState.StateName,newHeadState);
        }
    }

    public abstract void UpdateSoldier();

    protected void InitializeSprites()
    {
        headSpriteList = new Sprite[endIndexOfSprites - startIndexOfSprites + 1];
        for(int spriteIndex = startIndexOfSprites; spriteIndex <= endIndexOfSprites; spriteIndex++)
            headSpriteList[spriteIndex - 1] = SpriteManager.Instance.spriteAtlas.GetSprite(StateName + spriteIndex);
    }
    
    public void ChangeSprite(int directionAngle , SoldierSprite soldierSprite)
    {
        int spriteIndex = 0; 
        if (-90 < directionAngle && directionAngle <= 90)
        {
            if (soldierSprite.HeadSpriteRenderer.flipX)
                soldierSprite.HeadSpriteRenderer.flipX = false;
            spriteIndex = directionAngle + 90;
        }
        if (90 < directionAngle && directionAngle <= 180)
        {
            soldierSprite.HeadSpriteRenderer.flipX = true;
            spriteIndex = 270 - directionAngle;
        }
        if (-180 <= directionAngle && directionAngle <= -90)
        {
            soldierSprite.HeadSpriteRenderer.flipX = true;
            spriteIndex = -(directionAngle + 90);
        }
        soldierSprite.HeadSpriteRenderer.sprite = headSpriteList[spriteIndex];
    }
}