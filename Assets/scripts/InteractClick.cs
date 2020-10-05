using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractClick : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audio;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameManager.choosing)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.GetComponentInParent<InteractiveItem>() != null)
                {
                    UIHandler uiHandler = FindObjectOfType<UIHandler>();
                    InteractiveItem item = hit.collider.GetComponentInParent<InteractiveItem>();
                    if (item.isReady && !item.hasSelected)
                    {
                        gameManager.choosing = true;
                        uiHandler.buttons.alpha = 1;
                        uiHandler.choiceAbtn.GetComponentInChildren<Text>().text = item.choiceA;
                        uiHandler.choiceBbtn.GetComponentInChildren<Text>().text = item.choiceB;
                        uiHandler.SetMessageText(item.choiceText);
                        audio.clip = item.clip;
                        audio.Play();
                        if (item.noButtons)
                        {
                            uiHandler.choiceAbtn.gameObject.SetActive(false);
                            uiHandler.choiceBbtn.gameObject.SetActive(false);
                        }
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        if (gameManager.stage == 5 && item.endingNumber == 6)
                        {
                            gameManager.EndGame();
                        }
                    }
                }
            }

        }
        
    }
}
