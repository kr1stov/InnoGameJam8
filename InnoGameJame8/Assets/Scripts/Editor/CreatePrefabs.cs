using UnityEngine;
using UnityEditor;

using System.Collections;

public class PrefabEditor : MonoBehaviour
 {

    [MenuItem("GameObject/Pool", false, 10)]
    public static void CreatePool(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("new Pool");
        go.AddComponent<ObjectPool>();
        go.AddComponent<ObjectGenerator>();

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;

        string path = "Assets/Prefabs/Pools/" + go.name + ".prefab";
        PrefabUtility.CreatePrefab(path, go);

        DestroyImmediate(go);
    }
}
