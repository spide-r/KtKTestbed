using KamiToolKit;
using KtKTestBed.ResNodeStuff;

namespace KtKTestBed.NativeAddonStuff;

public class PvPFrontlineAddon : NativeAddon
{
    private PvPFrontlineInfo? _frontlineInfo;

    public PvPFrontlineAddon()
    {
        
        _frontlineInfo = new PvPFrontlineInfo();

        _frontlineInfo.AttachNode(this);
        
    }
}