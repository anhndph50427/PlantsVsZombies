using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject parent;
    [Header("UI info")]
    [SerializeField] private Button Login;
    [SerializeField] private Button Register;
    [SerializeField] private Button Back;

    [Header("GameObjet")]
    [SerializeField] private GameObject LoginObj;
    [SerializeField] private GameObject RegisterObj;
    void Start()
    {
        Login.onClick.AddListener(() => login());
        Register.onClick.AddListener(() => Registers());
        Back.onClick.AddListener(() => back());

    }

    private void Update()
    {
        if(parent.activeInHierarchy)
        {
            Back.gameObject.SetActive(false);
        }
        else
        {
            Back.gameObject.SetActive(true);
        }
    }

    void login()
    {
        LoginObj.SetActive(true);
        parent.SetActive(false);
    }

    void Registers()
    {
        RegisterObj.SetActive(true);
        parent.SetActive(false);
    }

    void back()
    {
        parent.SetActive(true);
        LoginObj.SetActive(false);
        RegisterObj.SetActive(false);
    }
    
}
