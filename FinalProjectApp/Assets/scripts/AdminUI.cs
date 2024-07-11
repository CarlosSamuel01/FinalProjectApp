using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    
    public void Minijuegosuma()
    {
        SceneManager.LoadScene("Lvl 2");
    }
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
}
