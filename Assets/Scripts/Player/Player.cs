using Godot;
using System;


public partial class Player : CharacterBody2D, IDamageable
{
    const int MOVE_SPEED = 300;
    RayCast2D raycast;

    public override void _Ready()
    {
        raycast = GetNode<RayCast2D>("RayCast2D");
        //await(GetTree(), "idle_frame");
    }

    public override void _PhysicsProcess(double delta)
    {
        var moveVector = new Vector2();

        if(Input.IsActionPressed("move_up"))
        {
            moveVector.Y -= 1;
        }
        if(Input.IsActionPressed("move_down"))
        {
            moveVector.Y += 1;
        }
        if(Input.IsActionPressed("move_left"))
        {
            moveVector.X -= 1;
        }
        if(Input.IsActionPressed("move_right"))
        {
            moveVector.X += 1;
        }

        moveVector.Normalized();
        MoveAndCollide(moveVector * (float)(MOVE_SPEED * delta));

        var lookVector = GetGlobalMousePosition() - GlobalPosition;
        GlobalRotation = Mathf.Atan2(lookVector.Y, lookVector.X);

        if(Input.IsActionJustPressed("shoot"))
        {
            var col = raycast.GetCollider();
            ;
            if(raycast.IsColliding())
            {
                if(col is IDamageable damageable)
                {
                    damageable.TakeDamage(1);
                }
            }
        }
    }
    public void TakeDamage(int amount)
    {
        if(amount > 0)
        Kill();
    }
    public void Kill()
    {
        GetTree().ReloadCurrentScene();
    }
}
