namespace KtKTestBed.OverlayControllerStuff;

public class PvPFrontlineInfoAdapter
{
    // -- These Values can probably be tied to plugin config
    public bool Visible { get; set;  } = true;
    public bool Movable { get; set;  } = true;
    // -- 
    public string ObjectiveState { get; set;  } = "Objective state"; // Long text needs special formatting
    public string ClockString { get; set;  } = "--:--";
    public int Animation { get; private set; } = 101;  //animations:     101,102,103,0,104,105,0  
    public int AnimationForResNode5 { get; private set;  } = 17; //animations: 17,0,101
    
    public uint IconForResNode5 { get; set;  } = 63985; 
    
    //resnode5 is only ever flashing or invisible

    public void SetToDefaultState()
    {
        SetToNeutral();
        HideIcon();
    }

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

    public void ShowIcon() // Objective currently in progress or pending
    {
        AnimationForResNode5 = 101;
    }
    
    public void HideIcon() //No objective currently in progress or pending
    {
        AnimationForResNode5 = 17; //identical to 0
    }
    
}