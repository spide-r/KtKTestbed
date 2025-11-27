using System;
using System.Numerics;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using KamiToolKit;
using KamiToolKit.Classes.Controllers;
using KtKTestBed.OverlayControllerStuff;

namespace KtKTestBed;

// /xldata ai2
public class KtKTestBedPlugin: IDalamudPlugin
{

    public WindowSystem WindowSystem = new("KtKTestBedPlugin");
    

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
        
        Service.CommandManager.AddHandler("/test2", new CommandInfo(OnCommand2)
        {
            HelpMessage = "Test Stuff",
        });
    }
    
    private void loadNode()
    {
        _overlayController?.CreateNode(() => new PvPFrontlineInfoOverlayNode()); // node creation MUST happen on the main thread. .CreateNode facilitates this
    }
    
    
    private void OnCommand(string command, string args)
    {
        Service.PvPFrontlineInfoAdapter.Animation = Convert.ToInt32(args);
    }

    
    private void OnCommand2(string command, string args)
    {
        Service.PvPFrontlineInfoAdapter.AnimationForResNode5 = Convert.ToInt32(args);
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