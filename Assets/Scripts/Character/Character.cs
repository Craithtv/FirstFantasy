using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move {get; set;}
    public CharacterAnimator Animator {get; set;}
    public CharacterTurner Turn {get; private set;}
    public bool IsMoving => Move.isMoving;
    public Vector2Int Facing => Turn.facing;
    public Vector2Int CurrentCell => Game.Map.Grid.GetCell2D(this.gameObject);

    protected virtual void Awake() 
    {
        Move = new CharacterMover(this);
        Turn = new CharacterTurner();
        Animator = new CharacterAnimator(this);
    }
    protected virtual void Start()
    {
        Vector2Int currentCell = Game.Map.Grid.GetCell2D(this.gameObject); //tells us what grid we're in
        transform.position = Game.Map.Grid.GetCellCenter2D(currentCell); //places us in center of grid
        Game.Map.OccupiedCells.Add(currentCell, this);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Animator.ChooseLayer();
        Animator.UpdateParameters();
    }
}
