using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] public string gameScene;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }
}
