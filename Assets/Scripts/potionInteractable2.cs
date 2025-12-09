using UnityEngine;

public class potionInteractable2 : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        // Get the player's status component
        PlayerStatus status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();

        // Set that the player now has the potion
        status.hasPotion2 = true;


        Destroy(gameObject);
    }
}
