using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;

    //----setting up magnet events
    public delegate void CallEvent(SphereScript.CubeMovement cubeMovement, float pullForce, float Mass);
    public static event CallEvent OnPlayerCall;

    [SerializeField]
    private float moveSpeed;

    //----Variables used for calculating players "gravitation" when magnet mode is activated
    [SerializeField]
    private float pullForce = 10;

    private float Mass;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Mass = rigid.mass;
    }

    //----User input is checked each frame
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
        //----Player gets moved according to input
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);

        //----Same as above, but Velocity based
        //rigid.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* Time.deltaTime * moveSpeed, ForceMode.Impulse);
    }

    private void Call()
    {
        //----calling the Magnet events when correct buttons are pushed
        if (Input.GetKey(KeyCode.H))
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
