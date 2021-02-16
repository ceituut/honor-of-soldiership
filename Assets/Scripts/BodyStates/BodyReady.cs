public class BodyReady : BodyState
{
    // Constructor
    public BodyReady(SoldierSprite soldierSprite)
    {
        InitializeSprites(soldierSprite);
    }

    // Properties
    public override string StateName { get{ return "Body-Ready"; } }

    // Methods
    public override void UpdateSoldier()
    {
        throw new System.NotImplementedException();
    }
}