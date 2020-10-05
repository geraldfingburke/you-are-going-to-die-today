using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text messageText;
    public Text mainText;
    public Text endingText;
    [Range(.05f, .5f)]
    public float scrollSpeed;
    [Range(1,3)]
    public float messageLife;
    public Button choiceAbtn;
    public Button choiceBbtn;
    private GameManager gameManager;
    public CanvasGroup buttons;
    public bool currentChoice;

    public void Start()
    {
        StartCoroutine("PermanentMessage", "Hello, this is your inner narrator. You are going to die today. You are going to die every day, for the rest of time. You may want to try eating something.");
        gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdatePermanentMessage()
    {
        StopCoroutine("PermanentMessage");
        switch (gameManager.stage)
        {
            case 1:
                StartCoroutine("PermanentMessage", "You should check your computer. Might find something important.");
                break;
            case 2:
                StartCoroutine("PermanentMessage", "There's a mess in the house. Maybe your roommate could do something about it.");
                break;
            case 3:
                StartCoroutine("PermanentMessage", "You smell quite badly. Do you want to go to work smelling badly?");
                break;
            case 4:
                StartCoroutine("PermanentMessage", "If you go to work naked, they may fire you.");
                break;
            case 5:
                StartCoroutine("PermanentMessage", "Time to go. Better hope you did everything right.");
                break;

        }
    }

    public void SetMessageText(string message)
    {
        StopCoroutine("DisplayMessage");
        messageText.text = "";
        StartCoroutine("DisplayMessage", message);
    }

    IEnumerator DisplayMessage (string message)
    {
        string renderedString = "";
        for (int i = 0; i < message.Length; i++)
        {
            messageText.text += message[i];
            yield return new WaitForSeconds(scrollSpeed);
        }
        yield return new WaitForSeconds(messageLife);
        messageText.text = "";
    }

    IEnumerator PermanentMessage(string message)
    {
        mainText.text = "";
        string renderedString = "";
        for (int i = 0; i < message.Length; i++)
        {
            mainText.text += message[i];
            yield return new WaitForSeconds(scrollSpeed);
        }
    }

    IEnumerator PrintEndMessage(string message)
    {
        string renderedString = "";
        for (int i = 0; i < message.Length; i++)
        {
            endingText.text += message[i];
            yield return new WaitForSeconds(scrollSpeed);
        }
    }

    public void ButtonClick (bool choiceA)
    {
        InteractiveItem[] items = FindObjectsOfType<InteractiveItem>();

        gameManager.choosing = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        buttons.alpha = 0;

        for (int i = 0; i < items.Length; i++)
        {
            if (gameManager.stage + 1 == items[i].endingNumber)
            {
                Debug.Log(items[i].endingNumber);

                InteractiveItem item = items[i];
                if (item.choiceACorrect != choiceA && gameManager.endingNumber == 0)
                {
                    gameManager.endingNumber = item.endingNumber;
                }
                item.hasSelected = true;

            }
            if (gameManager.stage + 2 == items[i].endingNumber)
            {
                InteractiveItem item = items[i];
                item.isReady = true;
            }
        }
        gameManager.StageUp();
        UpdatePermanentMessage();
    }
}
