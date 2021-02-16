public class BodyIdle : BodyState
{
    // Constructor
    public BodyIdle(SoldierSprite soldierSprite)
    {
        this.InitializeSprites(soldierSprite);
    }

    // Properties
    public override string StateName { get{ return "Body-Idle"; } }

    // Methods
    public override void UpdateSoldier()
    {
    }
}