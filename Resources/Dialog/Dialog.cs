using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class Dialog : Resource
{
    [Export] Godot.Collections.Dictionary dialogs;

    public void LoadFromJSON(string filePath)
    {
        var data = FileAccess.GetFileAsString(filePath);
        var parsedData = Json.ParseString(data);

        switch (parsedData.VariantType)
        {
            case Variant.Type.Nil:
                GD.PrintErr("Failed to parse: ", parsedData);
                break;
            default:
                dialogs = parsedData.AsGodotDictionary();
                break;

        }
    }

    /// <summary>
    /// Return individual NPC dialogs
    /// </summary>
    /// <param name="npc_id"></param>
    public Godot.Collections.Dictionary GetNPCDialog(string npc_id)
    {

        if (dialogs.ContainsKey(npc_id))
        {
            return ((Godot.Collections.Dictionary)dialogs[npc_id])["trees"].AsGodotDictionary();
        }
        else
        {
            return null;
        }
    }
}
