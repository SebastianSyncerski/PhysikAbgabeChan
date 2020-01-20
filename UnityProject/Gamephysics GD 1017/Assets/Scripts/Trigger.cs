using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ActivateOnTrigger;
    [SerializeField]
    private List<GameObject> DeactivateOnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SphereScript>())
        {
            //Debug.Log("objekt in box ist: " +other);
            //----if an object with the Sphere script enters the trigger it activates all Items in the ActivateOnTrigger List
            foreach (GameObject i in ActivateOnTrigger)
            {
                i.SetActive(true);
            }
            //----if an object with the Sphere script enters the trigger it deactivates all Items in the DeactivateOnTrigger List
            foreach (GameObject i in DeactivateOnTrigger)
            {
                i.SetActive(false);
            }
        }
    }
}
