using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public TextMeshProUGUI textBox;

    private Story story;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if(story.canContinue)
        {
            textBox.gameObject.SetActive(true);
            textBox.text = story.Continue();
        }
        else{
            FinishDialogue();
        }
    }

    private void FinishDialogue()
    {
        textBox.gameObject.SetActive(false);
    }
}
