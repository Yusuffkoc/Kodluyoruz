using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    void Start()
    {
        restartButton.onClick.AddListener(LoadMenu);
    }

    private void LoadMenu()
    {
        SceneLoader.Load(SceneLoader.Scenes.MenuScene);
    }
    
}
