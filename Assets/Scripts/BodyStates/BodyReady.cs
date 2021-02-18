public class BodyReady : BodyState
{
    // Constructor
    public BodyReady()
    {
        InitializeSprites();
    }

    // Properties
    public override string StateName { get{ return "Body-Ready"; } }

    // Methods
    public override void UpdateSoldier()
    {
        throw new System.NotImplementedException();
    }
}