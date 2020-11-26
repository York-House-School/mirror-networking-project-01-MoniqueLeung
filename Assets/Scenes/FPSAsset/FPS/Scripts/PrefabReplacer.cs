using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class PrefabReplacer : NetworkBehaviour
{
    [System.Serializable]
    public struct ReplacementDefinition
    {
        public GameObject SourcePrefab;
        public GameObject TargetPrefab;
    }

    public bool switchOrder;
    public List<ReplacementDefinition> replacements = new List<ReplacementDefinition>();
}
