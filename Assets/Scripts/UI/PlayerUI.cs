using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image healthBar; 
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Image armorBar;
    [SerializeField] private TextMeshProUGUI armorText;

    [SerializeField] private Image vampirismBar;
    [SerializeField] private TextMeshProUGUI vampirismText;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button buffButton;

    [SerializeField] private List<BuffUI> buffs;

    public void SetHealthBar(int value, int maxValue)
    {
        healthBar.fillAmount = (float)value/maxValue;
        healthText.text = StringArray.Values[value];
    }

    public void SetArmorBar(int value, int maxValue)
    {
        armorBar.fillAmount = (float)value / maxValue;
        armorText.text = StringArray.Values[value];
    }

    public void SetVampirirsmBar(int value, int maxValue)
    {
        vampirismBar.fillAmount = (float)value / maxValue;
        vampirismText.text = StringArray.Values[value];
    }

    public void AddListenerAttackButton(UnityAction action)
    {
        attackButton.onClick.AddListener(action);
    }

    public void AddListenerBuffButton(UnityAction action)
    {
        buffButton.onClick.AddListener(action);
    }

    public void RemoveListenerAttackButton(UnityAction action)
    {
        attackButton.onClick.RemoveListener(action);
    }

    public void RemoveListenerBuffButton(UnityAction action)
    {
        buffButton.onClick.RemoveListener(action);
    }

    public void SetButtonInteractable(bool value)
    {
        attackButton.interactable = value;
        buffButton.interactable = value;
    }

    public void SetBuff(string name, int id, int duration)
    {
        foreach (var buffUI in buffs)
        {
            if(!buffUI.IsSetuped)
            {
                buffUI.Setup(name, StringArray.Values[duration],id);
                break;
            }
        }
    }

    public void UpdateBuffUI(int id, int duration)
    {
        foreach (var buffUI in buffs)
        {
            if (buffUI.Id==id)
            {
                if(duration==0)
                {
                    buffUI.Remove();
                }
                else
                {
                    buffUI.UpdateDuration(StringArray.Values[duration]);
                }
            }
        }
    }
}
