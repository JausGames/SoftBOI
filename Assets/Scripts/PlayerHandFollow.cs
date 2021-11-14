using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandFollow : MonoBehaviour
{
    public Transform target;
    public Transform hand;
    public Transform selfSpine;
    public Transform referenceSpine;
    public Vector3 trigo;
    public Vector3 noAnglePos;
    public float angle;
    public float test;
    public float cosOffset;
    public float sinOffset;
    public float radius;
    public float tick;

    // Update is called once per frame
    void Update()
    {/*
        var referencePos = target.position - referenceSpine.position;
        radius = (transform.position - selfSpine.position).magnitude;
        cosOffset = (Mathf.Cos(selfSpine.rotation.y) - Mathf.Cos(referenceSpine.rotation.y));
        sinOffset = (Mathf.Sin(selfSpine.rotation.y) - Mathf.Sin(referenceSpine.rotation.y));
        angle = referenceSpine.eulerAngles.y - selfSpine.eulerAngles.y;
        trigo = - Mathf.Sin(angle) * referenceSpine.forward + (1 - Mathf.Cos(angle)) * referenceSpine.right;
        noAnglePos = selfSpine.position + referencePos;
        var rotOffset = Mathf.Pow(Mathf.Sin(selfSpine.eulerAngles.y) - Mathf.Sin(referenceSpine.eulerAngles.y), 2f) * radius * -selfSpine.forward + Mathf.Pow(Mathf.Cos(selfSpine.eulerAngles.y) - Mathf.Cos(referenceSpine.eulerAngles.y), 2f) * radius * selfSpine.right;
        var realPos = noAnglePos  + trigo * noAnglePos.magnitude;
        transform.position = realPos + rotOffset.x * Vector3.right + rotOffset.z * Vector3.forward;*/

        if (tick == 1000f) tick = 0;
        else tick++;

        angle = referenceSpine.eulerAngles.y - selfSpine.eulerAngles.y;
        radius = (hand.position - selfSpine.position).magnitude;
        cosOffset = 1f - Mathf.Cos((angle / 360f) * 2f * Mathf.PI);
        sinOffset = -Mathf.Sin((angle / 360f) * 2f * Mathf.PI);
        var totalSpinOffset = sinOffset * radius * -selfSpine.forward + cosOffset * radius * selfSpine.right;


        var referencePos = target.position - referenceSpine.position;
        //transform.position = selfSpine.position + referencePos + sinOffset * radius * -selfSpine.forward + cosOffset * radius * selfSpine.right;
        hand.position = Vector3.Lerp(hand.position, selfSpine.position + referencePos + totalSpinOffset, tick / 1000f); ;
    }
    private void OnDrawGizmosSelected()
    {
        angle = referenceSpine.eulerAngles.y - selfSpine.eulerAngles.y;
        radius = (hand.position - selfSpine.position).magnitude;
        cosOffset = 1f - Mathf.Cos((angle / 180f) * Mathf.PI);
        sinOffset = -Mathf.Sin((angle / 180f) * Mathf.PI);
        var referencePos = target.position - referenceSpine.position;
        var totalSpinOffset = sinOffset * radius * -selfSpine.forward + cosOffset * radius * selfSpine.right;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(selfSpine.position, selfSpine.position + referenceSpine.forward * radius);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(selfSpine.position, selfSpine.position + referenceSpine.right * radius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(selfSpine.position, selfSpine.position + selfSpine.forward * radius);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(selfSpine.position, selfSpine.position + selfSpine.right * radius);

        Gizmos.color = Color.yellow;
        var offsetPos = selfSpine.position + referenceSpine.right * radius;
        Gizmos.DrawLine(offsetPos, offsetPos + cosOffset * radius * selfSpine.right);
        Gizmos.DrawLine(offsetPos, offsetPos + sinOffset * radius * -selfSpine.forward);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(offsetPos, offsetPos + sinOffset * radius * -selfSpine.forward + cosOffset * radius * selfSpine.right);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(selfSpine.position + referencePos + totalSpinOffset, Vector3.one / 5f);
    }
}
