using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    [System.Serializable]
public class DialogueLine
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string speaker;
    [SerializeField] [TextArea(3,5)] private string message;

    public Sprite Sprite => sprite;
    public string Speaker => speaker;
    public string Message => message;
}
}