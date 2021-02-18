public class LegsIdle : LegsState
{
    // Constructor
    public LegsIdle()
    {
        this.InitializeSprites();
    }

    // Properties
    public override string StateName { get{ return "Legs-Idle"; } } 

    // Methods
    public override void UpdateSoldier()
    {

    }
}