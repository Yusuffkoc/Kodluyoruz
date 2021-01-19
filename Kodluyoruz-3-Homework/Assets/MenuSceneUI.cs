using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backSettingsPanelButton;

    [SerializeField] private GameObject settingsPanel;

    void Start()
    {
        startButton.onClick.AddListener(LoadGameScene);
        settingsButton.onClick.AddListener(LoadSettingsPanel);
        exitButton.onClick.AddListener(Exit);
        backSettingsPanelButton.onClick.AddListener(UnLoadSettingsPanel);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void LoadSettingsPanel()
    {
        settingsPanel.SetActive(true);
        startButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    private void UnLoadSettingsPanel()
    {
        settingsPanel.SetActive(false);
        startButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    private void LoadGameScene()
    {
        SceneLoader.Load(SceneLoader.Scenes.Gamescene);
    }
}
