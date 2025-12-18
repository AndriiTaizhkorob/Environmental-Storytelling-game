using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject actUI;
    [SerializeField] private GameObject player;
    [SerializeField] private InputActionReference interact;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float r;
    [SerializeField] private bool destroy;

    private string textUI;

    void Awake()
    {
        actUI.GetComponent<TextMeshProUGUI>().text = "";
        actUI.SetActive(false);
    }


    void Update()
    {
        if(Physics.CheckSphere(transform.position, r, mask))
        {
            actUI.SetActive(true);

            if(actUI.GetComponent<TextMeshProUGUI>().text.Length <= 0)
                actUI.GetComponent<TextMeshProUGUI>().text = gameObject.name;
        }
        else
        {
            actUI.GetComponent<TextMeshProUGUI>().text = "";
            actUI.SetActive(false);
        }


        if (interact.action.triggered && Physics.CheckSphere(transform.position, r, mask) && name == actUI.GetComponent<TextMeshProUGUI>().text)
        {
            Interaction();
        }
    }

    public void Interaction()
    {
        if (name == "Key")
            player.GetComponent<Inventory>().hasKey = true;

        if (GetComponent<NotePopUp>())
        { 
            GetComponent<NotePopUp>().SetText();
            player.GetComponent<Inventory>().SetControllsInactive();
        }

        if (CompareTag("Clue"))
            player.GetComponent<Inventory>().PlusClue();
        
        actUI.SetActive(false);

        if(destroy)
            Destroy(gameObject);
    }
}
