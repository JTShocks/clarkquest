using Godot;
using System;

public partial class QuestTracker : Control
{


	RichTextLabel title;
	VBoxContainer objectives;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		title = GetNode<RichTextLabel>("Details/Title");
		objectives = GetNode<VBoxContainer>("Details/Objectives");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
