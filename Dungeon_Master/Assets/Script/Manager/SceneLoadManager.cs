using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    public void SceneLoad(string scene_load_name)
    {
        SceneManager.LoadScene(scene_load_name);
    }
}