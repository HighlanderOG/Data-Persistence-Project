using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_Text score;
    public TMP_Text userName;

    public void UsernameSet(string newUsername)
    {
        DataStoring.Instance.username = newUsername;
        userName.text = "Name: " + newUsername;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameField.onEndEdit.AddListener(UsernameSet);
        LoadData();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataStoring.Instance.SaveUserData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveData()
    {
        DataStoring.Instance.SaveUserData();
    }

    public void LoadData()
    {
        DataStoring.Instance.LoadUserData();
        userName.text = "Name: " + DataStoring.Instance.username;
        score.text = "Score: " + DataStoring.Instance.hi.ToString();
    }
}
