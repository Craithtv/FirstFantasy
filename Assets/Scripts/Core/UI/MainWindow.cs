using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{public class MainWindow : MonoBehaviour
{
    [SerializeField] private GameObject partyMemberInfoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePartyMemberInfo();
    }


    private void GeneratePartyMemberInfo()
    {
        foreach (PartyMember member in Party.ActiveMembers)
        {
            Instantiate(partyMemberInfoPrefab, this.gameObject.transform);
        }
    }
}
}