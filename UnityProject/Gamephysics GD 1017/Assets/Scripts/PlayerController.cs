using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;

    public delegate void CallEvent(SphereScript.CubeMovement cubeMovement, float pullForce, float Mass);
    public static event CallEvent OnPlayerCall;

    [SerializeField]
    private float moveSpeed;


    [SerializeField]
    private float pullForce = 10;

    private float Mass;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Mass = rigid.mass;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        Move();
        Call();
    }
    private void Move()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);
        //rigid.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* Time.deltaTime * moveSpeed, ForceMode.Impulse);
    }

    private void Call()
    {
        if(Input.GetKey(KeyCode.H))
        {
            OnPlayerCall(SphereScript.CubeMovement.towardsPlayer, pullForce, Mass);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            OnPlayerCall(SphereScript.CubeMovement.awayFromPlayer, pullForce, Mass);
        } else
        {
            OnPlayerCall(SphereScript.CubeMovement.nothing, pullForce, Mass);
        }
    }
}
