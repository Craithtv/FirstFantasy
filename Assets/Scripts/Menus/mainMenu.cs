using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    private Animator animator;
    private string menuOpenAnim = "MenuOpen";
    private string menuCloseAnim = "MenuClose";

    public bool IsOpen{ get; private set;}
    [SerializeField] public bool IsAnimating => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1;

    //private bool isMenuOpen => Game.State == GameState.Menu;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        // animator.SetBool(menuOpenParameter, isMenuOpen);

        // if (Input.GetKeyDown(KeyCode.Escape) && isMenuOpen)
        // {
        //     StartCoroutine(CloseMenu());
        // }
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
