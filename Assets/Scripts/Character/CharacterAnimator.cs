using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator
{
    private Character character;
    private Animator animator;

    private string walkingParam = "isWalking";
    private string horizonalParam = "xDir";
    private string verticalParam = "yDir";

    public CharacterAnimator(Character character)
    {
        this.character = character;
        this.animator = character.GetComponent<Animator>();
    }

    public void ChooseLayer()
    {
        bool isWalking = character.IsMoving;
        animator.SetBool(walkingParam, isWalking);
    }

    public void UpdateParameters()
    {
        animator.SetFloat(horizonalParam, character.Facing.x);
        animator.SetFloat(verticalParam, character.Facing.y);
    
    }
}
