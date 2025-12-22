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

    private bool found = false;

    void Awake()
    {
        actUI.GetComponent<TextMeshProUGUI>().text = "";
        actUI.SetActive(false);
    }


    void Update()
    {
        if (interact.action.triggered && name == actUI.GetComponent<TextMeshProUGUI>().text && !found)
        {
            Interaction();
            found = true;
        }
    }

    private void OnTriggerEnter(Collider zone)
    {
        actUI.SetActive(true);

        if (actUI.GetComponent<TextMeshProUGUI>().text.Length <= 0)
        {
            actUI.GetComponent<TextMeshProUGUI>().text = gameObject.name;
            Debug.Log($"Name changed " + name + ".");
        }
    }

    private void OnTriggerExit(Collider zone)
    {
        actUI.GetComponent<TextMeshProUGUI>().text = "";
        actUI.SetActive(false);
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
        {
            actUI.GetComponent<TextMeshProUGUI>().text = "";
            actUI.SetActive(false);
            Destroy(gameObject);
        }
    }
}
