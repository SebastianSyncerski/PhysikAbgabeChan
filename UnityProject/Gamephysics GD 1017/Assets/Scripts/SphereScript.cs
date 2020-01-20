using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereScript : MonoBehaviour
{
    public enum CubeMovement
    {
        towardsPlayer,
        awayFromPlayer,
        nothing
    }

    private CubeMovement currentMoveState = CubeMovement.nothing;

    private Rigidbody rigid;

    private PlayerController player;

    private SphereCollider col;

    private float pullForce;

    private float Radius;

    private float gravitationConstant;

    private float Mass;

    private float massPlayer;

    private float earthSimulationMultiplier;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gravitationConstant = 6.672f * (float)Mathf.Pow(10, -11);
        col = GetComponent<SphereCollider>();
        Mass = rigid.mass;
        earthSimulationMultiplier = Mathf.Pow(10, 10);
    }

    private void Update()
    {
        ApplyMovement();
    }

    public void ChangeMovement(CubeMovement cubeM, float pullForce, float massPlayer)
    {
        this.pullForce = pullForce;
        this.massPlayer = massPlayer;
        currentMoveState = cubeM;
    }
    private void ApplyMovement()
    {
        Vector3 PullVector = (player.transform.position - transform.position).normalized * CalculateGravitationForce();
        Debug.Log($"pullVector: {PullVector}");
        switch (currentMoveState)
        {
            case CubeMovement.awayFromPlayer:
                rigid.AddForce(-PullVector, ForceMode.Impulse);
                break;
            case CubeMovement.towardsPlayer:
                rigid.AddForce(PullVector, ForceMode.Impulse);
                break;
            case CubeMovement.nothing:
                break;
            default:
                Debug.LogWarning($"undefined cubemovement: {currentMoveState}");
                break;
        }
    }
    private float CalculateGravitationForce()
    {
        Debug.Log($"GravityForce: {((gravitationConstant * Mass * massPlayer * earthSimulationMultiplier) / (player.transform.position - transform.position).magnitude) * pullForce}");
        return ((gravitationConstant * Mass * massPlayer * earthSimulationMultiplier) / (player.transform.position - transform.position).magnitude) * pullForce;
    }


    private void OnEnable()
    {
        PlayerController.OnPlayerCall += ChangeMovement;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerCall -= ChangeMovement;
    }
}
