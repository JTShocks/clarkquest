using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{

	Camera2D camera;
	Vector2 inputDirection;
	[Export]
	public int moveSpeed;

	bool isMoving;
	bool isIdle;

	[Export]
	AnimationTree animationTree;
	[Export]
	AnimationNodeStateMachinePlayback animationMode;

	[Export] Label interactPrompt;



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
		//GetInput();
		isMoving = inputDirection != Vector2.Zero && Velocity.Length() != 0;
		isIdle = !isMoving;
		UpdateAnimations();

	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey key)
		{
			GetInput();

			if (key.IsActionPressed("Interact"))
			{
				Interact();
			}
		}
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

	void UpdateAnimations()
	{
		animationTree.Set("parameters/Locomotion/conditions/is_moving", isMoving);
		animationTree.Set("parameters/Locomotion/conditions/idle", isIdle);



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

	public void ChangeInteractPrompt(bool inRange)
	{
		interactPrompt.Text = "<key>\n ";
		interactPrompt.Visible = false;
		base._Ready();
		var actions = InputMap.ActionGetEvents("Interact")[0];
		if (actions is InputEventKey key)
		{
			interactPrompt.Text.Replace("<key>", key.KeyLabel.ToString());
		}
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
