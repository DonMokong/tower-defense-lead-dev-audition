using UnityEngine;

public class MouseClickDamage : MonoBehaviour
{
    public float clickDamage = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(clickDamage);
            }
        }
    }
}