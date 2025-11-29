using System.Numerics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Classes;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;
using KamiToolKit.Overlay;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSBattleLog: OverlayNode
{
    public override OverlayLayer OverlayLayer { get; } = OverlayLayer.Background;

    private static string _pvpHudMove = "ui/uld/PVPHudMove.tex"; 
    private static string _contentGauge = "ui/uld/ContentGauge.tex"; 

    private ResNode _unkResNode13 = null!;
    private ResNode _unkResNode14 = null!;
    private ResNode _unkResNode15 = null!;
    
    private NineGridNode _unkNineGridNode23 = null!;
    private NineGridNode _unkNineGridNode22 = null!;
    private NineGridNode _unkNineGridNode21 = null!;
    private NineGridNode _unkNineGridNode20 = null!;
    private NineGridNode _unkNineGridNode19 = null!;
    private NineGridNode _unkNineGridNode18 = null!;
    private NineGridNode _unkNineGridNode17 = null!;
    private NineGridNode _unkNineGridNode16 = null!;

    //collision node
    //collision node
    //rn13 <- rn14 <- rn15 <- 8 ninegrid nodes attached, all have offsets
    //6 base component nodes w/ 26 nodes (mostly image), all have offsets
    //rn2 <- textnode, rn4 <- ninegrid, image
    public PVPMKSBattleLog()
    {
        Size = new Vector2(384, 260);
        NodeId = 1;
        // construct objects
        // load timelines
        // attach nodes
    }

    private void ConstructNineGridNodes()
    {
        _unkNineGridNode23 = new NineGridNode
        {
            Position = new Vector2(0,0),
            Size = new Vector2(404,270),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            PartId = 0
        };
        _unkNineGridNode22 = new NineGridNode
        {
            Position = new Vector2(10,225),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };
        
        _unkNineGridNode21 = new NineGridNode
        {
            Position = new Vector2(10,183),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };
        _unkNineGridNode20 = new NineGridNode
        {
            Position = new Vector2(10,141),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };
        
        _unkNineGridNode19 = new NineGridNode
        {
            Position = new Vector2(10,99),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };
        
        _unkNineGridNode18 = new NineGridNode
        {
            Position = new Vector2(10,57),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };
        
        _unkNineGridNode17 = new NineGridNode
        {
            Position = new Vector2(10,25),
            Size = new Vector2(384,32),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0.498f),
            PartId = 0,
            Offsets = new Vector4(8f,8f,16f,16f)
        };
        
        _unkNineGridNode16 = new NineGridNode
        {
            Position = new Vector2(20,12),
            Size = new Vector2(384,10),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            PartId = 1,
            Offsets = new Vector4(0f,0f,2f,2f)
        };
    }

    private unsafe void AddPartsToNinegridNodes()
    {
        var pvpHudMovePart0 = new Part
        {
            Id = 0,
            TexturePath = _pvpHudMove,
            Size = new Vector2(32,32),
            TextureCoordinates = new Vector2(0,0)
        };
        var pvpHudMovePart1 = new Part
        {
            Id = 1,
            TexturePath = _pvpHudMove,
            Size = new Vector2(6,10),
            TextureCoordinates = new Vector2(32,0)
        };
        
        var contentGauge0 = new Part
        {
            Id = 0,
            TexturePath = _contentGauge,
            Size = new Vector2(42,20),
            TextureCoordinates = new Vector2(0,82)
        };
        
        
        
        _unkNineGridNode23.AddPart(pvpHudMovePart0);
        _unkNineGridNode23.AddPart(pvpHudMovePart1);
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode22);
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode21);
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode20);
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode19);
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode18);
        
        _unkNineGridNode17.AddPart(contentGauge0);
        _unkNineGridNode16.AddPart(pvpHudMovePart0);
        _unkNineGridNode16.AddPart(pvpHudMovePart1);
    }

    private void ConstructResNodes()
    {
        _unkResNode13 = new ResNode
        {
            Position = new Vector2(-10,-5),
            Size = new Vector2(404, 270),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents
        };
        _unkResNode14 = new ResNode
        {
            Position = new Vector2(0,0),
            Size = new Vector2(404, 270),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Scale = new Vector2(-1, 1)
        };
        
        _unkResNode15 = new ResNode
        {
            Position = new Vector2(0,0),
            Size = new Vector2(404, 270),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
    }

    private void ConstructNineGridNodeTimelines()
    {
        var emptyTimeline = new TimelineBuilder()
            .BeginFrameSet(11, 20)
            .AddEmptyFrame(11)
            .EndFrameSet()
            .Build();
        
        _unkNineGridNode23.AddTimeline(emptyTimeline);
        _unkNineGridNode22.AddTimeline(emptyTimeline);
        _unkNineGridNode21.AddTimeline(emptyTimeline);
        _unkNineGridNode20.AddTimeline(emptyTimeline);
        _unkNineGridNode19.AddTimeline(emptyTimeline);
        _unkNineGridNode18.AddTimeline(emptyTimeline);
        _unkNineGridNode17.AddTimeline(emptyTimeline);
        _unkNineGridNode16.AddTimeline(emptyTimeline);

    }

    private void ConstructTimelines()
    {
        _unkResNode13.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 20)
                .AddLabel(1, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .Build());
        _unkResNode14.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 40)
                .AddLabel(1, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(10, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 102, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(20, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(21, 103, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(30, 0, AtkTimelineJumpBehavior.LoopForever, 102)
                .AddLabel(31, 4, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(40, 0, AtkTimelineJumpBehavior.LoopForever, 101)
                .EndFrameSet()
                .BeginFrameSet(1, 10)
                .AddFrame(1, position: new Vector2(0,0))
                .AddFrame(1, scale: new Vector2(-1, 1))
                .EndFrameSet()
                .BeginFrameSet(11, 20)
                .AddFrame(11, position: new Vector2(0,0))
                .AddFrame(11, scale: new Vector2(-1, 1))
                .EndFrameSet()
                .Build());
        
        _unkResNode15.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 20)
                .AddLabel(1, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .BeginFrameSet(1, 10)
                .AddFrame(1, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(11, 20)
                .AddFrame(11, alpha: 127)
                .EndFrameSet()
                .BeginFrameSet(21, 30)
                .AddFrame(21, alpha: 255)
                .AddFrame(24, alpha: 127)
                .EndFrameSet()
                .BeginFrameSet(31, 40)
                .AddFrame(31, alpha: 127)
                .AddFrame(34, alpha: 255)
                .EndFrameSet()
                .Build());
    }

    private void BuildRootTimeline()
    {
        AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 120)
                .AddLabel(1, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(120, 102, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .Build()
            );
    }
}