public class HeadReady : HeadState
{
    // Constructor
    public HeadReady()
    {
        this.InitializeSprites();
    }

    // Properties
    public override string StateName { get{ return "Head-Ready"; } }

    // Methods
    public override void UpdateSoldier()
    {

    }
}