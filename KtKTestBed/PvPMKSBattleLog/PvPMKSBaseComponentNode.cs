using System.Numerics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using KamiToolKit.Nodes;

namespace KtKTestBed.PvPMKSBattleLog;

public class PvPMKSBaseComponentNode: ResNode //this is a Base Component Node in ai2 but the node type is atkresnode
{
    // attached:
    // Resnode <- Resnode <- (22 nodes of crap)
    public PvPMKSBaseComponentNode(Vector2 position)
    {
        Position = position;
        Size = new Vector2(384,40);
        NodeFlags = NodeFlags.AnchorTop | NodeFlags.AnchorLeft | NodeFlags.Visible | NodeFlags.Enabled |
                    NodeFlags.EmitsEvents;
    }
}