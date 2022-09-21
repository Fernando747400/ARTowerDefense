using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInstance : MonoBehaviour
{
    public GameObject pos;
    public GameObject prefab;

    public void Instance()
    {
        GameObject.Instantiate(prefab);
        prefab.transform.position = pos.transform.position;
    }
}
