using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Stats 
{
    public readonly int MaxHealth;
    public readonly int MaxArmor;
    public readonly int MaxVampirism;

    private int armor;
    private int vampirism;
    private int health;
    private int damage;

    private int armorDestruction;
    private int vampirismDestruction;

    public event Action<int, int> HealthChanged;
    public event Action<int, int> ArmorChanged;
    public event Action<int, int> VampirismChanged;

    public Attack Attack
    {
        get
        {
            return new Attack
            {
                Damage = damage,
                ArmorDestruction = armorDestruction, 
                VampirismDesturction = vampirismDestruction 
            };
        } 
    }

    public int Health
    {
        get { return health; }
        set
        { 
            health = Mathf.Clamp(value, 0, MaxHealth);
            if(health<=0)
            {
                SceneManager.LoadScene(0);
            }
            HealthChanged?.Invoke(health,MaxHealth);
        }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Armor
    {
        get { return armor; }
        set
        { 
            armor = Mathf.Clamp(value, 0, MaxArmor);
            ArmorChanged?.Invoke(armor,MaxArmor);
        }
    }

    public int Vampirism
    {
        get { return vampirism; }
        set
        { 
            vampirism = Mathf.Clamp(value, 0, MaxVampirism);
            VampirismChanged?.Invoke(vampirism,MaxVampirism);
        }
    }

    public int ArmorDestruction
    {
        get { return armorDestruction; }
        set { armorDestruction = value; }
    }

    public int VampirismDestruction
    {
        get { return vampirismDestruction; }
        set { vampirismDestruction = value; }
    }

    public void InvokeEvents()
    {
        HealthChanged.Invoke(health,MaxHealth);
        ArmorChanged.Invoke(armor,MaxArmor);
        VampirismChanged.Invoke(vampirism,MaxVampirism);
    }

    public Stats(int maxHealth, int armor, int vampirism, int damage)
    {
        MaxHealth = maxHealth;
        health = maxHealth;

        MaxArmor = 100;
        this.armor = armor;

        MaxVampirism = 100;
        this.vampirism = vampirism;

        this.damage = damage;
    }
}
