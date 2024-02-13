using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stationaryNPC : Character, IInteractable
{
    [SerializeField] private Interaction interaction;
    public Interaction Interaction => interaction;

    public void Interact()
    {
        Interaction.StartInteraction();
    }
}