using System.Collections;
using UnityEngine;

public class PlayerVisualization : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Color damageColor;
    [SerializeField] private Color startColor;
    [SerializeField] private float colorChangeDuration;

    private void Awake()
    {
         startColor = material.color;
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        float time = 0f;

        while (time < colorChangeDuration)
        {
            time += Time.deltaTime;
            material.color = Color.Lerp(startColor, damageColor, time / colorChangeDuration);
            yield return null;
        }
        material.color = damageColor;

        time = 0;

        while (time < colorChangeDuration)
        {
            time += Time.deltaTime;
            material.color = Color.Lerp(damageColor, startColor, time / colorChangeDuration);
            yield return null;
        }
        material.color = startColor;
    }

    private void OnDestroy()
    {
        material.color = startColor;
    }
}
