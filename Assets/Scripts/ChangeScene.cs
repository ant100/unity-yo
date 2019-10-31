using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string escena;

    public void LoadSceneWithName()
    {
        SceneManager.LoadScene(escena);
    }
}
