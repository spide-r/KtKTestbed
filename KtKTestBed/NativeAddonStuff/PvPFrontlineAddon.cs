using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit;
using KtKTestBed.ResNodeStuff;

namespace KtKTestBed.NativeAddonStuff;

public class PvPFrontlineAddon : NativeAddon
{
    private PvPFrontlineInfo _frontlineInfo;
    protected override unsafe void OnSetup(AtkUnitBase* addon) {
           
        _frontlineInfo = new PvPFrontlineInfo();

        _frontlineInfo.AttachNode(this);
    } 
}