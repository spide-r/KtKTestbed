using System.Numerics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Classes;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSInfoMatchEventIconNode : ResNode
{
    //this icon is shown during each match event log, 1 at the start and one offset to the end 
    private ImageNode _matchEventBackgroundImageNode4 = null!;
    private ImageNode _matchEventBackgroundImageNode3 = null!;
    
    
    private ResNode _matchEventKillNode2 = null!; //basecomponent
    
    private ResNode _matchEventKillChildResNode4 = null!;
    private ResNode _matchEventKillChildResNode2 = null!;
    private ImageNode _matchEventJobBorderNode5 = null!;
    private ImageNode _matchEventJobIconNode3 = null!;
    
    //todo: expose playing animation maybe
    public PVPMKSInfoMatchEventIconNode(Vector2 pos)
    {
        Size = new Vector2(40, 40);
        Position = pos;
        NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents;
        ConstructAndLoadImageNodes();
        ConstructResNodes();
        ConstructTimeline();
        AttachNodes();
    }

    public void SetJob(uint border, uint job)
    {
        _matchEventJobBorderNode5.PartId = border;
        _matchEventJobIconNode3.PartId = job;
    }

    public void SetBackgroundImage4(uint part)
    {
        _matchEventBackgroundImageNode4.PartId = part;
    }

    public void SetBackgroundImage3(uint part)
    {
        _matchEventBackgroundImageNode3.PartId = part;
    }

    public void AttachNodes()
    {
        _matchEventBackgroundImageNode4.AttachNode(this);
        _matchEventBackgroundImageNode3.AttachNode(this);
        _matchEventKillNode2.AttachNode(this);
        
        _matchEventKillChildResNode4.AttachNode(_matchEventKillNode2);
        _matchEventJobBorderNode5.AttachNode(_matchEventKillChildResNode4);
        _matchEventKillChildResNode2.AttachNode(_matchEventKillNode2);
        _matchEventJobIconNode3.AttachNode(_matchEventKillChildResNode2);
        
        
    }

    public void ConstructResNodes()
    {
        _matchEventKillNode2 = new ResNode
        {
            Position = new Vector2(7,7),
            Size = new Vector2(26, 26), 
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | 
                        NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
        _matchEventKillChildResNode4 = new ResNode
        {
            Size = new Vector2(32,32),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | 
                        NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
        _matchEventKillChildResNode2 = new ResNode
        {
            Size = new Vector2(26, 26),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible |
                        NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
    }

    public void ConstructAndLoadImageNodes()
    {
        _matchEventBackgroundImageNode4 = new ImageNode
        {
            Size = new Vector2(40,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible 
                        | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            PartId = 1
        };
        _matchEventBackgroundImageNode3 = new ImageNode
        {
            Size = new Vector2(40,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible 
                        | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            PartId = 5
        };

        //7, 8, 9 are Blue, Green, Red bordered
        _matchEventJobBorderNode5 = new ImageNode
        {
            Size = new Vector2(26, 26),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible
                        | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            PartId = 7,
        };
        
        _matchEventJobIconNode3 = new ImageNode
        {
            Position = new Vector2(2,2),
            Size = new Vector2(26, 26),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible
                        | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            PartId = 0,
        };
        PVPMKSInfoTextureHelper.LoadPvPMKSInfo(_matchEventBackgroundImageNode4);
        PVPMKSInfoTextureHelper.LoadPvPMKSInfo(_matchEventBackgroundImageNode3);
        PVPMKSInfoTextureHelper.LoadPvPMKSInfo(_matchEventJobBorderNode5);
        PVPMKSInfoTextureHelper.LoadPvPClassJobIcon(_matchEventJobIconNode3);
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
        _matchEventBackgroundImageNode4.AddTimeline(new TimelineBuilder()
		        .BeginFrameSet(51, 60)
		        .AddFrame(51, partId: 1)
		        .EndFrameSet()
		        .BeginFrameSet(61, 70)
		        .AddFrame(61, partId: 0)
		        .EndFrameSet()
		        .Build());
        _matchEventBackgroundImageNode3.AddTimeline(new TimelineBuilder()
		        .BeginFrameSet(1, 10)
		        .AddFrame(1, partId: 5)
		        .EndFrameSet()
		        .BeginFrameSet(11, 20)
		        .AddFrame(11, partId: 4)
		        .EndFrameSet()
		        .BeginFrameSet(21, 30)
		        .AddFrame(21, partId: 6)
		        .EndFrameSet()
		        .BeginFrameSet(31, 40)
		        .AddFrame(31, partId: 3)
		        .EndFrameSet()
		        .BeginFrameSet(41, 50)
		        .AddFrame(41, partId: 2)
		        .EndFrameSet()
		        .BeginFrameSet(71, 80)
		        .AddFrame(71, partId: 10)
		        .EndFrameSet()
		        .BeginFrameSet(81, 90)
		        .AddFrame(81, partId: 11)
		        .EndFrameSet()
		        .BeginFrameSet(91, 100)
		        .AddFrame(91, partId: 12)
		        .EndFrameSet()
		        .Build());
        _matchEventKillNode2.AddTimeline(new TimelineBuilder()
		        .BeginFrameSet(51, 60)
		        .AddEmptyFrame(51)
		        .EndFrameSet()
		        .BeginFrameSet(61, 70)
		        .AddEmptyFrame(61)
		        .EndFrameSet()
		        .Build());
        _matchEventKillChildResNode4.AddTimeline(new TimelineBuilder()
		        .BeginFrameSet(1, 30)
		        .AddLabel(1, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
		        .AddLabel(11, 102, AtkTimelineJumpBehavior.PlayOnce, 0)
		        .AddLabel(21, 103, AtkTimelineJumpBehavior.PlayOnce, 0)
		        .EndFrameSet()
		        .Build());
        _matchEventJobBorderNode5.AddTimeline(new TimelineBuilder()
		        .BeginFrameSet(1, 10)
		        .AddFrame(1, partId: 7)
		        .EndFrameSet()
		        .BeginFrameSet(11, 20)
		        .AddFrame(11, partId: 8)
		        .EndFrameSet()
		        .BeginFrameSet(21, 30)
		        .AddFrame(21, partId: 9)
		        .EndFrameSet()
		        .Build());
        _matchEventKillChildResNode2.AddTimeline(new TimelineBuilder()
	.BeginFrameSet(1, 430)
		.AddLabel(1, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(11, 102, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(21, 103, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(31, 104, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(41, 105, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(51, 106, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(61, 107, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(71, 108, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(81, 109, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(91, 110, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(101, 111, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(111, 112, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(121, 113, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(131, 114, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(141, 115, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(151, 116, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(161, 117, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(171, 118, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(181, 119, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(191, 120, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(201, 121, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(211, 122, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(221, 123, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(231, 124, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(241, 125, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(251, 126, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(261, 127, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(271, 128, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(281, 129, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(291, 130, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(301, 131, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(311, 132, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(321, 133, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(331, 134, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(341, 135, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(351, 136, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(361, 137, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(371, 138, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(381, 139, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(391, 140, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(401, 141, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(411, 142, AtkTimelineJumpBehavior.PlayOnce, 0)
		.AddLabel(421, 143, AtkTimelineJumpBehavior.PlayOnce, 0)
	.EndFrameSet()
	.Build());
        _matchEventJobIconNode3.AddTimeline(
            new TimelineBuilder()
	.BeginFrameSet(1, 10)
		.AddFrame(1, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(11, 20)
		.AddFrame(11, partId: 1)
	.EndFrameSet()
	.BeginFrameSet(21, 30)
		.AddFrame(21, partId: 2)
	.EndFrameSet()
	.BeginFrameSet(31, 40)
		.AddFrame(31, partId: 3)
	.EndFrameSet()
	.BeginFrameSet(41, 50)
		.AddFrame(41, partId: 4)
	.EndFrameSet()
	.BeginFrameSet(51, 60)
		.AddFrame(51, partId: 5)
	.EndFrameSet()
	.BeginFrameSet(61, 70)
		.AddFrame(61, partId: 6)
	.EndFrameSet()
	.BeginFrameSet(71, 80)
		.AddFrame(71, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(81, 90)
		.AddFrame(81, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(91, 100)
		.AddFrame(91, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(101, 110)
		.AddFrame(101, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(111, 120)
		.AddFrame(111, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(121, 130)
		.AddFrame(121, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(131, 140)
		.AddFrame(131, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(141, 150)
		.AddFrame(141, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(151, 160)
		.AddFrame(151, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(161, 170)
		.AddFrame(161, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(171, 180)
		.AddFrame(171, partId: 0)
	.EndFrameSet()
	.BeginFrameSet(181, 190)
		.AddFrame(181, partId: 7)
	.EndFrameSet()
	.BeginFrameSet(191, 200)
		.AddFrame(191, partId: 8)
	.EndFrameSet()
	.BeginFrameSet(201, 210)
		.AddFrame(201, partId: 9)
	.EndFrameSet()
	.BeginFrameSet(211, 220)
		.AddFrame(211, partId: 10)
	.EndFrameSet()
	.BeginFrameSet(221, 230)
		.AddFrame(221, partId: 11)
	.EndFrameSet()
	.BeginFrameSet(231, 240)
		.AddFrame(231, partId: 12)
	.EndFrameSet()
	.BeginFrameSet(241, 250)
		.AddFrame(241, partId: 13)
	.EndFrameSet()
	.BeginFrameSet(251, 260)
		.AddFrame(251, partId: 14)
	.EndFrameSet()
	.BeginFrameSet(261, 270)
		.AddFrame(261, partId: 15)
	.EndFrameSet()
	.BeginFrameSet(271, 280)
		.AddFrame(271, partId: 16)
	.EndFrameSet()
	.BeginFrameSet(281, 290)
		.AddFrame(281, partId: 17)
	.EndFrameSet()
	.BeginFrameSet(291, 300)
		.AddFrame(291, partId: 18)
	.EndFrameSet()
	.BeginFrameSet(301, 310)
		.AddFrame(301, partId: 19)
	.EndFrameSet()
	.BeginFrameSet(311, 320)
		.AddFrame(311, partId: 20)
	.EndFrameSet()
	.BeginFrameSet(321, 330)
		.AddFrame(321, partId: 21)
	.EndFrameSet()
	.BeginFrameSet(331, 340)
		.AddFrame(331, partId: 22)
	.EndFrameSet()
	.BeginFrameSet(341, 350)
		.AddFrame(341, partId: 23)
	.EndFrameSet()
	.BeginFrameSet(351, 360)
		.AddFrame(351, partId: 24)
	.EndFrameSet()
	.BeginFrameSet(361, 370)
		.AddFrame(361, partId: 25)
	.EndFrameSet()
	.BeginFrameSet(371, 380)
		.AddFrame(371, partId: 26)
	.EndFrameSet()
	.BeginFrameSet(381, 390)
		.AddFrame(381, partId: 27)
	.EndFrameSet()
	.BeginFrameSet(391, 400)
		.AddFrame(391, partId: 28)
	.EndFrameSet()
	.BeginFrameSet(401, 410)
		.AddFrame(401, partId: 29)
	.EndFrameSet()
	.BeginFrameSet(411, 420)
		.AddFrame(411, partId: 30)
	.EndFrameSet()
	.Build());
    }
}