using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PushWaterSO PushWater;
    public MowerSO mowerSO;
    public SlowlySO Slowly;
    public string namePlayer;

    private void Awake()
    {
        if(Instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        namePlayer = EnterNamePlayer.namePlayer;
    }

    private void Update()
    {
        namePlayer = EnterNamePlayer.namePlayer;
    }
}
