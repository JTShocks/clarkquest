using Godot;
using System;

public partial class QuestUI : Control
{
	Panel questPanel;
	HBoxContainer questList;
	RichTextLabel questTitle;
	RichTextLabel questDescription;
	HBoxContainer questObjectives;
	HBoxContainer questRewards;

	public override void _Ready()
	{
		base._Ready();
		//Set all the UI elements
		questPanel = GetNode<Panel>("CanvasLayer/Panel");
		questList = GetNode<HBoxContainer>("CanvasLayer/Panel/Contents/Details/QuestList");
		questTitle = GetNode<RichTextLabel>("CanvasLayer/Panel/Contents/Details/QuestDetails/QuestTitle");
		questDescription = GetNode<RichTextLabel>("CanvasLayer/Panel/Contents/Details/QuestDetails/QuestDescription");
		questObjectives = GetNode<HBoxContainer>("CanvasLayer/Panel/Contents/Details/QuestDetails/QuestObjectives");
		questRewards = GetNode<HBoxContainer>("CanvasLayer/Panel/Contents/Details/QuestDetails/QuestRewards");
    }

}
