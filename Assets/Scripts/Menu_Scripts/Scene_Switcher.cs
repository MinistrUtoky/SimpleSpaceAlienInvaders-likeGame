using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switcher : MonoBehaviour
{
    [SerializeField]
    private int sceneNumber;
    public void ScreenSwitching()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
