using Godot;
using System;

public partial class NPC : CharacterBody2D, IEntity
{

    public float moveSpeed { get; set; }

    [Export] public string name { get; set; }
    [Export] public string npc_id;


    void StartDialog()
    {
        
    }

    


}
