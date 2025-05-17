using Godot;
using System;

public partial class PlayerController : CharacterBody2D, IInteractable
{

	Camera2D camera;
	Vector2 inputDirection;
    [Export] 
	public int moveSpeed;

	private bool isFacingLeft = false;

    public bool isSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //This is the generic player controller for moving the player around and getting player input

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		camera = GetNode<Camera2D>("PlayerCamera");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetInput();

		//Will move this around to account for jumping, but should work okay.
		//Vector2 moveVector = new();
		//moveVector = inputDirection * moveSpeed* (float)delta;


		//MoveAndCollide(moveVector);

		Vector2 mousePos = GetGlobalMousePosition();
        camera.GlobalPosition = GlobalPosition.Lerp(mousePos, 0.15f);

		if(mousePos.X < GlobalPosition.X && !isFacingLeft)
		{
			//Player is looking left
			isFacingLeft = true;
			FlipPlayer();
		}
		else if(mousePos.X > GlobalPosition.X && isFacingLeft)
		{
			isFacingLeft = false;
			FlipPlayer();
		}

		//If we read the primary click or the secondary click
		//Use the primary weapon

	}

    public override void _PhysicsProcess(double delta)
    {
		Velocity = inputDirection.Normalized() * moveSpeed;
		MoveAndSlide();
		if(Input.IsActionJustPressed("Interact"))
		{
			GD.Print("Interacted");
		}
    }

    public void GetInput()
    {
        inputDirection = Input.GetVector("Left", "Right", "Up", "Down");
		
    }

	void FlipPlayer()
	{
		ApplyScale(new Vector2(-1,1));
	}

    public bool Interact()
    {
        //throw new NotImplementedException();
		return true;
    }

    public void Interact(Interactor interactor)
    {
        //throw new NotImplementedException();
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
