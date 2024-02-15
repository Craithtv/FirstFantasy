using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember
{
    public GameObject actorPrefab {get; private set;}

    public PartyMember(GameObject actorPrefab)
    {
        this.actorPrefab = actorPrefab;
    }

}
