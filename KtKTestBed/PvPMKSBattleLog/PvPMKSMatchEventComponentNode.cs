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
    private ImageNode _unkImageNode25 = null!;
    private ResNode _unkResNode24 = null!;
    private PVPMKSInfoMatchEventIconNode _unkBaseComponentNode23 = null!; //basecomponent
    
    private ImageNode _unkImageNode22 = null!;
    private ImageNode _unkImageNode21 = null!;
    private ImageNode _unkImageNode20 = null!;
    private ImageNode _unkImageNode19 = null!;
    private ImageNode _unkImageNode18 = null!;
    private ImageNode _unkImageNode17 = null!;
    private ImageNode _unkImageNode16 = null!;
    private ImageNode _unkImageNode15 = null!;
    
    private NineGridNode _unkNineGridNode14 = null!;
    
    private PVPMKSInfoMatchEventIconNode _unkBaseComponentNode13 = null!; //basecomponent
    
    private ImageNode _unkImageNode12 = null!;
    private ImageNode _unkImageNode11 = null!;
    private ImageNode _unkImageNode10 = null!;
    private ImageNode _unkImageNode9 = null!;
    
    private ResNode _unkResNode7 = null!;
    
    private TextNode _unkTextNode8 = null!;
    private TextNode _unkTextNode6 = null!;
    private TextNode _unkTextNode5 = null!;
    private TextNode _unkTextNode4 = null!;

    public void PlayAnimation(int anim)
    {
        Service.PluginLog.Debug(anim.ToString());
        Timeline?.PlayAnimation(anim);
        _unkResNode2.Timeline?.PlayAnimation(anim);
        _unkResNode3.Timeline?.PlayAnimation(anim);
        _unkResNode7.Timeline?.PlayAnimation(anim);
        _unkResNode24.Timeline?.PlayAnimation(anim);
        _unkBaseComponentNode13.Timeline?.PlayAnimation(anim);
        _unkBaseComponentNode23.Timeline?.PlayAnimation(anim);
    }
    public PvPMKSMatchEventComponentNode(Vector2 position, uint id)
    {
        NodeId = id;
        Position = position;
        Size = new Vector2(384,40);
        NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                    NodeFlags.EmitsEvents;
        IsVisible = true;
        ConstructResNodes();
        ConstructImageNodes();
        ConstructNinegridNodes();
        ConstructTextNodes();
        AddPartsToNodes();
        LoadTimelineForImageNodes();
        LoadTimelineForNineGridNodes();
        LoadTimelineForResnodes();
        LoadTimelineForTextnodes();
        LoadTimelineForRoot();
        AttachNodes();
    }
    
    private void AttachNodes()
    {
        _unkResNode2.AttachNode(this);
        _unkResNode3.AttachNode(_unkResNode2);
        
        _unkTextNode4.AttachNode(_unkResNode3);
        _unkTextNode5.AttachNode(_unkResNode3);
        _unkTextNode6.AttachNode(_unkResNode3);
        _unkResNode7.AttachNode(_unkResNode3);
        _unkTextNode8.AttachNode(_unkResNode7);
        _unkImageNode9.AttachNode(_unkResNode3);
        _unkImageNode10.AttachNode(_unkResNode3);
        _unkImageNode11.AttachNode(_unkResNode3);
        _unkImageNode12.AttachNode(_unkResNode3);
        _unkBaseComponentNode13.AttachNode(_unkResNode3);
        _unkNineGridNode14.AttachNode(_unkResNode3);
        _unkImageNode15.AttachNode(_unkResNode3);
        _unkImageNode16.AttachNode(_unkResNode3);
        _unkImageNode17.AttachNode(_unkResNode3);
        _unkImageNode18.AttachNode(_unkResNode3);
        _unkImageNode19.AttachNode(_unkResNode3);
        _unkImageNode20.AttachNode(_unkResNode3);
        _unkImageNode21.AttachNode(_unkResNode3);
        _unkImageNode22.AttachNode(_unkResNode3);
        _unkBaseComponentNode23.AttachNode(_unkResNode3);
        _unkResNode24.AttachNode(_unkResNode3);
        _unkImageNode25.AttachNode(_unkResNode24);
        _unkTextNode26.AttachNode(_unkResNode3);
        _unkNineGridNode27.AttachNode(_unkResNode3);
    }

    private void ConstructNinegridNodes()
    {
        _unkNineGridNode27 = new NineGridNode
        {
            NodeId = 27,
            Position = new Vector2(-20, 0),
            Size = new Vector2(414,40),
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(-1,-1,-1),
            PartId = 10,
            Offsets = new Vector4(2f,2f,50f,50f)
        };

        _unkNineGridNode14 = new NineGridNode
        {
            NodeId = 14,
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
        _unkImageNode25 = new ImageNode
        {
            NodeId = 25,
            Size = new Vector2(40, 40),
            Origin = new Vector2(20, 20),
            AddColor = new Vector3(-0.251f, 0.251f, 0.502f),
            PartId = 0,
        };
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_unkImageNode25);
        _unkImageNode22 = ConstructAndLoadArrowImageNode(new Vector2(230, 17), 0.098f, 22);
        _unkImageNode21 = ConstructAndLoadArrowImageNode(new Vector2(200, 17), 0.098f, 21);
        _unkImageNode20 = ConstructAndLoadArrowImageNode(new Vector2(170, 17), 0.146f, 20);
        _unkImageNode19 = ConstructAndLoadArrowImageNode(new Vector2(140, 17), 0.078f, 19);
        _unkImageNode18 = ConstructAndLoadArrowImageNode(new Vector2(110, 17), 0.133f, 18);
        _unkImageNode17 = ConstructAndLoadArrowImageNode(new Vector2(80, 17), 0.118f, 17);
        _unkImageNode16 = ConstructAndLoadArrowImageNode(new Vector2(50, 17), 0.039f, 16);
        _unkImageNode15 = ConstructAndLoadArrowImageNode(new Vector2(20, 17), 0.113f, 15);
        _unkImageNode12 = ConstructAndLoadCrossedSwordsImageNode(12);
        _unkImageNode11 = ConstructAndLoadCrossedSwordsImageNode(11);
        _unkImageNode10 = ConstructAndLoadCrossedSwordsImageNode(10);
        _unkImageNode9 = ConstructAndLoadCrossedSwordsImageNode(9);
    }

    private static unsafe ImageNode ConstructAndLoadCrossedSwordsImageNode(uint nodeId)
    {
        var image = new ImageNode
        {
            NodeId = nodeId,
            Position = new Vector2(250,-8),
            Size = new Vector2(46,54),
            Origin = new Vector2(23,26),
            Color = new Vector4(1,1,1,0.498f),
            AddColor = new Vector3(0, -0.502f, -0.502f),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch
        };
        var p = new Part
        {
            Id = 0,
            Size = new Vector2(128,128),
            TexturePath = "ui/uld/PVPProfileIconBg.tex"
        };
        image.AddPart(p);
        return image;
    }

    private static ImageNode ConstructAndLoadArrowImageNode(Vector2 position, float alpha, uint nodeId)
    {
        var image = new ImageNode
        {
            NodeId = nodeId,
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
            NodeId = 26,
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
            NodeId = 8,
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
            NodeId = 6,
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
            NodeId = 5,
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
            NodeId = 4,
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
        PVPMKSTextureHelper.LoadPvPScreenInformation(_unkNineGridNode14);
    }

    private void ConstructResNodes()
    {
        _unkResNode2 = new ResNode
        {
            NodeId = 2,
            Position   = new Vector2(0,0),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                        NodeFlags.EmitsEvents
        };
    
        _unkResNode3 = new ResNode
        {
            NodeId = 3,
            Position   = new Vector2(0,0),
            Size = new Vector2(384,40),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                        NodeFlags.EmitsEvents    
        };
    
        _unkResNode24 = new ResNode
        {
            NodeId = 24,
            Size = new Vector2(40,40),
            Scale = new Vector2(2,2),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            Origin = new Vector2(20,20)
        };

        _unkBaseComponentNode23 = new PVPMKSInfoMatchEventIconNode(new Vector2(0,0), 23);
        _unkBaseComponentNode13 = new PVPMKSInfoMatchEventIconNode(new Vector2(200,0), 13);


        _unkResNode7 = new ResNode
        {
            NodeId = 7,
            Size = new Vector2(210,18),
            Color = new Vector4(1,1,1,0f),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents
        };
    }

    private void LoadTimelineForImageNodes()
    {
        _unkImageNode25.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(11, 20)
                .AddEmptyFrame(11)
                .EndFrameSet()
                .Build());
        _unkImageNode22.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(47, 55)
                .AddFrame(47, alpha: 0)
                .AddFrame(51, alpha: 51)
                .AddFrame(55, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode21.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(44, 52)
                .AddFrame(44, alpha: 0)
                .AddFrame(48, alpha: 51)
                .AddFrame(52, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode20.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(41, 49)
                .AddFrame(41, alpha: 0)
                .AddFrame(45, alpha: 51)
                .AddFrame(49, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode19.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(38, 46)
                .AddFrame(38, alpha: 0)
                .AddFrame(41, alpha: 51)
                .AddFrame(46, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode18.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(35, 43)
                .AddFrame(35, alpha: 0)
                .AddFrame(38, alpha: 51)
                .AddFrame(43, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode17.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(32, 40)
                .AddFrame(32, alpha: 0)
                .AddFrame(35, alpha: 51)
                .AddFrame(40, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode16.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(30, 38)
                .AddFrame(30, alpha: 0)
                .AddFrame(33, alpha: 51)
                .AddFrame(38, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode15.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(27, 35)
                .AddFrame(27, alpha: 0)
                .AddFrame(30, alpha: 51)
                .AddFrame(35, alpha: 0)
                .EndFrameSet()
                .Build());
        _unkImageNode12.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(26, 55)
                .AddFrame(26, alpha: 127)
                .AddFrame(39, alpha: 0)
                .AddFrame(55, alpha: 127)
                .EndFrameSet()
                .Build());
        _unkImageNode11.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(26, 55)
                .AddFrame(26, alpha: 127)
                .AddFrame(39, alpha: 63)
                .AddFrame(55, alpha: 127)
                .EndFrameSet()
                .Build());
        _unkImageNode10.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, scale: new Vector2(2, 2))
                .AddFrame(19, scale: new Vector2(1, 1))
                .AddFrame(10, alpha: 0)
                .AddFrame(19, alpha: 127)
                .EndFrameSet()
                .Build());
        _unkImageNode9.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, scale: new Vector2(2, 2))
                .AddFrame(19, scale: new Vector2(1, 1))
                .AddFrame(10, alpha: 0)
                .AddFrame(19, alpha: 127)
                .EndFrameSet()
                .Build());
    }

    private void LoadTimelineForNineGridNodes()
    {
        _unkNineGridNode27.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, alpha: 0)
                .AddFrame(14, alpha: 127)
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, alpha: 127)
                .EndFrameSet()
                .BeginFrameSet(56, 70)
                .AddFrame(56, alpha: 0)
                .AddFrame(60, alpha: 127)
                .EndFrameSet()
                .BeginFrameSet(71, 120)
                .AddFrame(71, alpha: 127)
                .EndFrameSet()
                .Build());
        _unkNineGridNode14.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(26, 55)
                .AddEmptyFrame(26)
                .EndFrameSet()
                .Build());
    }

    private void LoadTimelineForTextnodes()
    {
        _unkTextNode26.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(56, 70)
                .AddFrame(56, position: new Vector2(0,0))
                .AddFrame(61, position: new Vector2(48,0))
                .AddFrame(56, alpha: 0)
                .AddFrame(61, alpha: 231)
                .EndFrameSet()
                .BeginFrameSet(71, 120)
                .AddFrame(71, position: new Vector2(48,0))
                .AddFrame(98, position: new Vector2(48,0))
                .AddFrame(120, position: new Vector2(48,0))
                .AddFrame(71, alpha: 255)
                .AddFrame(98, alpha: 127)
                .AddFrame(120, alpha: 255)
                .EndFrameSet()
                .Build());
        _unkTextNode8.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, textOutlineColor: new Vector3(0, 153, 255))
                .EndFrameSet()
                .BeginFrameSet(11, 20)
                .AddFrame(11, textOutlineColor: new Vector3(204, 55, 55))
                .EndFrameSet()
                .Build());
        _unkTextNode6.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, position: new Vector2(30,19))
                .AddFrame(13, position: new Vector2(40,19))
                .AddFrame(25, position: new Vector2(40,19))
                .AddFrame(10, scale: new Vector2(2, 2))
                .AddFrame(13, scale: new Vector2(1, 1))
                .AddFrame(25, scale: new Vector2(1, 1))
                .AddFrame(10, alpha: 0)
                .AddFrame(13, alpha: 255)
                .AddFrame(25, alpha: 255)
                .AddFrame(10, textOutlineColor: new Vector3(230, 167, 58))
                .AddFrame(13, textOutlineColor: new Vector3(230, 167, 58))
                .AddFrame(25, textOutlineColor: new Vector3(157, 131, 91))
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, position: new Vector2(40,19))
                .AddFrame(39, position: new Vector2(40,19))
                .AddFrame(55, position: new Vector2(40,19))
                .AddFrame(26, scale: new Vector2(1, 1))
                .AddFrame(39, scale: new Vector2(1, 1))
                .AddFrame(55, scale: new Vector2(1, 1))
                .AddFrame(26, alpha: 255)
                .AddFrame(39, alpha: 191)
                .AddFrame(55, alpha: 255)
                .AddFrame(26, textOutlineColor: new Vector3(157, 131, 91))
                .AddFrame(39, textOutlineColor: new Vector3(157, 131, 91))
                .AddFrame(55, textOutlineColor: new Vector3(157, 131, 91))
                .EndFrameSet()
                .Build());
        _unkTextNode5.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(13, 21)
                .AddFrame(13, scale: new Vector2(1, 1))
                .AddFrame(16, scale: new Vector2(1, 1.5f))
                .AddFrame(21, scale: new Vector2(1, 2))
                .AddFrame(13, alpha: 0)
                .AddFrame(16, alpha: 127)
                .AddFrame(21, alpha: 0)
                .AddFrame(13, textOutlineColor: new Vector3(240, 142, 55))
                .AddFrame(16, textOutlineColor: new Vector3(240, 142, 55))
                .AddFrame(21, textOutlineColor: new Vector3(220, 0, 0))
                .EndFrameSet()
                .Build());
        _unkTextNode4.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(10, 25)
                .AddFrame(10, position: new Vector2(-50,20))
                .AddFrame(15, position: new Vector2(100,20))
                .AddFrame(25, position: new Vector2(110,20))
                .AddFrame(10, alpha: 0)
                .AddFrame(15, alpha: 255)
                .AddFrame(25, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, position: new Vector2(110,20))
                .AddFrame(39, position: new Vector2(110,20))
                .AddFrame(55, position: new Vector2(110,20))
                .AddFrame(26, alpha: 255)
                .AddFrame(39, alpha: 191)
                .AddFrame(55, alpha: 255)
                .EndFrameSet()
                .Build());
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
        _unkResNode24.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 20)
                .AddLabel(1, 17, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .BeginFrameSet(15, 25)
                .AddFrame(15, rotation: 6.2831855f)
                .AddFrame(20, rotation: 3.1415927f)
                .AddFrame(25, rotation: 0)
                .AddFrame(15, scale: new Vector2(1, 1))
                .AddFrame(20, scale: new Vector2(2.5f, 2.5f))
                .AddFrame(25, scale: new Vector2(2, 2))
                .AddFrame(15, alpha: 0)
                .AddFrame(20, alpha: 255)
                .AddFrame(25, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, rotation: 0)
                .AddFrame(55, rotation: 6.2831855f)
                .AddFrame(26, scale: new Vector2(2, 2))
                .AddFrame(55, scale: new Vector2(2, 2))
                .AddFrame(26, alpha: 255)
                .AddFrame(55, alpha: 255)
                .EndFrameSet()
                .Build());
        _unkResNode7.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 20)
                .AddLabel(1, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
                .AddLabel(11, 102, AtkTimelineJumpBehavior.PlayOnce, 0)
                .EndFrameSet()
                .BeginFrameSet(10, 25)
                .AddFrame(10, position: new Vector2(0,0))
                .AddFrame(19, position: new Vector2(36,0))
                .AddFrame(10, alpha: 0)
                .AddFrame(19, alpha: 255)
                .EndFrameSet()
                .BeginFrameSet(26, 55)
                .AddFrame(26, position: new Vector2(36,0))
                .AddFrame(26, alpha: 229)
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