using UnityEngine;
using System.Collections;

public interface IPoolObject {
    void Initialize(ObjectPool pool);

    void Activate(Vector3 pos, Quaternion rot);
}
