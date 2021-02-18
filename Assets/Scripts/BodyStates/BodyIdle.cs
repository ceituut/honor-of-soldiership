public class BodyIdle : BodyState
{
    // Constructor
    public BodyIdle()
    {
        this.InitializeSprites();
    }

    // Properties
    public override string StateName { get{ return "Body-Idle"; } }

    // Methods
    public override void UpdateSoldier()
    {
    }
}