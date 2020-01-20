using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ActivateOnTrigger;

    //----if an object with the Sphere script enters the trigger it activates all Items in the ActivateOnTrigger List
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
