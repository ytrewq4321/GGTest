using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ArmorDestructionEffect")]
public class ArmorDestructionBuff : Buff
{
    public int ArmorDestructionForce;

    public override void Apply(Stats stats)
    {
        stats.ArmorDestruction += ArmorDestructionForce;
    }
    public override void Remove(Stats stats)
    {
        stats.ArmorDestruction -= ArmorDestructionForce;
    }
}
