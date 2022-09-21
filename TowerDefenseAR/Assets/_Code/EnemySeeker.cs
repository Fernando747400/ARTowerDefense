using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    public Vector3 SphereCastPosition;
    public float SphereCastRadius;
    public float SphereCastDistance;

    private List<GameObject> EnemiesList = new List<GameObject>();

    public List<GameObject> GetEnemies()
    {
        RaycastHit[] hits = Physics.SphereCastAll(SphereCastPosition, SphereCastRadius, this.transform.forward, SphereCastDistance);
        EnemiesList.Clear();
        foreach (var item in hits)
        {
            if (item.transform.gameObject.CompareTag("Enemy"))
            {
                EnemiesList.Add(item.transform.gameObject);
            }
        }
        return EnemiesList;
    }

    public GameObject Closest()
    {
        if (EnemiesList.Count == 0) return null;

        GameObject closest = EnemiesList[0];
        foreach(var item in EnemiesList)
        {
            if (Vector3.Distance(this.transform.position, item.transform.position) < Vector3.Distance(this.transform.position, closest.transform.position))
            {
                closest = item;
            }
        }
        return closest;
    }
}
