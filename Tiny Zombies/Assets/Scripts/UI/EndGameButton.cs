using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    void Start()
    {
        _sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }
    public void ExitLevel()
    {
        if(_sceneLoader != null)
        {
            _sceneLoader.LoadScene(0);
        }
    } 
}
