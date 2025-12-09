using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GameOverScreen;



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameOverScreen.SetActive(true);
            //Time.timeScale = 0f;
        }

    }
}
