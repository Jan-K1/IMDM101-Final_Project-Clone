using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public String sceneToLoad;
      public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Exit"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}
