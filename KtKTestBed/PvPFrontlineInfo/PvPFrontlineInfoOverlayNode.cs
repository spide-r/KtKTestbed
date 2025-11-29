using System;
using System.Numerics;
using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Classes;
using KamiToolKit.Classes.Controllers;
using KamiToolKit.Classes.Timelines;
using KamiToolKit.Nodes;
using KamiToolKit.Overlay;

namespace KtKTestBed.OverlayControllerStuff;

public sealed class PvPFrontlineInfoOverlayNode : OverlayNode, IDisposable
{
    public override OverlayLayer OverlayLayer { get; } = OverlayLayer.Background;
    private static string _pvPFrontLineInfoHr1 = "ui/uld/PvPFrontlineInfo_hr1.tex";
    private ImageNode _unkImageNode14 = null!;
    private ImageNode _unkImageNode13 = null!;
    private ImageNode _unkImageNode12 = null!;
    private ImageNode _unkImageNode11 = null!;
    private ImageNode _unkImageNode10 = null!;
    private ImageNode _unkImageNode9 = null!;
    
    private ResNode _iconObjectiveResNode5 = null!;
    private ImageNode _pulsingGlowingIconNode8 = null!;
    private ImageNode _raysSpinningImageNode7 = null!;
    private IconImageNode _currentMidObjectiveNode6 = null!; //this node is set to whatever icon is needed for current mid
    
    private TextNode _timeUntilNextObjectiveNode4 = null!;
    private ImageNode _clockIconNode3 = null!;
    private TextNode _objectiveStateTextNode2 = null!; //"Weapon Displacement System Charging", "Weaponry Deployed!" among other things

    //https://github.com/MidoriKami/VanillaPlus/blob/master/VanillaPlus/Features/BetterCursor/CursorImageNode.cs

