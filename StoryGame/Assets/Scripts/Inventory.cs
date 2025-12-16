using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InputActionReference pause;
    [SerializeField] private TextMeshProUGUI clueCounter;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject gameTip;

    private int clueCount = 0;
    private int clueCountGoal;

    [HideInInspector] public bool hasKey = false;

    void Awake()
    {
        gameEnd.SetActive(false);
        gameTip.SetActive(false);
        clueCountGoal = GameObject.FindGameObjectsWithTag("Clue").Length;
    }

    void Update()
    {
        clueCounter.text = clueCount + "/" + clueCountGoal;

        if (gameEnd.activeInHierarchy)
        {
            gameTip.SetActive(false);
        }
        else if (!gameEnd.activeInHierarchy && clueCount == clueCountGoal)
        {
            gameTip.SetActive(true);
        }

        if (pause.action.triggered)
            PauseMenu();
    }

    public void PlusClue()
    {
        clueCount++;
        PauseMenu();
    }

    public void PauseMenu()
    {
        if (clueCount == clueCountGoal)
        {
            Cursor.lockState = CursorLockMode.None;
            gameEnd.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<CameraControls>().enabled = false;
        }
    }

    public void SetControllsActive()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<CameraControls>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
