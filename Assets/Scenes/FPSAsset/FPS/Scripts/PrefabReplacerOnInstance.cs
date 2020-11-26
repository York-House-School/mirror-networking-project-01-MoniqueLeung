using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

[ExecuteInEditMode]
public class PrefabReplacerOnInstance : NetworkBehaviour
{
    public GameObject TargetPrefab;

    void Awake()
    {
#if UNITY_EDITOR
        List<GameObject> allPrefabObjectsInScene = new List<GameObject>();
        foreach (Transform t in GameObject.FindObjectsOfType<Transform>())
        {
            if (PrefabUtility.IsAnyPrefabInstanceRoot(t.gameObject))
            {
                allPrefabObjectsInScene.Add(t.gameObject);
            }
        }

        foreach (GameObject go in allPrefabObjectsInScene)
        {
            GameObject instanceSource = PrefabUtility.GetCorrespondingObjectFromSource(go);

            if (instanceSource == TargetPrefab)
            {
                transform.SetParent(go.transform.parent);
                transform.position = go.transform.position;
                transform.rotation = go.transform.rotation;
                transform.localScale = go.transform.localScale;

                // Undo.Register
                Undo.DestroyObjectImmediate(go);

                Debug.Log("Replaced prefab in scene");
                DestroyImmediate(this);
                break;
            }
        }
#endif
    }
}
