using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{

    private GameManager gameManager;
    public string choiceText;
    public string choiceA;
    public string choiceB;
    public bool choiceACorrect;
    public bool hasSelected;
    public int endingNumber;
    public string alreadySelectedMessage;
    public string notReadyYetMessage;
    public bool isReady;
    public bool noButtons;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(bool choiceACorrect)
    {
        if (this.choiceACorrect != choiceACorrect)
        {
            gameManager.endingNumber = endingNumber;
        }
        gameManager.StageUp();
        hasSelected = true;
        InteractiveItem [] items = FindObjectsOfType<InteractiveItem>();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].endingNumber == endingNumber + 1)
            {
                items[i].isReady = true;
            }
        }
    }
}
