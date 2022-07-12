using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Utilities
{
    public static int playerDeath = 0;
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return "Next time you'll be at number " + countReference;
    }
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Debug.Log("Player death: " + playerDeath);
        string messege = UpdateDeathCount(ref playerDeath);
        Debug.Log("Player death: " + playerDeath);
    }
    public static bool RestartLevel(int sceneIndex)

    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
