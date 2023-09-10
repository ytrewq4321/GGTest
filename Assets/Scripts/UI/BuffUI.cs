using UnityEngine;
using TMPro;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI durationText;

    public bool IsSetuped { get; private set; }

    public int Id { get; private set; }

    public void UpdateDuration(string value)
    {
        durationText.text = value;
    }

    public void Setup(string name, string value,int id)
    {
        nameText.text = name;
        durationText.text = value;
        Id = id;
        IsSetuped = true;
    }

    public void Remove()
    {
        nameText.text = null;
        durationText.text = null;
        Id = -1;
        IsSetuped = false;
    }
}
