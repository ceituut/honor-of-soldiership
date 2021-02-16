public class HeadIdle : HeadState
{
    // Constructor
    public HeadIdle(SoldierSprite soldierSprite)
    {
        this.InitializeSprites(soldierSprite);
    }

    // Properties
    public override string StateName { get{ return "Head-Idle"; } }

    // Methods
    public override void UpdateSoldier()
    {

    }
}