using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI playerNameField;
    public string playerName;

    private void Awake()
    {
        // create singleton to carry persistent ui data
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        // don't destroy wehn loading another scene
        DontDestroyOnLoad(gameObject);
    }

    public void OnStart()
    {
        playerName = playerNameField.text;
        SceneManager.LoadScene("main");
    }

    public void OnExit()
    {
        // Conditional compiling, if run in editor it exits play mode, if run when built it quits the application
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

