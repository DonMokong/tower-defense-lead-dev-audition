using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillImage;

    public void SetHealth(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }
}