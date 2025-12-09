using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        Debug.Log("CLicked");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Dungeon_Demo");
        Debug.Log("CLicked 2");
    }
}
