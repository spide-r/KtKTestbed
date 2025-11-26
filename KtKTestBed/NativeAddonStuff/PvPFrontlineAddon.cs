using KamiToolKit;

namespace KtKTestBed.NativeAddonStuff;

public class PvPFrontlineAddon : NativeAddon
{
    private PvPFrontlineInfo? _frontlineInfo;

    public PvPFrontlineAddon()
    {
        
        _frontlineInfo = new PvPFrontlineInfo();

        RootNode = _frontlineInfo;
        
    }
}