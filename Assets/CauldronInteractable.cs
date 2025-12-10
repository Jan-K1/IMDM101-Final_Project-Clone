using UnityEngine;

public class CauldronInteractable : MonoBehaviour
{
    [SerializeField] private GameObject specialPotionPrefab;
    [SerializeField] private Transform holdPoint;   // Where potion will appear (on camera)

    private bool triggerActive = false;
    private bool specialPotionGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            triggerActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            triggerActive = false;
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            TryMakeSpecialPotion();
        }
    }

    void TryMakeSpecialPotion()
    {
        if (specialPotionGiven)
            return; // prevents duplicates

        PlayerStatus status = GameObject.FindGameObjectWithTag("Player")
                                        .GetComponent<PlayerStatus>();

        if (status.hasPotion1 && status.hasPotion2)
        {
            specialPotionGiven = true;

            // Spawn potion as child of camera
            GameObject potion = Instantiate(specialPotionPrefab, holdPoint);

            potion.transform.localPosition = Vector3.zero;
            potion.transform.localRotation = Quaternion.identity;

            // Remove any potion physics
            Rigidbody rb = potion.GetComponent<Rigidbody>();
            if (rb) Destroy(rb);

            Collider c = potion.GetComponent<Collider>();
            if (c) Destroy(c);

            Debug.Log("Special potion created and attached!");
        }
        else
        {
            Debug.Log("You don't have both potions!");
        }
    }
}
