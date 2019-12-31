using System;
using System.Collections;
using System.Collections.Generic;
using eidng8.SpaceFlight.Managers;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


// A behaviour that is attached to a playable
public class Startup : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.Gm.SceneLoaded(scene, mode);
    }
}
