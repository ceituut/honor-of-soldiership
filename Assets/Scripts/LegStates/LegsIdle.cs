public class LegsIdle : LegsState
{
    // Constructor
    public LegsIdle(SoldierSprite soldierSprite)
    {
        this.InitializeSprites(soldierSprite);
    }

    // Properties
    public override string StateName { get{ return "Legs-Idle"; } } 

    // Methods
    public override void UpdateSoldier()
    {

    }
}