using UnityEngine;

public abstract class Buff : ScriptableObject
{
    [SerializeField] private string buffName;
    [SerializeField] private int id;
    [SerializeField] private int duration;
    [SerializeField] private int remainingTime;

    public string Name { get => buffName; }

    public int Id { get => id; }

    public int Duration { get => duration; }

    public int RemainingTime { get => remainingTime; }

    public abstract void Apply(Stats stats);

    public abstract void Remove(Stats stats);

    public void DecreaseTime()
    {
        remainingTime--;
    }

    public void SetRemainingTime()
    {
        remainingTime = duration;
    }
}

