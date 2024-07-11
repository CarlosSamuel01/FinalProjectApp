using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminBanner : MonoBehaviour
{
    private float timer = 0f;
    private float disableTime = 5f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= disableTime)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
