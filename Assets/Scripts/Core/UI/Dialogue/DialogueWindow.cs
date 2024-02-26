using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Core
{public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI message;

    private Animator animator;
    private string dialogueOpenAnim = "dialogueOpen";
    private string dialogueCloseAnim = "dialogueClose";
    
    private int currentDialogueLine = 0;

    public bool IsOpen {get; private set;}
    public bool IsAnimating => animator.IsAnimating();

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // private void Update() 
    // {
    //     if (Input.GetKeyDown(KeyCode.Return))
    //     {
    //         GoToNextLine();
    //     }
    // }

    public void GoToNextLine()
    {
        Debug.Log("Going to next line");
        currentDialogueLine++;
        if (currentDialogueLine < dialogue.DialogueLines.Count)
        {

            ShowDialogueLine(dialogue.DialogueLines[currentDialogueLine]);
        }
        else
        {
            Close();
            Debug.Log("Convo over");
        }
    }

    public void Open(Dialogue dialogueToPlay)
    {
        this.dialogue = dialogueToPlay;
        currentDialogueLine = 0;
        ShowDialogueLine(dialogue.DialogueLines[currentDialogueLine]);
        animator.Play(dialogueOpenAnim);
        IsOpen = true;
    }

    private void ShowDialogueLine(DialogueLine dialogue)
    {
        portrait.sprite = dialogue.Sprite;
        speaker.text = dialogue.Speaker;
        message.text = dialogue.Message;
    }

    private void Close()
    {
        animator.Play(dialogueCloseAnim);
        Game.Manager.EndDialogue();
        IsOpen = false;
    }
    
}
}