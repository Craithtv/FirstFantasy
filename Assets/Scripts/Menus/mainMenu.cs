using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    private Animator animator;
    private string menuOpenParameter = "menuOpen";
    private bool isMenuOpen => Game.State == GameState.Menu;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        animator.SetBool(menuOpenParameter, isMenuOpen);

        if (Input.GetKeyDown(KeyCode.Escape) && isMenuOpen)
        {
            StartCoroutine(CloseMenu());
        }
    }

    private IEnumerator CloseMenu()
    {
        yield return null;
        Game.CloseMenu();
    }
}
