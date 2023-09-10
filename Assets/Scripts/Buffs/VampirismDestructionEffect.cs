using UnityEngine;

[CreateAssetMenu(menuName = "Effect/VampirismDestructionEffect")]
public class VampirismDestructionEffect : Buff
{
    public int VampirismDestructionForce;

    public override void Apply(Stats stats)
    {
        stats.VampirismDestruction += VampirismDestructionForce;
    }
    public override void Remove(Stats stats)
    {
        stats.VampirismDestruction -= VampirismDestructionForce;
    }
}
