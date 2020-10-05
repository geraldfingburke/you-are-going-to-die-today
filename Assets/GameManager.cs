using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage;
    public int endingNumber;
    private UIHandler uIHandler;
    public bool choosing;
    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        endingNumber = 0;
        uIHandler = FindObjectOfType<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageUp()
    {
        stage++;
    }

    public void EndGame()
    {
        if (endingNumber == 0)
        {
            endingNumber = 6;
        }
        string endMessage = "";

        switch (endingNumber)
        {
            case 1:
                endMessage = "Skipping breakfast gave you a bad case of the hungries. You thought you could make it to lunch, but the smell wafting over to you from the taqueria next to your office is irresistable. You pop in for a breakfast burrito and wolf it down in fewer bites than you should tell any potential partner. Suddenly you're overcome with the worst pain you've ever experienced. The last thing you hear before you fade out is the doctor's excited murmuring about a new strain of \"Flash Food Poisoning\".";
                break;
            case 2:
                endMessage = "A coworker you rarely speak to has sent you an email. She wants to meet for coffee at a local cafe you've never heard of. When you arrive, the cafe seems abandonded. As you enter, you realize it is abandoned. You see a makeshift medical station setup in what used to be the kitchen. You turn to leave, but you feel a small sting in your neck. The world goes black.";
                break;
            case 3:
                endMessage = "Your roommate reads the note and becomes irate. It's the third time this week you've left him a note to clean a mess that you made. He packs up his room and leaves in a huff, 'forgetting' to close the front door behind him. At work, you hear a report of a bear being spotted in your neighborhood. You should be careful on your way home. When you get home, you find your door ajar. Your pesky roommate must have left it open. You sit down for a beer on your new sofa, when you hear a growling coming from beneath you. You look down to realize you do not, in fact, have a new sofa. The bear mauls you, but in a final gesture of true composure, you manage to die without spilling your beer.";
                break;
            case 4:
                endMessage = "A nice hot shower leaves you feeling fresh and confident. As you're crossing the street, an attractive woman waves at you. You give her a smile and a wink as you're struck down by the bus she was trying to warn you about.";
                break;
            case 5:
                endMessage = "You put on your flashy new Unity hoody that you bought from the Unity store. On your way back to the office from lunch, you run into a gang of skinheads covered in Unreal Engine tattoos. They see your Unity hoody and jump you, leaving you to bleed out on the pavement. ";
                break;
            case 6:
                endMessage = "You manage to slog through your day with a sneaking suspicion that something is terribly wrong. In spite of this, you seem to make it home in one piece. Maybe tomorrow will be better.";
                break;
        }

        uIHandler.StartCoroutine("PrintEndMessage",endMessage);
        Invoke("ReloadScene", 60);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
