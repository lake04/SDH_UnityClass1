using System;
using System.Dynamic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangeDelegate();
    public OnHealthChangeDelegate onHealthChangeCallback;

    #region Sigelton
    private static PlayerStats instance; //외부에서 변환이 안되기 위해
    public static PlayerStats Instance //외부에서 instanc 읽어오기
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<PlayerStats>();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get {return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    public void AddHtealth()
    {
        if(maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangeCallback != null)
                onHealthChangeCallback.Invoke();
        }
    }

    public void RemoveTealth()
    {
        if (1 < maxHealth)
        {
            maxHealth -= 1;
            health = maxHealth;

            if (onHealthChangeCallback != null)
                onHealthChangeCallback.Invoke();
        }
    }

    private void ClampHealth()
    {
        health = Math.Clamp(health, 0.0f, maxHealth);

        if (onHealthChangeCallback != null)
            onHealthChangeCallback.Invoke();
    }
    

}
