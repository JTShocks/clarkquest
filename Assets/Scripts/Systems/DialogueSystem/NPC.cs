using Godot;
using System;

public partial class NPC : CharacterBody2D, IEntity, IInteractable
{

    public float moveSpeed { get; set; }

    [Export] public string name { get; set; }
    public bool isSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    [Export] public string npc_id;

    [Export] Dialog dialogResource;

    string currentState = "start";
    int currentBranchIndex = 0;


    public override void _Ready()
    {
        base._Ready();
        dialogResource.LoadFromJSON("res://Resources/Dialog/dialog_data.json");
    }



    public void StartDialog()
    {
        GD.Print("Dialog has started");
        Godot.Collections.Dictionary npcDialogs = dialogResource.GetNPCDialog(npc_id);
        if (npcDialogs.Count == 0)
        {
            return;
        }
    }
    /// <summary>
    /// Get current branch dialog
    /// </summary>
    /// <returns></returns>
    public string GetCurrentDialog()
    {
        Godot.Collections.Dictionary npcDialogs = dialogResource.GetNPCDialog(npc_id);
        if (currentBranchIndex < npcDialogs.Count)
        {
            foreach (var (dialog, value) in ((Godot.Collections.Dictionary)npcDialogs[currentBranchIndex])["dialogs"].AsGodotDictionary())
            {
                if (dialog.AsString() == currentState)
                {
                    return value.AsString();
                }
            }
        }
        return String.Empty;
    }
    /// <summary>
    /// Update dialog branch
    /// </summary>
    /// <param name="branchIndex"></param>
    public void SetDialogTree(int branchIndex)
    {
        currentBranchIndex = branchIndex;
        currentState = "start";
    }

    public void SetDialogState(string state)
    {
        currentState = state;
    }




    public bool Interact()
    {
        StartDialog();
        return true;
    }

    public void Interact(Interactor interactor)
    {
        throw new NotImplementedException();
    }

    public void OnSelect()
    {
        throw new NotImplementedException();
    }

    public void OnDeselect()
    {
        throw new NotImplementedException();
    }

}
