using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public abstract class LegsState
{
    // Fields
    public static Dictionary<string,LegsState> legsList;
    private static readonly int startIndexOfSprites = 1;
    private static readonly int endIndexOfSprites = 181;
    protected Sprite[] legsSpriteList;

    // Properties
    public abstract string StateName { get;}

    // Methods
    public static void InitializelegsList()
    {
        var legsTypes = Assembly.GetAssembly(typeof(LegsState)).GetTypes().Where(thisLegsState => typeof(LegsState).IsAssignableFrom(thisLegsState) && thisLegsState.IsAbstract == false);
        legsList = new Dictionary<string, LegsState>();
        foreach(var thisLegsType in legsTypes)
        {
            LegsState newLegsState = System.Activator.CreateInstance(thisLegsType) as LegsState;
            legsList.Add(newLegsState.StateName,newLegsState);
        }
    }

    public abstract void UpdateSoldier();

    protected void InitializeSprites()
    {
        legsSpriteList = new Sprite[endIndexOfSprites - startIndexOfSprites + 1];
        for(int spriteIndex = startIndexOfSprites; spriteIndex <= endIndexOfSprites; spriteIndex++)
            legsSpriteList[spriteIndex - 1] = SpriteManager.Instance.spriteAtlas.GetSprite(StateName + spriteIndex);
    }
    
    public void ChangeSprite(int directionAngle , SoldierSprite soldierSprite)
    {
        int spriteIndex = 0; 
        if (-90 < directionAngle && directionAngle <= 90)
        {
            if (soldierSprite.LegsSpriteRenderer.flipX)
                soldierSprite.LegsSpriteRenderer.flipX = false;
            spriteIndex = directionAngle + 90;
        }
        if (90 < directionAngle && directionAngle <= 180)
        {
            soldierSprite.LegsSpriteRenderer.flipX = true;
            spriteIndex = 270 - directionAngle;
        }
        if (-180 <= directionAngle && directionAngle <= -90)
        {
            soldierSprite.LegsSpriteRenderer.flipX = true;
            spriteIndex = -(directionAngle + 90);
        }
        soldierSprite.LegsSpriteRenderer.sprite = legsSpriteList[spriteIndex];
    }
}