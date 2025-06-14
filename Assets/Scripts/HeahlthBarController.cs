﻿using UnityEngine;
using UnityEngine.UI;

public class HeahlthBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;


    void Start()
    {
        heartContainers = new GameObject[(int)PlayerStats.Instance.MaxTotalHealth];
        heartFills = new Image[(int)PlayerStats.Instance.MaxTotalHealth];

        PlayerStats.Instance.onHealthChangeCallback += UpdateHeartHUD;

        InstantiateHeartContainers();
        UpdateHeartHUD();
    }

    private void UpdateHeartHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }
    private void SetHeartContainers()
    {
        for(int i=0; i<heartContainers.Length; i++)
        {
            if(i < PlayerStats.Instance.MaxHealth) { heartContainers[i].SetActive(true); }
            else {  heartContainers[i].SetActive(false);}
        }
    }

    private void SetFilledHearts()
    {
        for(int i=0;i<heartFills.Length; i++)
        {
            if (i < PlayerStats.Instance.Health) { heartFills[i].fillAmount = 1; }
            else { heartFills[i].fillAmount=0; }
        }

        if(PlayerStats.Instance.Health %1 !=0)
        {
            int lastPos = Mathf.FloorToInt(PlayerStats.Instance.Health);
            heartFills[lastPos].fillAmount = PlayerStats.Instance.Health % 1;
        }
    }
    void InstantiateHeartContainers()
    {
        for(int i=0;i<PlayerStats.Instance.MaxTotalHealth;i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent,false);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }
}
