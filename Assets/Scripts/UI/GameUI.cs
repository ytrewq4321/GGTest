using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundCounter;
    [SerializeField] private Button restartButton;

    public void SetRoundCount(int count)
    {
        roundCounter.text = StringArray.Values[count];
    }

    public void AddRestartButtonListener(UnityAction action)
    {
        restartButton.onClick.AddListener(action);
    }
    public void RemoveRestartButtonListener(UnityAction action)
    {
        restartButton.onClick.RemoveListener(action);
    }
}
