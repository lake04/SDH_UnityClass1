using TMPro.EditorUtilities;
using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void AddHealth()
    {
        PlayerStats.Instance.AddHtealth();
    }
    public void RemoveHwalth()
    {
        PlayerStats.Instance.RemoveTealth();
    }

    public void Heal(float health)
    {
        PlayerStats.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        PlayerStats.Instance.TakeDamage(dmg);
    }

   
        
}
