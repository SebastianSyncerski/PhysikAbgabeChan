using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ActivateOnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SphereScript>())
        {
            Debug.Log("objekt in box ist: " +other);
            foreach (GameObject i in ActivateOnTrigger)
            {
                i.SetActive(true);
            }
        }
    }
}
