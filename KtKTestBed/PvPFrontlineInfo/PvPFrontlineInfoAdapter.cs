using System.Numerics;

namespace KtKTestBed.OverlayControllerStuff;

public class PvPFrontlineInfoAdapter
{
    //todo: we probably still need to save the position somewhere since the UI elements arent always displayed/drawn 
    // user could be in a non-pvp zone but wish to edit where the icon is / view it
    // maybe make a toggle?
    public bool Visible { get; set;  } = true; // this value could probably be tied to a plugin config / plugin state
    public string ObjectiveState { get; set;  } = "Small Ice"; // Long text needs special formatting
    public string ClockString { get; set;  } = "00:27";
    public int Animation { get; private set; } = 101;  //animations:     101,102,103,0,104,105,0  
    public int AnimationForResNode5 { get; private set;  } = 17; //animations: 17,0,101
    
    public uint IconForResNode5 { get; set;  } = 60904; 
    
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