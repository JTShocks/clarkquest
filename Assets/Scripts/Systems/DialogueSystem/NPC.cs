using Godot;
using System;

public partial class NPC : CharacterBody2D, IEntity, IInteractable
{

    public float moveSpeed { get; set; }

    [Export] public string name { get; set; }
    public bool isSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    [Export] public string npc_id;

    [Export] Dialog dialogResource;


    public void StartDialog()
    {
        GD.Print("Dialog has started");
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
