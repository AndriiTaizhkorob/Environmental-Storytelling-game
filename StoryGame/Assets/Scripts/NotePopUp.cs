using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotePopUp : MonoBehaviour
{

    [SerializeField] private GameObject letterUI;
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private string text;

    void Awake()
    {
        letterUI.SetActive(false);
    }

    public void SetText()
    {
        if(letterUI != null)
        {
            letterUI.SetActive(true);
            letterText.text = text;
        }
        else
        {
            Debug.LogError("No UI element is set to the NotePopUp component!");
        }
    }
}
