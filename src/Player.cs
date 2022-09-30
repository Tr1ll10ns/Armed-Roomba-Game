using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    public int MaxHearts = 3;
    [Export]
    public int Hearts = 3;
    [Export]
    public int Speed_Pixels = 20;

    public override void _PhysicsProcess(float delta)
    {
        Vector2 movementVector = Vector2.Zero;

        if (Input.IsActionPressed("move_up"))
        {
            movementVector += Vector2.Up;
        }
        if (Input.IsActionPressed("move_down"))
        {
            movementVector += Vector2.Down;
        }
        if (Input.IsActionPressed("move_left"))
        {
            movementVector += Vector2.Left;
        }
        if (Input.IsActionPressed("move_right"))
        {
            movementVector += Vector2.Right;
        }

        if (movementVector != Vector2.Zero)
        {
            MoveAndSlide(Speed_Pixels * movementVector.Normalized() * 1000 * delta);
        }
    }

    public void Damage(int damage)
    {
        Hearts -= damage;
        if (Hearts <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
