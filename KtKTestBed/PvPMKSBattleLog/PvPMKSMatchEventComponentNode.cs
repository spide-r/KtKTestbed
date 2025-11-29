using System.Numerics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Classes;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PvPMKSMatchEventComponentNode: ResNode //this is a Base Component Node in ai2 but the node type is atkresnode
{
    // attached:
    // Resnode <- Resnode <- (22 nodes of crap)
    private ResNode _unkResNode2 = null!;
    private ResNode _unkResNode3 = null!;
    
    private NineGridNode _unkNineGridNode27 = null!;
    private TextNode _unkTextNode26 = null!;
    private ResNode _unkResNode24 = null!;
    private ResNode _unkBaseComponentNode23 = null!; //basecomponent-but-actually-resnode todo: MAKE INTO NEW CLASS
    
    private ImageNode _unkImageNode22 = null!;
    private ImageNode _unkImageNode21 = null!;
    private ImageNode _unkImageNode20 = null!;
    private ImageNode _unkImageNode19 = null!;
    private ImageNode _unkImageNode18 = null!;
    private ImageNode _unkImageNode17 = null!;
    private ImageNode _unkImageNode16 = null!;
    private ImageNode _unkImageNode15 = null!;
    
    private NineGridNode _unkNineGridNode14 = null!;
    
    private ResNode _unkBaseComponentNode13 = null!; //basecomponent-but-actually-resnode todo: MAKE INTO NEW CLASS
    
    private ImageNode _unkImageNode12 = null!;
    private ImageNode _unkImageNode11 = null!;
    private ImageNode _unkImageNode10 = null!;
    private ImageNode _unkImageNode9 = null!;
    
    private ResNode _unkResNode7 = null!;
    
    private TextNode _unkTextNode8 = null!;
    private TextNode _unkTextNode6 = null!;
    private TextNode _unkTextNode5 = null!;
    private TextNode _unkTextNode4 = null!;
    public PvPMKSMatchEventComponentNode(Vector2 position)
    {
        Position = position;
        Size = new Vector2(384,40);
        NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                    NodeFlags.EmitsEvents;
        // construct objects
        // load timelines
        // attach nodes
    }

    private void ConstructNinegridNodes()
    {
        _unkNineGridNode27 = new NineGridNode
        {
            Position = new Vector2(-20, 0),
            Size = new Vector2(414,40),
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };

        _unkNineGridNode14 = new NineGridNode
        {
            Position = new Vector2(44, 0),
            Size = new Vector2(256, 18),
            Color = new Vector4(1,1,1,0.247f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)

        };
    }

    private void ConstructImageNodes()
    {
        _unkImageNode22 = ConstructAndLoadArrowImageNode(new Vector2(230, 17), 0.098f);
        _unkImageNode21 = ConstructAndLoadArrowImageNode(new Vector2(200, 17), 0.098f);
        _unkImageNode20 = ConstructAndLoadArrowImageNode(new Vector2(170, 17), 0.146f);
        _unkImageNode19 = ConstructAndLoadArrowImageNode(new Vector2(140, 17), 0.078f);
        _unkImageNode18 = ConstructAndLoadArrowImageNode(new Vector2(110, 17), 0.133f);
        _unkImageNode17 = ConstructAndLoadArrowImageNode(new Vector2(80, 17), 0.118f);
        _unkImageNode16 = ConstructAndLoadArrowImageNode(new Vector2(50, 17), 0.039f);
        _unkImageNode15 = ConstructAndLoadArrowImageNode(new Vector2(20, 17), 0.113f);
        _unkImageNode12 = ConstructAndLoadCrossedWordsImageNode();
        _unkImageNode11 = ConstructAndLoadCrossedWordsImageNode();
        _unkImageNode10 = ConstructAndLoadCrossedWordsImageNode();
        _unkImageNode9 = ConstructAndLoadCrossedWordsImageNode();
    }

    private unsafe ImageNode ConstructAndLoadCrossedWordsImageNode()
    {
        ImageNode image = new ImageNode
        {
            Position = new Vector2(250,-8),
            Size = new Vector2(46,54),
            Origin = new Vector2(23,26),
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(0, -0.502f, -0.502f),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch
        };
        Part p = new Part
        {
            Id = 0,
            Size = new Vector2(128,128),
            TexturePath = "ui/uld/PVPProfileIconBg.tex"
        };
        image.AddPart(p);
        return image;
    }

    private ImageNode ConstructAndLoadArrowImageNode(Vector2 position, float alpha)
    {
        ImageNode image = new ImageNode
        {
            Position = position,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled |
                        NodeFlags.EmitsEvents,
            Size = new Vector2(60,46),
            Color = new Vector4(1,1,1,alpha),
            WrapMode = WrapMode.Stretch,
            PartId = 3,
            Scale = new Vector2(0.5f,0.5f)
            
        };
        PVPMKSTextureHelper.LoadPvPScreenInformation(image);
        return image;
    }

    private void ConstructTextNodes()
    {
        _unkTextNode26 = new TextNode
        {
            Position = new Vector2(48, 0),
            Size = new Vector2(340, 40),
            FontType = FontType.Axis,
            FontSize = 14,
            AlignmentType = AlignmentType.Left,
            TextOutlineColor = new Vector4(0.616f, 0.514f, 0.357f, 1.000f),
            String = "unkTextNode26",
            TextFlags = TextFlags.Edge | TextFlags.MultiLine //todo Unk15 flag??
        };
        _unkTextNode8 = new TextNode
        {
            Size = new Vector2(210,18),
            FontType = FontType.Axis,
            FontSize = 14,
            AlignmentType = AlignmentType.Left,
            TextOutlineColor = new Vector4(0.000f, 0.600f, 1.000f, 1.000f),
            TextFlags = TextFlags.Edge | TextFlags.Glare | TextFlags.Ellipsis, //todo Unk15
            String = "unkTextNode8"
        };

        _unkTextNode6 = new TextNode
        {
            Position = new Vector2(30,19),
            Size = new Vector2(64,20),
            Scale = new Vector2(2,2),
            Origin = new Vector2(32,8),
            AlignmentType = AlignmentType.Right,
            FontType = FontType.MiedingerMed,
            FontSize = 24,
            TextOutlineColor = new Vector4(0.902f, 0.655f, 0.227f, 1.000f),
            TextFlags = TextFlags.Edge | TextFlags.Glare,
            String = "unkTextNode6"
        };
        _unkTextNode5 = new TextNode
        {
            Position = new Vector2(40,18),
            Size = new Vector2(64,20),
            Scale = new Vector2(1,1.17f),
            Origin = new Vector2(32,8),
            AlignmentType = AlignmentType.Right,
            FontType = FontType.MiedingerMed,
            FontSize = 24,
            Color = new Vector4(1.000f, 1.000f, 1.000f, 0.165f),
            TextOutlineColor = new Vector4(0.941f, 0.557f, 0.216f, 1.000f),
            TextFlags = TextFlags.Edge | TextFlags.Glare,
            
        };

        _unkTextNode4 = new TextNode
        {
            Position = new Vector2(-50, 20),
            Size = new Vector2(70,16),
            Origin = new Vector2(35,8),
            String = "KO",
            AlignmentType = AlignmentType.Left,
            FontType = FontType.MiedingerMed,
            FontSize = 18,
            TextOutlineColor = new Vector4(0.616f, 0.514f, 0.357f, 1.000f),
            TextFlags = TextFlags.Edge //todo unk15
        };
    }

    private void AddPartsToNodes()
    {
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode27);
    }

    private void ConstructResNodes()
    {
        _unkResNode2 = new ResNode
        {
         Position   = new Vector2(0,0),
         Size = new Vector2(384,40),
         NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                     NodeFlags.EmitsEvents
        };
        
        _unkResNode3 = new ResNode
        {
            Position   = new Vector2(0,0),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                        NodeFlags.EmitsEvents    
        };
        
        _unkResNode24 = new ResNode
        {
            Size = new Vector2(40,40),
            Scale = new Vector2(2,2),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Origin = new Vector2(20,20)
        };

        _unkBaseComponentNode23 = new ResNode
        {
            //todo move to class
            Size = new Vector2(40,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
        _unkBaseComponentNode13 = new ResNode
        {
            //todo move to class
            Position = new Vector2(200,0),
            Size = new Vector2(40,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Color = new Vector4(1,1,1,0)
        };

        _unkResNode7 = new ResNode
        {
            Size = new Vector2(210,18),
            Color = new Vector4(1,1,1,0f),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents
        };
    }

    private void LoadTimelineForResnodes()
    {
        _unkResNode2.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 36)
                .AddLabel(1, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(27, 4, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(31, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(32, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(36, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .BeginFrameSet(1, 10)
                .AddFrame(1, position: new Vector2(0,0))
                .AddFrame(1, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, position: new Vector2(0,42))
                .AddFrame(26, position: new Vector2(0,0))
                .AddFrame(11, alpha: 255)
                .AddFrame(26, alpha: 255)
                .EndFrameSet()
                .Build());
        
        _unkResNode3.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 120)
                .AddLabel(1, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(10, 101, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(26, 102, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(55, 0, AtkTimelineJumpBehavior.LoopForever, 102)
                .AddLabel(56, 103, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(71, 104, AtkTimelineJumpBehavior.Start, 0)
                .AddLabel(120, 105, AtkTimelineJumpBehavior.LoopForever, 104)
                .EndFrameSet()
                .BeginFrameSet(1, 26)
                .AddFrame(1, position: new Vector2(0,0))
                .AddFrame(1, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(27, 31)
                .AddFrame(27, position: new Vector2(0,0))
                .AddFrame(31, position: new Vector2(64,0))
                .AddFrame(27, alpha: 255)
                .AddFrame(31, alpha: 0)
                .EndFrameSet()
                .BeginFrameSet(32, 36)
                .AddFrame(32, position: new Vector2(0,0))
                .AddFrame(36, position: new Vector2(0,0))
                .AddFrame(32, alpha: 0)
                .AddFrame(36, alpha: 255)
                .EndFrameSet()
                .Build());
    }

    private void LoadTimelineForRoot()
    {
        AddTimeline(new TimelineBuilder()
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
    }
    
    
}