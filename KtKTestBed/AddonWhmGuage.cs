using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit;
using KamiToolKit.Nodes;

namespace KtKTestBed;

public class AddonWhmGauge : NativeAddon {

    private TextNode? timeTextNode;
    
    protected override unsafe void OnSetup(AtkUnitBase* addon) {
        addon->SubscribeAtkArrayData(1, (int)NumberArrayType.JobHud);

        timeTextNode = new TextNode() {
            Position = ContentStartPosition,
            String = "number here",
        };
        timeTextNode.AttachNode(this);
    }

    protected override unsafe void OnRequestedUpdate(AtkUnitBase* addon, NumberArrayData** numberArrayData, StringArrayData** stringArrayData)
    {
        if (timeTextNode != null)
            timeTextNode.String = numberArrayData[(int) NumberArrayType.JobHud]->IntArray[4].ToString();
    }

    protected override unsafe void OnFinalize(AtkUnitBase* addon) {
        addon->UnsubscribeAtkArrayData(1, (int)NumberArrayType.JobHud);
    }
}