using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IAttackable
{
    [SerializeField] private StatsSO statsSO;

    private PlayerVisualization playerVisualization;
    private BuffHandler buffHandler;
    private Player target;
    private Stats stats;

    public void Initialize(List<Buff> effects, Player target)
    {
        playerVisualization = GetComponent<PlayerVisualization>();
        stats = new Stats(statsSO.Health, statsSO.Armor, statsSO.Vampirism, statsSO.Damage);
        buffHandler = new BuffHandler(stats, effects);
        this.target = target;
    }

    public void Attack()
    {
        var damageTaken = target.TakeAttack(stats.Attack);
        LifeSteal(damageTaken);
    }

    public void ApplyBuff()
    {
        buffHandler.TryApplyBuff();
    }

    public void LifeSteal(float damage)
    {
        stats.Health += (int)((float)stats.Vampirism / 100 * damage);
    }

    public int TakeAttack(Attack attack)
    {
        var damageTaken = attack.Damage - (int)((float)stats.Armor / 100 * attack.Damage);
        stats.Health -= damageTaken;
        stats.Armor -= attack.ArmorDestruction;
        stats.Vampirism -= attack.VampirismDesturction;

        playerVisualization.ChangeColor();

        Tick();

        return damageTaken;
    }

    public void Tick()
    {
        buffHandler.Tick();
    }

    public void SetupStats()
    {
        stats.InvokeEvents();
    }

    public void AddHealthListener(Action<int, int> action)
    {
        stats.HealthChanged += action;
    }

    public void AddArmorListener(Action<int, int> action)
    {
        stats.ArmorChanged += action;
    }

    public void AddVampirismListener(Action<int, int> action)
    {
        stats.VampirismChanged += action;
    }

    public void AddBuffDurationListener(Action<int, int> action)
    {
        buffHandler.BuffDurationChanged += action;
    }

    public void AddBuffListener(Action<string, int, int> action)
    {
        buffHandler.BuffApplied += action;
    }

    public void RemoveHealthListener(Action<int, int> action)
    {
        stats.HealthChanged += action;
    }

    public void RemoveArmorListener(Action<int, int> action)
    {
        stats.ArmorChanged += action;
    }

    public void RemoveVampirismListener(Action<int, int> action)
    {
        stats.VampirismChanged += action;
    }

    public void RemoveBuffDurationListener(Action<int, int> action)
    {
        buffHandler.BuffDurationChanged += action;
    }

    public void RemoveBuffListener(Action<string, int, int> action)
    {
        buffHandler.BuffApplied += action;
    }
}
