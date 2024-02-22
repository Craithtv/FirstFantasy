using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string speaker;
    [SerializeField] [TextArea(3,5)] private string message;

    public Sprite Sprite => sprite;
    public string Speaker => speaker;
    public string Message => message;
}
