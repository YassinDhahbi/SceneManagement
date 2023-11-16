using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : TimedAction
{
    [SerializeField]
    private GameObject spawnablePrefab;

    [SerializeField]
    private List<GameObject> listOfSpawnedObjects = new List<GameObject>();

    [SerializeField]
    private int maxSpawnCountBeforePooling;


    protected override void Awake()
    {
        base.Awake();
    }

    public override void DoAction()
    {
        //SpawnOrPool();
    }

    private void Spawn()
    {
        GameObject spawnedObject = Instantiate(spawnablePrefab, transform.position, spawnablePrefab.transform.rotation);
        listOfSpawnedObjects.Add(spawnedObject);
        spawnedObject.transform.parent = transform;
        maxSpawnCountBeforePooling--;
    }

    //private void SpawnOrPool()
    //{
    //    var isMoving = movementManager.playerCharacterDisplacer.GetSpeed() > 1;
    //    if (isMoving)
    //    {
    //        if (maxSpawnCountBeforePooling > 0)
    //        {
    //            Spawn();
    //        }
    //        else
    //        {
    //            Pool();
    //        }
    //    }
    //}

    private void Pool()
    {
        foreach (var item in listOfSpawnedObjects)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = transform.position;
                item.SetActive(true);
                return;
            }
        }
    }
}