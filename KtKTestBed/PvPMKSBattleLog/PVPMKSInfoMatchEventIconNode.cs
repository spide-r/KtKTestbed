using System.Numerics;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSInfoMatchEventIconNode : ResNode
{
    //this icon is shown during each match event log, 1 at the start and one offset to the end 
    private ImageNode _matchEventBackgroundImageNode4 = null!;
    private ImageNode _matchEventBackgroundImageNode3 = null!;
    
    
    private ResNode _matchEventKillNode2 = null!;
    
    private ResNode _matchEventKillResNode4 = null!;
    private ResNode _matchEventKillResNode2 = null!;
    private ImageNode _matchEventJobBorderNode5 = null!;
    private ImageNode _matchEventJobIconNode3 = null!;
    public PVPMKSInfoMatchEventIconNode(Vector2 pos)
    {
        Size = new Vector2(40, 40);
        Position = pos;
        //todo construct all nodes, attach all icons, add all timelines
    }

    public void ConstructTimeline()
    {
        AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, position: new Vector2(-20,0))
                .AddFrame(15, position: new Vector2(0,0))
                .AddFrame(10, alpha: 0)
                .AddFrame(15, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, position: new Vector2(0,0))
                .AddFrame(26, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(56, 70)
                .AddFrame(56, position: new Vector2(0,0))
                .AddFrame(61, position: new Vector2(0,0))
                .AddFrame(56, alpha: 0)
                .AddFrame(61, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(71, 119)
                .AddFrame(71, position: new Vector2(0,0))
                .AddFrame(71, alpha: 255)
                .EndFrameSet()
                .Build());
    }
}