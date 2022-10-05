public abstract class Ability
{
    public abstract int Cooldown { get; set; }
    public abstract Enums.SlotType Slot { get; set; }
    public abstract void OnUse();
    public abstract void WhileHeld();
    public abstract void OnRelease();
}