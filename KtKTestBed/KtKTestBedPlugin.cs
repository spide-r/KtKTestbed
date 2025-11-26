using System;
using System.Numerics;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using KamiToolKit;
using KtKTestBed.NativeAddonStuff;
using KtKTestBed.ResNodeStuff;

namespace KtKTestBed;

public class KtKTestBedPlugin: IDalamudPlugin
{

    public WindowSystem WindowSystem = new("KtKTestBedPlugin");
    

    public IDalamudPluginInterface PluginInterface { get; set; }

    public KtKTestBedPlugin(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
            Service.Initialize(pluginInterface);
            KamiToolKitLibrary.Initialize(pluginInterface);

            pluginInterface.UiBuilder.Draw += DrawUi;
            LoadCommands();

    }
    
    private void LoadCommands()
    {
        Service.CommandManager.AddHandler("/test", new CommandInfo(OnCommand)
        {
            HelpMessage = "Test Stuff",
        });
    }
    
    private AddonWhmGauge? whmGauge;
    
    private PvPFrontlineAddon? _frontlineAddon;

    private void TestFrontlineInfo()
    {
        _frontlineAddon = new PvPFrontlineAddon
        {
            InternalName = "PvPFrontlineInfo-KtKTestBed",
            Title = "PvPFrontlineInfo"
        };
        
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
    private void OnCommand(string command, string args)
    {
        Service.ChatGui.Print("AAAAAAAAAAA TEST START!!!!!!");
        TestFrontlineInfo();
  
        Service.ChatGui.Print("AAAAAAAAAAA TEST FAILED!!!!!!");
    }

    


    private void DrawUi()
    {
        WindowSystem.Draw();
    }



    public void Dispose()
    {
        KamiToolKitLibrary.Dispose();
        PluginInterface.UiBuilder.Draw -= DrawUi;
    }
}