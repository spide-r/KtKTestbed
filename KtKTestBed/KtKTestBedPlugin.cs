using System;
using System.Numerics;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using KamiToolKit;
using KamiToolKit.Classes.Controllers;
using KtKTestBed.NativeAddonStuff;
using KtKTestBed.OverlayControllerStuff;
using KtKTestBed.ResNodeStuff;

namespace KtKTestBed;

public class KtKTestBedPlugin: IDalamudPlugin
{

    public WindowSystem WindowSystem = new("KtKTestBedPlugin");
    public static bool badDesignRemoveMe = false;
    

    public IDalamudPluginInterface PluginInterface { get; set; }

    private OverlayController? _overlayController;

    public KtKTestBedPlugin(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
            Service.Initialize(pluginInterface);
            KamiToolKitLibrary.Initialize(pluginInterface);
            _overlayController = new OverlayController();
            pluginInterface.UiBuilder.Draw += DrawUi;
            LoadCommands();
            loadNode();

    }
    
    private void LoadCommands()
    {
        Service.CommandManager.AddHandler("/test", new CommandInfo(OnCommand)
        {
            HelpMessage = "Test Stuff",
        });
    }
    
    private void loadNode()
    {
        _overlayController?.CreateNode(() => new PvPFrontlineInfoOverlayNode()); // node creation MUST happen on the main thread. .CreateNode facilitates this

    }
    
    private AddonWhmGauge? whmGauge;
    
    private PvPFrontlineAddon? _frontlineAddon;

    private void TestFrontlineInfoAddon()
    {
        _frontlineAddon = new PvPFrontlineAddon
        {
            InternalName = "PvPFrontlineInfo-KtKTestBed",
            Title = "PvPFrontlineInfo - I don't want this page"
        };
        _frontlineAddon.Open();
        
        
    }

    private void PutNativeAddonUpWhmTest()
    {
        whmGauge = new AddonWhmGauge {
            InternalName = "WhiteMageGauge",
            Title = "White Mage Gauge",
            Size = new Vector2(200.0f, 100.0f),
        };
        whmGauge.Open();

    }
    private void OverlayControllerTest()
    {
        badDesignRemoveMe = !badDesignRemoveMe;
    }
    private void OnCommand(string command, string args)
    {
        Service.ChatGui.Print("AAAAAAAAAAA TEST START!!!!!!");
        OverlayControllerTest();
  
        Service.ChatGui.Print("AAAAAAAAAAA TEST FAILED!!!!!!");
    }

    


    private void DrawUi()
    {
        WindowSystem.Draw();
    }



    public void Dispose()
    {
        _overlayController?.Dispose();
        _overlayController = null;
        PluginInterface.UiBuilder.Draw -= DrawUi;
        KamiToolKitLibrary.Dispose();

    }
}