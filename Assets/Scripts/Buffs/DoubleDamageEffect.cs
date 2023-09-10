using UnityEngine;

[CreateAssetMenu(menuName = "Effect/DoubleDamageEffect")]
public class DoubleDamageEffect : Buff
{
    public override void Apply(Stats stats)
    {
        stats.Damage *= 2;
    }
    public override void Remove(Stats stats)
    {
        stats.Damage /= 2;
    }
}
