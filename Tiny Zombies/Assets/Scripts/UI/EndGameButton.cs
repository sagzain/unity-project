using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private GameObject _musicManager;

    void Start()
    {
        _sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        _musicManager = GameObject.Find("MusicManager");
    }
    public void ExitLevel()
    {
        if(_sceneLoader != null)
        {
            _sceneLoader.LoadScene(0);
            Destroy(_sceneLoader.gameObject);
            Destroy(_musicManager);
        }
    } 
}
