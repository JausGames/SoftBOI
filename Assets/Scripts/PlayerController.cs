using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody body;
    [SerializeField] Rigidbody spine;
    [SerializeField] Animator animmator;
    [SerializeField] private ConfigurableJoint hipJoint;
    [Header("Infos")]
    [SerializeField] private int playerIndex = 0;
    [Header("Movement")]
    [SerializeField] Vector3 move = Vector3.zero;
    [SerializeField] float speed = 10f;
    public Vector2 Move
    {
        get
        {
            return move;
        }
        set
        {
            move.x = value.x;
            move.z = value.y;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(move.magnitude > 0.2f)
        {
            spine.AddForce(move * speed, ForceMode.Acceleration);
            body.AddForce(move * speed, ForceMode.Acceleration);


            float targetAngle = Mathf.Atan2(-move.x, move.z) * Mathf.Rad2Deg;
            this.hipJoint.targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            animmator.SetFloat("speed", move.sqrMagnitude);
        }
        else
        {
            animmator.SetFloat("speed", 0f);
        }
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void SetPlayerIndex(int nb)
    {
        playerIndex = nb;
    }
    public void SetMove(Vector2 move)
    {
        this.move = move;
    }
}
