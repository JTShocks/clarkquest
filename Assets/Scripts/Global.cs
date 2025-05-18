using Godot;
using System;

public partial class Global : Node
{
	public static PlayerController player = null;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Global has loaded");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
