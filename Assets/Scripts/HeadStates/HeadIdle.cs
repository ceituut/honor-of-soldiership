public class HeadIdle : HeadState
{
    // Constructor
    public HeadIdle()
    {
        this.InitializeSprites();
    }

    // Properties
    public override string StateName { get{ return "Head-Idle"; } }

    // Methods
    public override void UpdateSoldier()
    {

    }
}