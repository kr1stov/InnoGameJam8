using UnityEngine;
using UnityEditor;

using System.Collections;

public class PrefabEditor : MonoBehaviour
 {

     [MenuItem("GameObject/Pool", false, 10)]
     public static void CreatePool()
     {
         PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Pools");
     }
}