    private int _currentAnimationForNode = 0;
    private int _currentAnimationForObjectiveIcon = 0;
    public override void Update()
    {
        
        var a = Service.PvPFrontlineInfoAdapter;
        _objectiveStateTextNode2.String = a.ObjectiveState;
        _timeUntilNextObjectiveNode4.String = a.ClockString;
        IsVisible = a.Visible;
        _currentMidObjectiveNode6.IconId = a.IconForResNode5;
        if (_currentAnimationForNode != a.Animation)
        {
            Timeline?.StopAnimation();
            Timeline?.PlayAnimation(a.Animation);
            _currentAnimationForNode = a.Animation;
        }
        
        if (_currentAnimationForObjectiveIcon != a.AnimationForResNode5)
        {
            if (a.AnimationForResNode5 == -1)
            {
                _iconObjectiveResNode5.Timeline?.StopAnimation();
            }
            else
            {
                _iconObjectiveResNode5.Timeline?.StopAnimation();
                _iconObjectiveResNode5.Timeline?.PlayAnimation(a.AnimationForResNode5);
            }

            _currentAnimationForObjectiveIcon = a.AnimationForResNode5;
        }

    }

    
    public PvPFrontlineInfoOverlayNode()
    {
        var a = Service.PvPFrontlineInfoAdapter;
        Service.AddonLifecycle.RegisterListener(AddonEvent.PostUpdate, "PvPFrontlineInfo", SetPositionScaleAndVisibility); //todo: deregister!!

        Size = new Vector2(212, 56);
        NodeId = 1;
        NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.Fill |
                    NodeFlags.Focusable |
                    NodeFlags.EmitsEvents;
        
        ConstructObjects();
        LoadTimeline();
        AttachNodes();
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            Service.AddonLifecycle.UnregisterListener(AddonEvent.PostUpdate, "PvPFrontlineInfo", SetPositionScaleAndVisibility); 
        }
    }

    public new void Dispose()
    {
        Dispose(true);
        base.Dispose();
        GC.SuppressFinalize(this);
    }

    private void SetPositionScaleAndVisibility(AddonEvent type, AddonArgs args)
    {
        unsafe
        {
            var addon = (AtkUnitBase*) args.Addon.Address;
            Scale = new Vector2(addon->Scale,  addon->Scale);
            var xX = addon->X;
            var yY = addon->Y;
            Position = new Vector2(xX, yY);
            if (addon->IsVisible) // make sure we dont overlay two of them
            {
                IsVisible = false;
            }
        }    
    }
    

    private void ConstructObjects()
    {
        GenerateImageNodes();
        GenerateResnode5();
        GenerateClock();
        LoadPvPMksForAllNodes();
    }
    private void AttachNodes() 
    {
        _unkImageNode14.AttachNode(this);
        _unkImageNode13.AttachNode(this);
        _unkImageNode12.AttachNode(this);
        _unkImageNode11.AttachNode(this);
        _unkImageNode10.AttachNode(this);
        _unkImageNode9.AttachNode(this);

        _iconObjectiveResNode5.AttachNode(this);
        _pulsingGlowingIconNode8.AttachNode(_iconObjectiveResNode5);
        //_raysSpinningImageNode7.AttachNode(_iconObjectiveResNode5);
        _currentMidObjectiveNode6.AttachNode(_iconObjectiveResNode5);
        
        _timeUntilNextObjectiveNode4.AttachNode(this);
        _clockIconNode3.AttachNode(this);
        _objectiveStateTextNode2.AttachNode(this);
    }
    private void LoadTimeline()
    {
        LoadTimelineForRoot();
        LoadTimelineForClockSection();
        LoadTimelineForImageNodes();
        LoadTimelineForResNode5();
    }
    private void GenerateImageNodes()
    {
        _unkImageNode14 = new ImageNode()
        {
            NodeId = 14,
            Position = new Vector2(106, 2),
            Size = new Vector2(160, 52),
            Scale = new Vector2(-0.25f, 1),
            Color = new Vector4(1,1,1,0),
            AddColor = new Vector3(0.251f, 0.000f, -0.251f),
            PartId = 18,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
        };
        
        _unkImageNode13 = new ImageNode()
        {
            NodeId = 13,
            Position = new Vector2(106, 2),
            Size = new Vector2(160, 52),
            Scale = new Vector2(0.25f, 1),
            Color = new Vector4(1,1,1,0),
            AddColor = new Vector3(0.251f,0,-0.251f),
            PartId = 18,
            WrapMode = WrapMode.Stretch,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft  | NodeFlags.Enabled | NodeFlags.EmitsEvents,
        };
        

        _unkImageNode12 = new ImageNode()
        {
            NodeId = 12,
            Position = new Vector2(106, 2),
            Size = new Vector2(160, 30),
            Scale = new Vector2(-1, 1.75f),
            PartId = 18,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.Visible | NodeFlags.AnchorLeft | NodeFlags.Enabled| NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch
        };
        _unkImageNode11 = new ImageNode()
        {
            NodeId = 11,
            Position = new Vector2(106, 2),
            Size = new Vector2(160, 30),
            Scale = new Vector2(1, 1.75f),
            PartId = 18,
            NodeFlags = NodeFlags.AnchorTop  | NodeFlags.Visible | NodeFlags.AnchorLeft | NodeFlags.Enabled| NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch

        };

        _unkImageNode10 = new SimpleImageNode()
        {
            NodeId = 10,
            IsVisible = true,
            Position = new Vector2(212, 0),
            Size = new Vector2(212, 56),
            Scale = new Vector2(-1, 1),
            Color = new Vector4(1,1,1,65),
            AddColor = new Vector3(-0.502f, -0.502f, -0.502f),
            PartId = 0,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents | NodeFlags.Visible,
            WrapMode = WrapMode.Stretch,
            TextureCoordinates = new Vector2(0, 0),
            TextureSize = new Vector2(212, 56),
            TexturePath = _pvPFrontLineInfoHr1,
        };

        
        _unkImageNode9 = new SimpleImageNode()
        {
            NodeId = 9,
            Position = new Vector2(0, 0),
            Size = new Vector2(212, 56),
            Scale = new Vector2(1, 1),
            Color = new Vector4(1,1,1,65),
            AddColor = new Vector3(-0.502f, -0.502f, -0.502f),
            PartId = 0,
            TextureCoordinates = new Vector2(0, 0),
            TextureSize = new Vector2(212, 56),
            TexturePath = _pvPFrontLineInfoHr1,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents | NodeFlags.Visible,
        };
        

    }
    private void GenerateClock() 
    {
        _timeUntilNextObjectiveNode4 = new TextNode
        {
            NodeId = 4,
            Position = new Vector2(76,35),
            Size = new Vector2(60,14),
            AlignmentType = AlignmentType.Center,
            FontType = FontType.MiedingerMed,
            FontSize = 14,
            TextColor = new Vector4(1,1,1,1),
            TextOutlineColor = new Vector4(0,0.6f,1,1),
            TextFlags = TextFlags.Edge | TextFlags.Glare,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents
        }; 

        _clockIconNode3 = new ImageNode()
        {
            NodeId = 3,
            IsVisible = true,
            Position = new Vector2(48, 31),
            Size = new Vector2(22, 22),
            AddColor = new Vector3(-0.251f, 0, 0.502f),
            PartId = 24,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft| NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            
        };

        _objectiveStateTextNode2 = new TextNode
        {
            NodeId = 2,
            Position = new Vector2(16, -1),
            Size = new Vector2(180, 32),
            AlignmentType = AlignmentType.Center,
            FontType = FontType.Axis,
            FontSize = 12,
            TextColor = new Vector4(1,1,1,1),
            TextOutlineColor = new Vector4(0,0.6f,1,1),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            TextFlags = TextFlags.Edge | TextFlags.Glare | TextFlags.WordWrap | TextFlags.MultiLine
        };
    }
    private void GenerateResnode5()
    {
        _iconObjectiveResNode5 = new ResNode
        {
            NodeId = 5,
            IsVisible = true,
            Position = new Vector2(18,18),
            Size = new Vector2(28,28),
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents | NodeFlags.Visible,

        };

        _pulsingGlowingIconNode8 = new ImageNode()
        {
            NodeId = 8,
            Position = new Vector2(-16,-16),
            Size = new Vector2(60,60),
            Origin = new Vector2(30,30),
            Color = new Vector4(1,1,1,103),
            PartId = 20,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.EmitsEvents | NodeFlags.Enabled,
            WrapMode = WrapMode.Stretch
        };

        _raysSpinningImageNode7 = new ImageNode()
        {
            NodeId = 7,
            Position = new Vector2(-18,-18),
            Size = new Vector2(64,64),
            Origin = new Vector2(32,32),
            Color = new Vector4(1,1,1,193),
            PartId = 17,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.EmitsEvents,
            WrapMode = WrapMode.Stretch,
            RotationDegrees = 183.1f,
        };

        _currentMidObjectiveNode6 = new IconImageNode
        {
            NodeId = 6,
            Position = new Vector2(0,0),
            Size = new Vector2(28,28),
            Origin = new Vector2(14,14),
            Color = new Vector4(1,1,1,1),
            AddColor = new Vector3(0.395f,0.395f,0.395f),
            WrapMode = WrapMode.Stretch,
            NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Enabled | NodeFlags.Visible | NodeFlags.EmitsEvents,

        };
    }
    private void LoadPvPMksForAllNodes()
    {
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_clockIconNode3); 
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_unkImageNode14);
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_unkImageNode13);
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_unkImageNode12);
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_unkImageNode11);
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_pulsingGlowingIconNode8);
        PvPIconNodeTextureHelper.LoadPvPmksGuageTexture(_raysSpinningImageNode7);
    }
    public void LoadTimelineForRoot()
    {
        AddTimeline(new TimelineBuilder()
            .BeginFrameSet(1, 110)
            .AddLabel(1, 101, AtkTimelineJumpBehavior.PlayOnce, 0)
            .AddLabel(11, 102, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(27, 103, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(56, 0, AtkTimelineJumpBehavior.LoopForever, 103)
            .AddLabel(57, 104, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(71, 105, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(110, 0, AtkTimelineJumpBehavior.LoopForever, 105)
            .EndFrameSet()
            .Build()
        );
    }
    private void LoadTimelineForImageNodes()
    {
            _unkImageNode14.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(11, 26)
                .AddFrame(11, scale: new Vector2(-0.25f, 1))
                .AddFrame(11, alpha: 0)
                .AddFrame(11, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, scale: new Vector2(-0.25f, 1))
                .AddFrame(42, scale: new Vector2(-0.75f, 1))
                .AddFrame(56, scale: new Vector2(-1.1f, 1))
                .AddFrame(27, alpha: 0)
                .AddFrame(42, alpha: 255)
                .AddFrame(56, alpha: 0)
                .AddFrame(27, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(42, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(56, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, scale: new Vector2(-0.25f, 1))
                .AddFrame(57, alpha: 0)
                .AddFrame(57, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, scale: new Vector2(-0.25f, 1))
                .AddFrame(90, scale: new Vector2(-0.75f, 1))
                .AddFrame(110, scale: new Vector2(-1.1f, 1))
                .AddFrame(71, alpha: 0)
                .AddFrame(90, alpha: 255)
                .AddFrame(110, alpha: 0)
                .AddFrame(71, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(90, addColor: new Vector3(255, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(110, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _unkImageNode13.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(11, 26)
                .AddFrame(11, scale: new Vector2(0.25f, 1))
                .AddFrame(11, alpha: 0)
                .AddFrame(11, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, scale: new Vector2(0.25f, 1))
                .AddFrame(42, scale: new Vector2(0.75f, 1))
                .AddFrame(56, scale: new Vector2(1.1f, 1))
                .AddFrame(27, alpha: 0)
                .AddFrame(42, alpha: 255)
                .AddFrame(56, alpha: 0)
                .AddFrame(27, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(42, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(56, addColor: new Vector3(255, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, scale: new Vector2(0.25f, 1))
                .AddFrame(57, alpha: 0)
                .AddFrame(57, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, scale: new Vector2(0.25f, 1))
                .AddFrame(90, scale: new Vector2(0.75f, 1))
                .AddFrame(110, scale: new Vector2(1.1f, 1))
                .AddFrame(71, alpha: 0)
                .AddFrame(90, alpha: 255)
                .AddFrame(110, alpha: 0)
                .AddFrame(71, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(90, addColor: new Vector3(255, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(110, addColor: new Vector3(64, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _unkImageNode12.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(15, addColor: new Vector3(255, 64, 64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(26, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(61, addColor: new Vector3(255, 128, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _unkImageNode11.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(15, addColor: new Vector3(255, 64, 64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(26, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(61, addColor: new Vector3(255, 128, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, addColor: new Vector3(128, 0, -64), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _unkImageNode10.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(-128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, addColor: new Vector3(-128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(15, addColor: new Vector3(255, 64, 64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(26, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(42, addColor: new Vector3(128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(56, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(61, addColor: new Vector3(255, 128, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(90, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(110, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _unkImageNode9.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(-128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, addColor: new Vector3(-128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(15, addColor: new Vector3(255, 64, 64), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(26, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(42, addColor: new Vector3(128, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(56, addColor: new Vector3(0, -128, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(61, addColor: new Vector3(255, 128, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(90, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(110, addColor: new Vector3(0, -64, -128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
    }
    private void LoadTimelineForResNode5()
    {
        _iconObjectiveResNode5.AddTimeline(new TimelineBuilder()
            .BeginFrameSet(1, 70)
            .AddLabel(1, 17, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(10, 0, AtkTimelineJumpBehavior.PlayOnce, 0)
            .AddLabel(11, 101, AtkTimelineJumpBehavior.Start, 0)
            .AddLabel(70, 0, AtkTimelineJumpBehavior.LoopForever, 101)
            .EndFrameSet()
            .Build()
        );
        _pulsingGlowingIconNode8.AddTimeline(new TimelineBuilder()
            .BeginFrameSet(11, 70)
            .AddFrame(11, alpha: 63)
            .AddFrame(41, alpha: 153)
            .AddFrame(70, alpha: 63)
            .EndFrameSet()
            .Build()
        );
        _raysSpinningImageNode7.AddTimeline(new TimelineBuilder()
            .BeginFrameSet(11, 70)
            .AddFrame(11, rotation: 0)
            .AddFrame(70, rotation: 6.2831855f)
            .EndFrameSet()
            .Build()
        );
        _currentMidObjectiveNode6.AddTimeline(new TimelineBuilder()
            .BeginFrameSet(11, 70)
            .AddFrame(11, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
            .AddFrame(41, addColor: new Vector3(100, 100, 100), multiplyColor: new Vector3(100, 100, 100))
            .AddFrame(70, addColor: new Vector3(0, 0, 0), multiplyColor: new Vector3(100, 100, 100))
            .EndFrameSet()
            .Build());

    }
    private void LoadTimelineForClockSection()
    {
              _timeUntilNextObjectiveNode4.AddTimeline(new TimelineBuilder()
          .BeginFrameSet(1, 10)
          .AddFrame(1, textOutlineColor: new Vector3(0.0f, 0.6000f, 1.0f))
          .EndFrameSet()
          .BeginFrameSet(11, 26)
          .AddFrame(11, textOutlineColor: new Vector3(0.0f, 0.6000f, 1.0f))
          .AddFrame(26, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
          .EndFrameSet()
          .BeginFrameSet(27, 56)
          .AddFrame(27, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
          .EndFrameSet()
          .BeginFrameSet(57, 70)
          .AddFrame(57, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
          .AddFrame(70, textOutlineColor: new Vector3(0.9412f, 0.5569f, 0.2157f))
          .EndFrameSet()
          .BeginFrameSet(71, 110)
          .AddFrame(71, textOutlineColor: new Vector3(0.9412f, 0.5569f, 0.2157f))
          .EndFrameSet()
          .Build()
      );
      _clockIconNode3.AddTimeline(new TimelineBuilder()
                .BeginFrameSet(1, 10)
                .AddFrame(1, addColor: new Vector3(-64, 0, 128), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(11, 26)
                .AddFrame(11, addColor: new Vector3(-64, 0, 128), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(26, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(27, 56)
                .AddFrame(27, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(57, 70)
                .AddFrame(57, addColor: new Vector3(128, 0, 0), multiplyColor: new Vector3(100, 100, 100))
                .AddFrame(70, addColor: new Vector3(128, 64, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .BeginFrameSet(71, 110)
                .AddFrame(71, addColor: new Vector3(128, 64, 0), multiplyColor: new Vector3(100, 100, 100))
                .EndFrameSet()
                .Build()
        );
        _objectiveStateTextNode2.AddTimeline(new TimelineBuilder().BeginFrameSet(1, 10)
            .AddFrame(1, textOutlineColor: new Vector3(0.0f, 0.6000f, 1.0f))
            .EndFrameSet()
            .BeginFrameSet(11, 26)
            .AddFrame(11, textOutlineColor: new Vector3(0.0f, 0.6000f, 1.0f))
            .AddFrame(26, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
            .EndFrameSet()
            .BeginFrameSet(27, 56)
            .AddFrame(27, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
            .EndFrameSet()
            .BeginFrameSet(57, 70)
            .AddFrame(57, textOutlineColor: new Vector3(0.8980f, 0.0f, 0.3098f))
            .AddFrame(70, textOutlineColor: new Vector3(0.9412f, 0.5569f, 0.2157f))
            .EndFrameSet()
            .BeginFrameSet(71, 110)
            .AddFrame(71, textOutlineColor: new Vector3(0.9412f, 0.5569f, 0.2157f))
            .EndFrameSet()
            .Build()
        );
        
    }
}