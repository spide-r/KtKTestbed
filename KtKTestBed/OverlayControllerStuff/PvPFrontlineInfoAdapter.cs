namespace KtKTestBed.OverlayControllerStuff;

public class PvPFrontlineInfoAdapter
{
    public string ObjectiveState = "Objective state";
    public string ClockString = "00:00";
    public bool Visible = true;
    public bool Movable = true;
    public int Animation = 0;     //animations:     101,102,103,0,104,105,0  
    public int AnimationForResNode5 = 0; //animations: 17,0,101
    
    //resnode5 is only ever flashing or invisible

    public void SetToNeutral() // Start of Match
    {
        Animation = 101;
    }

    public void FlashRedThrobRed() // Objective Countdown has gotten close
    {
        Animation = 102;
    }

    public void TurnRedThrobRed() // Objective countdown has gotten to the hot zone
    {
        Animation = 103; // identical to 0
    }

    public void TurnOrangeThrobRed() // Objective is currently active
    {
        Animation = 104;
    }

    public void ShowResNode() // Objective currently in progress or pending
    {
        AnimationForResNode5 = 101;
    }
    
    public void HideResNode5() //No objective currently in progress or pending
    {
        AnimationForResNode5 = 17; //identical to 0
    }
    
}