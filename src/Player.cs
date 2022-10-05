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
    [Export]
    public float RotationInterpolationRate = 0.1f;

    public Ability Ability1;
    public Ability Ability2;
    public Ability Ability3;

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
            GlobalRotation = Mathf.LerpAngle(GlobalRotation, Vector2.Right.AngleTo(movementVector), RotationInterpolationRate);
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
