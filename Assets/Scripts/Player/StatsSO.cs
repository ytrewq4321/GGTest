using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PlayerStats/PlayerStats")]
public class StatsSO : ScriptableObject
{
    [SerializeField, Range(0, 100)] private int armor;
    [SerializeField, Range(0, 100)] private int vampirism;
    [SerializeField] private int health;
    [SerializeField] private int damage;

    public int Armor { get { return armor; } }
    public int Damage { get { return damage; } }
    public int Health { get { return health; } }
    public int Vampirism { get { return vampirism; } }
}
