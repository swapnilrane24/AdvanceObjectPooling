using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnerCubes;     //reference to cubes gameobject
    [SerializeField] private GameObject[] spherePrefabs;    //reference to sphere prefabs

    //Blue button method
    public void SpawnBlue()
    {
        SpawnObj(0);
    }

    //White button method
    public void SpawnWhite()
    {
        SpawnObj(1);
    }

    //Yellow button method
    public void SpawnYellow()
    {
        SpawnObj(2);
    }

    //All button method
    public void SpawnAll()
    {
        for (int i = 0; i < spherePrefabs.Length; i++)
        {
            SpawnObj(i);
        }
    }

    //Method to spawn the sphere
    void SpawnObj(int index)
    {
        //we get the clone of required gameobject from ObjectPooling
        GameObject sphere = ObjectPooling.instance.GetFromPool(spherePrefabs[index]);
        sphere.SetActive(true); //we set it active
        //and then set its transform to the respective cube
        sphere.transform.position = spawnerCubes[index].transform.position;
    }
}
