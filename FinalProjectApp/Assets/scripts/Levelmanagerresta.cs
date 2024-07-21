using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levelmanagerresta : MonoBehaviour
{
    public string nextlevel;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneManager.LoadScene(nextlevel);

        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReacheadIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevelr", PlayerPrefs.GetInt("UnlockedLevelr", 1) + 1);
            PlayerPrefs.Save();
        }
    }

}
