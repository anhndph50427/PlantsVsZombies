using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterNamePlayer : MonoBehaviour
{
    public static string namePlayer;
    [SerializeField] private TMP_InputField enterName;
    void Start()
    {
        namePlayer = enterName.text;
    }

    private void Update()
    {
        namePlayer = enterName.text;
    }
}
