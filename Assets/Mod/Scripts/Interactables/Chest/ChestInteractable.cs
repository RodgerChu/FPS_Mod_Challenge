using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public GameObject loot;
    public Transform lootPawnPosition;
    private bool opened = false;

    override public void PerformAction()
    {
        if (!opened)
        {
            opened = true;
            interactable = false;

            var spawnedLoot = Instantiate(loot, lootPawnPosition.position, Quaternion.identity);
            var rigidBody = spawnedLoot.GetComponent<Rigidbody>();
            var force = new Vector3(Random.Range(-100, 100), 300, Random.Range(-150, -100));
            rigidBody.AddForce(force);

            base.PerformAction();
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!opened)
        {
            base.OnTriggerEnter(collision);
        }
    }
}
