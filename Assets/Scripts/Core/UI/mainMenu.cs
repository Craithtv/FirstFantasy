using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{public class mainMenu : MonoBehaviour
{
    private Animator animator;
    private string menuOpenAnim = "MenuOpen";
    private string menuCloseAnim = "MenuClose";

    public bool IsOpen{ get; private set;}
    public bool IsAnimating => (animator.IsAnimating());

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    public void OpenMenu()
    {
        Debug.Log("playing open menu");
        IsOpen = true;
        animator.Play(menuOpenAnim);
    }

    public void CloseMenu()
    {
        Debug.Log("playing closing menu");
        IsOpen = false;
        animator.Play(menuCloseAnim);
    }
}
}