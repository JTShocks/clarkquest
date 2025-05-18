using Game.Items;
using Godot;
using System;

public partial class Interactor : Area2D
{


	//Things this needs to account for
	//1. Item in the "ActiveItem" slot
		//These are things like tools and weapons that take priority
	//2. Items that are in the player's hand/ actively being carried
		//These take precidence over interacting with an object
	[Export]
	float interactionRange = 3;

	[Export]
	public Item ActiveItem;
	[Export]
	public RayCast2D ray;

	public IInteractable highlightTarget;

	public bool WithRightClick;
	
	public override void _Ready()
	{

		BodyEntered += UpdateHighlightTarget;
		BodyExited += ClearHighlightTarget;


	}

    public override void _Process(double delta)
    {
        base._Process(delta);

		GlobalPosition = GetGlobalMousePosition();
		//GlobalPosition = new Vector2(Mathf.Clamp(GetGlobalMousePosition().X, -interactionRange*64, interactionRange*64), Mathf.Clamp(GetGlobalMousePosition().Y, -interactionRange*64, interactionRange*64) );

    }



    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

		if(@event is InputEventMouseButton mouseClick)
		{
			
			if(mouseClick.ButtonIndex == MouseButton.Left && mouseClick.Pressed)
			{		
					if(ActiveItem != null && ActiveItem is Weapon weapon)
					{
		
						weapon.Attack();
							
					}		
				//If the Left mouse is pressed
				if(highlightTarget != null) //If there is a target 
				{
	
				//Check if there is an active item in the slot
					//If YES, use that item on the target (such as shoot a weapon)
				//If not, the 

				}



			}
			else if(mouseClick.ButtonIndex == MouseButton.Right && mouseClick.Pressed)
			{
				//If the Right mouse is pressed
				if(highlightTarget != null) //If there is a target 
				{

					if(ActiveItem != null)
					{
						//If you can interact with the 
						if(ActiveItem.UseOn(highlightTarget))
						{
							GD.Print("Item was used");
							//If the item is successfully used on the target
							//Consume the item (if it is consumed)
						}
						else
						{
							GD.Print("Cannot use that item on this");
						}
					}
					else
					{
						highlightTarget.Interact();
					}
				}
				else //if there is no target for the input
				{
					//Drop the item on the ground
				}
			}
			
		}
    }

	public void UpdateHighlightTarget(Node2D body)
	{
		if(body is IInteractable interactable)
		{
			highlightTarget = interactable;
		}
	}
	public void ClearHighlightTarget(Node2D body)
	{
		highlightTarget = null;
	}



    public void OnInteract()
	{

		if(ActiveItem is Weapon weapon)
		{
			weapon.Attack();
			return;
		}
		var col = ray.GetCollider();
		if(col is IInteractable target)
		{
			

		}
		
		




	}



	
}
