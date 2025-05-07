using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public State CurrentState { get; private set; } = State.Main;
    public bool isMiniClear { get; private set; } = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SetClear(bool value)
    {
        isMiniClear = value;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainScene")
        {
            MainUIManager.Instance.ClearInfo();
        }
    }


    public void SetState(State newState)
    {
       CurrentState = newState;
    }

}
