using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class minigameRmanager : MonoBehaviour
{
    public int maxNumber = 100;
    public int currentSum = 100;
    public Text sumText;
    

    void Update()
    {
        sumText.text = "Resta: " + currentSum + "/" + maxNumber;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Block block = hit.transform.GetComponent<Block>();
                if (block != null)
                {
                    AddNumber(block.number);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    public void AddNumber(int number)
    {
        currentSum -= number;
        if (currentSum < 0)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
