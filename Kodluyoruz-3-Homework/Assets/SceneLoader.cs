using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class SceneLoader 
{
    public static void Load(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public enum Scenes
    {
        Gamescene,
        RestartScene,
        MenuScene
    }

    
}

