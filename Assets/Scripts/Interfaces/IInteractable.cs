using Godot;
using Godot.Collections;
using System;

public partial interface IInteractable
{
    bool isSelected {get; set;}

    bool Interact();

    void Interact(Interactor interactor);
    void OnSelect();
    void OnDeselect();
}
