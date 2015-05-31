using UnityEngine;
using System.Collections;

public class ParalaxPoolObject : PoolObject {

    public override void Activate(Vector3 position, float distance)
    {
        base.Activate(position, distance);
        this.spawnDistance = distance + (this.transform.lossyScale.x*10);
    }

    void FixedUpdate()
    {
        float fixedSpeed = speed * Time.deltaTime;

        if (GameController.GameLoading)
        {
            fixedSpeed *= GameController.LevelSpeed;
        }

        this.transform.Translate(new Vector3(-fixedSpeed, 0, 0));

        distance += fixedSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Deadzone")
        {
            if (GameController.GameLoading)
            {
                GameController.InitializeLevel();
            }

            Deactivate();
        }
    }
}
