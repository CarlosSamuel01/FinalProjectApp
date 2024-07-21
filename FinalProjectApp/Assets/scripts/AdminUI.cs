using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    
 
    public void Consejos()
    {
        SceneManager.LoadScene("Lvl 3");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LaberintosDeCubos()
    {
        SceneManager.LoadScene("Lvl 1");
    }
    public void Race()
    {
        SceneManager.LoadScene("runner");
        
    }
    public void NumeroFaltante()
    {
        SceneManager.LoadScene("resPreguntas");
        
    }
    

    public void LoadRandomScene()
    {
        int randomIndex = Random.Range(1, 3); // Genera aleatoriamente un 1 o 2

        if (randomIndex == 1)
        {
            SceneManager.LoadScene("Lvl 2");
        }
        else
        {
            SceneManager.LoadScene("Lvl 4");
        }
    }
}
