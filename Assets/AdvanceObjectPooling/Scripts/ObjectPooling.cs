using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;   //reference to the instance

    //dictionary to store the deactive pooledobjects
    private Dictionary<string, List<GameObject>> pooledObjects = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        //if instance is null
        if (instance == null)
            instance = this;    //we set this as the instance

        pooledObjects = new Dictionary<string, List<GameObject>>(); ;
    }

    /// <summary>
    /// Method called to get the gameobject form the pool dictionary
    /// </summary>
    /// <param name="objPrefab">Pass the respective gameobject prefab</param>
    /// <returns>Gameobject</returns>
    public GameObject GetFromPool(GameObject objPrefab)
    {
        //create a new gamobject variable
        GameObject obj = null;
        //set the key to object name
        string key = objPrefab.name;
        //check if dictionary contains the key
        if (pooledObjects.ContainsKey(key))
        {
            //if yes then check the list for that key has elements
            if (pooledObjects[key].Count > 0)
            {
                //return the 1st element
                obj = pooledObjects[key][0];
                //remove it from the list
                pooledObjects[key].RemoveAt(0);
            }
            else //if list is empty
            {
                //create the new gameobject
                obj = CreateGameobject(objPrefab);
            }
        }
        else //if the dictionary dont have the key
        {
            //add the key and new list as value to the dictionary
            pooledObjects.Add(key, new List<GameObject>());
            //create the gameobject
            obj = CreateGameobject(objPrefab);
        }

        //return the object
        return obj;
    }

    /// <summary>
    /// Method called when we want to return the gameobject to the pool
    /// </summary>
    /// <param name="objPrefab">Pass the gameobject</param>
    public void ReturnToPool(GameObject obj)
    {
        //create the key from object name
        string key = obj.name;
        //deactivate it
        obj.SetActive(false);
        //check the dictionary for the key
        if (pooledObjects.ContainsKey(key))
        {
            //if we have the key then add the obj to list
            pooledObjects[key].Add(obj);
        }
        else
        {
            //if we dont have the key
            //create the empty list
            List<GameObject> objList = new List<GameObject>();
            //add the object to the list
            objList.Add(obj);
            //add the key value pair to the dictionary
            pooledObjects.Add(key, objList);
        }
    }

    /// <summary>
    /// Method to create the clone of gameobject
    /// </summary>
    /// <param name="objPrefab">Pass the respective gameobject prefab</param>
    /// <returns>Gameobject</returns>
    private GameObject CreateGameobject(GameObject objPrefab)
    {
        //Instantiate the gameobject
        GameObject obj = Instantiate(objPrefab);
        //set its name to the prefab gameobject name
        obj.name = objPrefab.name;
        //deactivate the gameobject
        obj.SetActive(false);
        //return it
        return obj;
    }
}
