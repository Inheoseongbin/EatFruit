using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaaaanage : MonoBehaviour
{
    public void GameRule()
    {
        SceneManager.LoadScene("SS");
    }

    public void Game()
    {
        SceneManager.LoadScene("Main");
    }
}
