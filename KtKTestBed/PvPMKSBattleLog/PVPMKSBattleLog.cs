using System.Numerics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Classes;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;
using KamiToolKit.Overlay;

namespace KtKTestBed.PvPMKSBattleLog;

public class PVPMKSBattleLog: OverlayNode
{
    //todo we may have to manually expose methods to trigger animations in each node
    public override OverlayLayer OverlayLayer { get; } = OverlayLayer.Background;

    private static string _pvpHudMove = "ui/uld/PVPHudMove.tex"; 
    private static string _contentGauge = "ui/uld/ContentGauge.tex"; 

    private ResNode _unkResNode13 = null!;
    private ResNode _unkResNode14 = null!;
    private ResNode _unkResNode15 = null!;
    
    private ResNode _unkResNode2 = null!;
    private TextNode _unkTextNode3 = null!;
    private ResNode _unkResNode4 = null!;
    private NineGridNode _unkNineGridNode6 = null!;
    private ImageNode _unkImageNode5 = null!;
    
    private NineGridNode _unkNineGridNode23 = null!;
    private NineGridNode _unkNineGridNode22 = null!;
    private NineGridNode _unkNineGridNode21 = null!;
    private NineGridNode _unkNineGridNode20 = null!;
    private NineGridNode _unkNineGridNode19 = null!;
    private NineGridNode _unkNineGridNode18 = null!;
    private NineGridNode _unkNineGridNode17 = null!;
    private NineGridNode _unkNineGridNode16 = null!;
    
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode12 = null!;
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode11 = null!;
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode10 = null!;
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode9 = null!;
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode8 = null!;
    private PvPMKSMatchEventComponentNode _pvPmksMatchEventComponentNode7 = null!;

    //collision node
    //collision node
    //rn13 <- rn14 <- rn15 <- 8 ninegrid nodes attached, all have offsets
    //6 base component nodes w/ 26 nodes (mostly image), all have offsets
    //rn2 <- textnode, rn4 <- ninegrid, image
    public PVPMKSBattleLog()
    {
        Size = new Vector2(384, 260);
        NodeId = 1;
        ConstructResNodes();
        ConstructImageNodes();
        ConstructTextNodes();
        ConstructAndLoadMatchEventComponentNodes();
        ConstructNineGridNodes();
        AddPartsToNinegridNodes();
        ConstructNineGridNodeTimelines();
        ConstructTimelinesForResNodes();
        ConstructTimelinesForImageNodes();
        ConstructTimelinesForTextNodes();
        BuildRootTimeline();
        AttachNodes();
        // construct objects
        // load timelines
        // attach nodes
    }

    private void AttachNodes()
    {
        _unkResNode13.AttachNode(this);
        _unkResNode14.AttachNode(_unkResNode13);
        _unkResNode15.AttachNode(_unkResNode14);
        _unkNineGridNode23.AttachNode(_unkResNode15);
        _unkNineGridNode22.AttachNode(_unkResNode15);
        _unkNineGridNode21.AttachNode(_unkResNode15);
        _unkNineGridNode20.AttachNode(_unkResNode15);
        _unkNineGridNode19.AttachNode(_unkResNode15);
        _unkNineGridNode18.AttachNode(_unkResNode15);
        _unkNineGridNode17.AttachNode(_unkResNode15);
        _unkNineGridNode16.AttachNode(_unkResNode15);
        _pvPmksMatchEventComponentNode12.AttachNode(this);
        _pvPmksMatchEventComponentNode11.AttachNode(this);
        _pvPmksMatchEventComponentNode10.AttachNode(this);
        _pvPmksMatchEventComponentNode9.AttachNode(this);
        _pvPmksMatchEventComponentNode8.AttachNode(this);
        _pvPmksMatchEventComponentNode7.AttachNode(this);
        _unkResNode2.AttachNode(this);
        _unkResNode4.AttachNode(_unkResNode2);
        _unkTextNode3.AttachNode(_unkResNode2);
        _unkImageNode5.AttachNode(_unkResNode4);
        _unkNineGridNode6.AttachNode(_unkResNode4);
    }

