using UnityEngine;

[CreateAssetMenu(menuName = "Effects/VampirismSelfEffect")]
public class VampirismSelfEffect : Buff
{
    public int Vampirism;
    public int Armor;

    public override void Apply(Stats stats)
    {
        stats.Vampirism += Vampirism;
        stats.Armor += Armor;
    }
    public override void Remove(Stats stats)
    {
        stats.Vampirism -= Vampirism;
    }
}
