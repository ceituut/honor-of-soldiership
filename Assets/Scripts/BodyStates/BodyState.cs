using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public abstract class BodyState
{
    // Fields
    public static Dictionary<string,BodyState> bodyList;
    private static readonly int startIndexOfSprites = 1;
    private static readonly int endIndexOfSprites = 361;
    protected Sprite[] bodySpriteList;

    // Properties
    public abstract string StateName { get;}

    // Methods
    public static void InitializeBodyList()
    {
        var bodyTypes = Assembly.GetAssembly(typeof(BodyState)).GetTypes().Where(thisBodyState => typeof(BodyState).IsAssignableFrom(thisBodyState) && thisBodyState.IsAbstract == false);
        bodyList = new Dictionary<string, BodyState>();
        foreach(var thisBodyType in bodyTypes)
        {
            BodyState newBodyState = System.Activator.CreateInstance(thisBodyType) as BodyState;
            bodyList.Add(newBodyState.StateName,newBodyState);
        }
    }
    public abstract void UpdateSoldier();
    protected void InitializeSprites()
    {
        bodySpriteList = new Sprite[endIndexOfSprites - startIndexOfSprites + 1];
        for(int spriteIndex = startIndexOfSprites; spriteIndex <= endIndexOfSprites; spriteIndex++)
            bodySpriteList[spriteIndex - 1] = SpriteManager.Instance.spriteAtlas.GetSprite(StateName + spriteIndex);
    }
    public void ChangeSprite(int directionAngle , SoldierSprite soldierSprite)
    {
        int spriteIndex = 0; 
        if (-180 <= directionAngle && directionAngle < -90)
            spriteIndex = directionAngle + 90 + 360; 
        if (-90 <= directionAngle && directionAngle <= 180)
            spriteIndex = directionAngle + 90;
        soldierSprite.BodySpriteRenderer.sprite = bodySpriteList[spriteIndex];
    }
}