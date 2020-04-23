using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartScript : MonoBehaviour
{
    public CinemachineVirtualCamera vcamLevelFirst;
    public void restartGame()
    {
        Time.timeScale = 1f;
        vcamLevelFirst.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
