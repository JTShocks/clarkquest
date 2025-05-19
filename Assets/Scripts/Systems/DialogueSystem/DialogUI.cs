using Godot;
using System;

public partial class DialogUI : Control
{

    Panel panel;
    RichTextLabel dialogSpeaker;
    RichTextLabel dialogText;
    HBoxContainer dialogOptions;

    public override void _Ready()
    {
        base._Ready();
        panel = GetNode<Panel>("CanvasLayer/Panel");
        dialogSpeaker = GetNode<RichTextLabel>("CanvasLayer/Panel/DialogBox/DialogSpeaker");
        dialogText = GetNode<RichTextLabel>("CanvasLayer/Panel/DialogBox/DialogText");
        dialogOptions = GetNode<HBoxContainer>("CanvasLayer/Panel/DialogBox/DialogOptions");

    }


}
