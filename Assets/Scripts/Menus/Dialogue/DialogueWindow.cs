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

    private int currentSceneDialogueIndex = 0;

    private void Start() 
    {
        DisplayDialogue(scene.Dialogues[currentSceneDialogueIndex]);
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
                Debug.Log("Convo over");
            }
        }
    }

    private void DisplayDialogue(Dialogue dialogue)
    {
        portrait.sprite = dialogue.Sprite;
        speaker.text = dialogue.Speaker;
        message.text = dialogue.Message;

    }
}
