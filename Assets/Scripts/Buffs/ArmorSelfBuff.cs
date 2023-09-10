using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ArmorSelfEffect")]
public class ArmorSelfBuff : Buff
{
    public int Armor;

    public override void Apply(Stats stats)
    {
        stats.Armor += Armor;
    }
    public override void Remove(Stats stats)
    {
        stats.Armor -= Armor;
    }
}
