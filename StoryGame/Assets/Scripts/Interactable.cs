using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject actUI;
    [SerializeField] private GameObject player;
    [SerializeField] private float r;
    [SerializeField] public InputActionReference interact;
    [SerializeField] private LayerMask mask;

    void Awake()
    {
        actUI.SetActive(false);
    }


    void Update()
    {
        if(Physics.CheckSphere(transform.position, r, mask))
        {
            actUI.SetActive(true);
            actUI.GetComponent<TextMeshProUGUI>().text = gameObject.name;
        }
        else
        {
            actUI.SetActive(false);
        }


        if (interact.action.triggered && Physics.CheckSphere(transform.position, r, mask))
        {
            PickUp();
        }

        if (interact.action.triggered)
        {
            Debug.Log("keyWorks");
        }
    }

    public void PickUp()
    {
        if (gameObject.name == "Key")
        {
            player.GetComponent<Inventory>().hasKey = true;
        }

        player.GetComponent<Inventory>().PlusClue();
        Debug.Log("Got the item.");
        actUI.SetActive(false);
        Destroy(gameObject);
    }
}
