using Godot;
using System;

public partial class Interactable : Area2D
{

    //In this case, a signal would be better, since these are only going to be linked within a given scene
    [Signal]
    public delegate void OnInteractEventHandler();

    [Export] string interactText = "Activate";
    [Export] Transform2D interactPromptLocation;
    

    //When determining if a player should interact with something, the prompt should ONLY be on the one highlighted

    //Interactable defines the ZONE of a given interactable AND sends out an event on interacted

    public override void _Ready()
    {


        //Internal connections. Nothing outside will be affected by this
        BodyEntered += EnterRange;
        BodyExited += ExitRange;
       
    }

    public void Interact()
    {
        EmitSignal(SignalName.OnInteract);
    }

    void EnterRange(Node2D body)
    {
        //Activate the prompt
        //interactPrompt.Visible = true;
        if (body is PlayerController player)
        {
            player.ChangeInteractPrompt(true);
        }
    }
    void ExitRange(Node2D body)
    {
        //interactPrompt.Visible = false;
                if (body is PlayerController player)
        {
            player.ChangeInteractPrompt(true);
        }
    }
}
