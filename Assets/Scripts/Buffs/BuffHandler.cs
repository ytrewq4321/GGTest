using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Linq;

public class BuffHandler
{
    public List<Buff> buffList = new();
    public List<Buff> activeBuffList=new();

    public Action<int,int> BuffDurationChanged;
    public Action<string,int,int> BuffApplied;

    private Stats stats;

    public BuffHandler(Stats stats, List<Buff> buffs)
    {
        this.stats = stats;

        for (int i = 0; i < buffs.Count; i++)
        {
            Buff newEffect = ScriptableObject.CreateInstance(buffs[i].GetType()) as Buff;
            EditorUtility.CopySerialized(buffs[i], newEffect);
            buffList.Add(newEffect);
        }
    }

    public Buff GetRandomBuff()
    {
        var availableBuffs = buffList.Except(activeBuffList).ToList();

        if (availableBuffs.Count == 0)
        {
            return null;
        }

        return availableBuffs[UnityEngine.Random.Range(0, availableBuffs.Count)];
    }


    public void TryApplyBuff()
    {
        if (activeBuffList.Count < 2)
        {
            Buff buff = GetRandomBuff();

            activeBuffList.Add(buff);
            buff.Apply(stats);
            buff.SetRemainingTime();
            BuffApplied?.Invoke(buff.Name,buff.Id,buff.Duration);
        }
    }

    public void Tick()
    {
        int count = activeBuffList.Count;
        for (int i = 0; i < count; i++)
        {
            if (activeBuffList[i]!=null)
            {
                activeBuffList[i].DecreaseTime();
                BuffDurationChanged?.Invoke(activeBuffList[i].Id, activeBuffList[i].RemainingTime);

                if (activeBuffList[i].RemainingTime == 0)
                {
                    activeBuffList[i].Remove(stats);
                    activeBuffList[i] = null;
                }
            }         
        }
        activeBuffList.RemoveAll(item => item == null);
    }
}
