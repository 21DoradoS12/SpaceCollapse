using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadGame : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