    private void ConstructTextNodes()
    {
        _unkTextNode3 = new TextNode
        {
            Position = new Vector2(31,0),
            Size = new Vector2(352,32),
            Origin = new Vector2(150,16),
            Color = new Vector4(1.000f, 1.000f, 1.000f, 0.957f),
            AlignmentType = AlignmentType.Left,
            FontType = FontType.Axis,
            FontSize = 14,
            TextOutlineColor = new Vector4(0.616f, 0.514f, 0.357f, 1.000f),
            TextFlags = TextFlags.Edge | TextFlags.Ellipsis,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                        NodeFlags.EmitsEvents,
            String = "unkTextNode3"
        };
    }

    private void ConstructAndLoadMatchEventComponentNodes()
    {
        _pvPmksMatchEventComponentNode12 = new PvPMKSMatchEventComponentNode(new Vector2(0, 52));
        _pvPmksMatchEventComponentNode11 = new PvPMKSMatchEventComponentNode(new Vector2(0, 94));
        _pvPmksMatchEventComponentNode10 = new PvPMKSMatchEventComponentNode(new Vector2(0, 136));
        _pvPmksMatchEventComponentNode9 = new PvPMKSMatchEventComponentNode(new Vector2(0, 178));
        _pvPmksMatchEventComponentNode8 = new PvPMKSMatchEventComponentNode(new Vector2(0, 220));
        _pvPmksMatchEventComponentNode7 = new PvPMKSMatchEventComponentNode(new Vector2(0, 262));
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

        _unkNineGridNode6 = new NineGridNode
        {
            Size = new Vector2(384, 32),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Offsets = new Vector4(8f, 8f, 16f, 16f)
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
        _unkNineGridNode6.AddPart(contentGauge0);
    }

    private void ConstructImageNodes()
    {
        _unkImageNode5 = new SimpleImageNode
        {
            Position = new Vector2(4,2),
            Size = new Vector2(28,28),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            PartId = 0,
            TexturePath = "ui/uld/CircleButtons.tex",
            TextureCoordinates = new Vector2(112,84),
            TextureSize = new Vector2(28,28)
        };
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

        _unkResNode2 = new ResNode
        {
            Position = new Vector2(0,20),
            Size = new Vector2(384,32),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,

        };
        _unkResNode4 = new ResNode
        {
            Size = new Vector2(384,32),
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
        _unkNineGridNode6.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 70)
                .AddFrame(11, addColor: new Vector3(64, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(41, addColor: new Vector3(200, 32, 32), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(64, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build());

    }

    private void ConstructTimelinesForTextNodes()
    {
        _unkTextNode3.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, position: new Vector2(0,0))
                .AddFrame(10, position: new Vector2(32,0))
                .AddFrame(1, alpha: 0)
                .AddFrame(10, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(11, 70)
                .AddFrame(11, position: new Vector2(32,0))
                .AddFrame(38, position: new Vector2(32,0))
                .AddFrame(70, position: new Vector2(32,0))
                .AddFrame(11, alpha: 255)
                .AddFrame(38, alpha: 191)
                .AddFrame(70, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(71, 80)
                .AddFrame(71, position: new Vector2(32,0))
                .AddFrame(80, position: new Vector2(60,0))
                .AddFrame(71, alpha: 255)
                .AddFrame(80, alpha: 0)
                .EndFrameSet()
                .Build());
    }

    private void ConstructTimelinesForImageNodes()
    {
        _unkImageNode5.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 70)
                .AddFrame(11, addColor: new Vector3(64, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build());
    }

    private void ConstructTimelinesForResNodes()
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
        _unkResNode2.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 90)
                .AddLabel(1, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(11, 102, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(70, 0, AtkTimelineJumpBehavior.LoopForever, 102)
                .AddLabel(71, 4, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(81, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .Build());
        _unkResNode4.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 70)
                .AddLabel(1, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(10, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 102, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(70, 0, AtkTimelineJumpBehavior.LoopForever, 102)
                .EndFrameSet()
                .BeginFrameSet(1, 10)
                .AddFrame(1, alpha: 0)
                .AddFrame(6, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(11, 70)
                .AddFrame(11, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(71, 80)
                .AddFrame(71, alpha: 255)
                .AddFrame(76, alpha: 255)
                .AddFrame(80, alpha: 0)
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