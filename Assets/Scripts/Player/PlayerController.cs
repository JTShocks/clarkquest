using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{

	Camera2D camera;
	Vector2 inputDirection;
    [Export] 
	public int moveSpeed;

	bool isMoving;

	[Export]
	AnimationTree animationTree;
	[Export]
	AnimationNodeStateMachinePlayback animationMode;

	

	private bool isFacingLeft = false;

    public bool isSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	//This is the generic player controller for moving the player around and getting player input

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		camera = GetNode<Camera2D>("PlayerCamera");
		//animationTree = GetNode<AnimationTree>("AnimationTree");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetInput();
				isMoving = inputDirection != Vector2.Zero && Velocity.Length() != 0;
		UpdateAnimations();





		
		//Will move this around to account for jumping, but should work okay.
		//Vector2 moveVector = new();
		//moveVector = inputDirection * moveSpeed* (float)delta;


		//MoveAndCollide(moveVector);

		//Vector2 mousePos = GetGlobalMousePosition();
		//camera.GlobalPosition = GlobalPosition.Lerp(mousePos, 0.15f);



		//If we read the primary click or the secondary click
		//Use the primary weapon

	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = inputDirection.Normalized() * moveSpeed;

		MoveAndSlide();


		

		//if(Input.IsActionJustPressed("Interact"))
		//{
		//	GD.Print("Interacted");
		//}
	}

    public void GetInput()
    {
        inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		GD.Print(inputDirection.ToString());
    }

	public void _unhandled_input()
	{

	}

	void UpdateAnimations()
	{
		animationTree.Set("parameters/Locomotion/conditions/is_moving", isMoving);
		animationTree.Set("parameters/Locomotion/conditions/idle", !isMoving);
		


		if (isMoving)
		{
			animationTree.Set("parameters/Locomotion/Idle/blend_position", inputDirection.X);
			animationTree.Set("parameters/Locomotion/Walk/blend_position", inputDirection);
		}
	}

    public bool Interact()
	{
		//throw new NotImplementedException();
		return true;
	}

    //public void Interact(Interactor interactor)
   // {
     //   //throw new NotImplementedException();
    //}

    public void OnSelect()
    {
        throw new NotImplementedException();
    }

    public void OnDeselect()
    {
        throw new NotImplementedException();
    }

}
