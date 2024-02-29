using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    public CharacterMover Movement {get; set;}
    public CharacterAnimator Animator {get; set;}
    public CharacterTurner Turner {get; private set;}
    public bool IsMoving => Movement.isMoving;
    public Vector2Int Facing => Turner.facing;
    public Vector2Int CurrentCell => Game.Manager.Map.Grid.GetCell2D(this.gameObject);
    public Map Map => Game.Manager.Map;

    protected virtual void Awake() 
    {
        Movement = new CharacterMover(this);
        Turner = new CharacterTurner(this);
        Animator = new CharacterAnimator(this);
    }
    protected virtual void Start()
    {
        transform.position = Map.Grid.GetCellCenter2D(CurrentCell); //places us in center of grid
        Game.Manager.Map.OccupiedCells.Add(CurrentCell, this);
    }

    protected virtual void Update()
    {
        Animator.ChooseLayer();
        Animator.UpdateParameters();
    }
}
}
