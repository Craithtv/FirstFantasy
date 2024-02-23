using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private DialogueScene scene;
    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI message;

    private Animator animator;
    private string dialogueOpenParam = "dialogueOpen";

    private int currentSceneDialogueIndex = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentSceneDialogueIndex++;
            if (currentSceneDialogueIndex < scene.Dialogues.Count)
            { 
                DisplayDialogue(scene.Dialogues[currentSceneDialogueIndex]);
            }
            else
            {
                Close();
                Debug.Log("Convo over");
            }
        }
    }

    public void Open(DialogueScene sceneToPlay)
    {
        scene = sceneToPlay;
        currentSceneDialogueIndex = 0;
        DisplayDialogue(scene.Dialogues[currentSceneDialogueIndex]);
        animator.SetBool(dialogueOpenParam, true);
    }

    private void DisplayDialogue(Dialogue dialogue)
    {
        portrait.sprite = dialogue.Sprite;
        speaker.text = dialogue.Speaker;
        message.text = dialogue.Message;

    }

    private void Close()
    {
        animator.SetBool(dialogueOpenParam, false);
        Game.EndDialogue();

    }
}
