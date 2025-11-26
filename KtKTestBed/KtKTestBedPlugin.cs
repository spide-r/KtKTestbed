using System;
using System.Numerics;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using KamiToolKit;

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
    private void OnCommand(string command, string args)
    {
        Service.ChatGui.Print("AAAAAAAAAAA TEST START!!!!!!");

        whmGauge = new AddonWhmGauge {
            
            //NativeController = System.NativeController,
            InternalName = "WhiteMageGauge",
            Title = "White Mage Gauge",
            Size = new Vector2(200.0f, 100.0f),
        };
        
        whmGauge.Open();
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