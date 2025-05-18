using Godot;
using System;
using Game.Component;

public partial interface IEntity
{

    //An interface to determine if a thing can be affected by potions/ has the health we want to apply to it

    float moveSpeed {get;set;}          
    HealthComponent health  {get;set;} //All entities must have a health component


}
