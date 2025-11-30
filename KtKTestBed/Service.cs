using System;
using System.Windows.Input;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using KtKTestBed.OverlayControllerStuff;
using KtKTestBed.PvPMKSBattleLog;

namespace KtKTestBed;

#pragma warning disable 8618
// ReSharper disable UnusedAutoPropertyAccessor.Local

internal class Service {

    [PluginService]
    internal static IDataManager DataManager { get; private set; }
    
    [PluginService]
    internal static ICommandManager CommandManager { get; private set; }
    
    [PluginService]
    internal static IAddonLifecycle AddonLifecycle { get; private set; }

    [PluginService]
    internal static IChatGui ChatGui { get; private set; }
    
    [PluginService]
    internal static IPluginLog PluginLog { get; private set; }

    [PluginService]
    internal static IObjectTable ObjectTable { get; private set; }

    [PluginService]
    internal static IPartyList PartyList { get; private set; }

    [PluginService]
    internal static IClientState ClientState { get; private set; }
    
    [PluginService]
    internal static IDalamudPluginInterface DalamudPluginInterface { get; private set; }
    
    [PluginService]
    internal static ICondition Condition { get; private set; }
    
    [PluginService]
    internal static IFramework Framework { get; private set; }
    
    [PluginService]
    internal static IGameInteropProvider GameInteropProvider { get; private set; }
    
    [PluginService]
    internal static IDutyState DutyState { get; private set; }
    
    internal static PvPFrontlineInfoAdapter PvPFrontlineInfoAdapter { get; private set; }
    internal static PVPMKSBattleLogAdapter PVPMKSBattleLogAdapter { get; private set; }


    internal static void Initialize(IDalamudPluginInterface pluginInterface) {

        pluginInterface.Create<Service>();
        PvPFrontlineInfoAdapter = new PvPFrontlineInfoAdapter();
        PVPMKSBattleLogAdapter = new PVPMKSBattleLogAdapter();
        PluginLog.Verbose("Verbose");
        PluginLog.Debug("Debug");
        PluginLog.Info("Info");
    }


}
#pragma warning restore 8618