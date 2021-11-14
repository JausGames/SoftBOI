using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class RigidbodyInverseKinematics : MonoBehaviour
{

	public Transform upperArm;
	public Transform forearm;
	public Transform hand;
	public Transform elbow;
	public Transform target;
	[Space(20)]
	public Vector3 uppperArm_OffsetRotation;
	public Vector3 forearm_OffsetRotation;
	public Vector3 hand_OffsetRotation;
	[Space(20)]
	public float inverseForce = 0.1f;
	[Space(20)]
	public bool handMatchesTargetRotation = true;
	[Space(20)]
	public bool debug;

	float angle;
	float upperArm_Length;
	float forearm_Length;
	float arm_Length;
	float targetDistance;
	float adyacent;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (upperArm != null && forearm != null && hand != null && elbow != null && target != null)
		{
			var upperArmBody = upperArm.GetComponent<Rigidbody>();
			//var elbowPos = uppperArm_OffsetRotation + elbow.position - upperArm.position;
			var elbowPos = elbow.position - upperArm.position;

			var xAxisAngle = new Vector3(elbowPos.x, elbowPos.y, 0);
			var zAxisAngle = new Vector3(0, elbowPos.y, elbowPos.z);

			var angleZ = Vector3.SignedAngle(transform.right, xAxisAngle, transform.forward) * inverseForce;
			//var angleZ = Vector3.SignedAngle(transform.forward, xAxisAngle, transform.right) * inverseForce;

			Debug.Log("RIK, SignedAngle : angleX = " + angleZ);

			//upperArmBody.MoveRotation(Quaternion.Euler(uppperArm_OffsetRotation.x, uppperArm_OffsetRotation.y, angleZ + uppperArm_OffsetRotation.z));
			upperArmBody.MoveRotation(Quaternion.Euler(0f, 0f, angleZ));


			/*Vector3 cross = Vector3.Cross(elbow.position - upperArm.position, forearm.position - upperArm.position);



			upperArm_Length = Vector3.Distance(upperArm.position, forearm.position);
			forearm_Length = Vector3.Distance(forearm.position, hand.position);
			arm_Length = upperArm_Length + forearm_Length;
			targetDistance = Vector3.Distance(upperArm.position, target.position);
			targetDistance = Mathf.Min(targetDistance, arm_Length - arm_Length * 0.001f);

			adyacent = ((upperArm_Length * upperArm_Length) - (forearm_Length * forearm_Length) + (targetDistance * targetDistance)) / (2 * targetDistance);

			angle = Mathf.Acos(adyacent / upperArm_Length) * Mathf.Rad2Deg;

			upperArm.RotateAround(upperArm.position, cross, -angle);

			forearm.LookAt(target, cross);
			forearm.Rotate(forearm_OffsetRotation);*/

			if (handMatchesTargetRotation)
			{
				hand.rotation = target.rotation;
				hand.Rotate(hand_OffsetRotation);
			}

			if (debug)
			{
				if (forearm != null && elbow != null)
				{
					Debug.DrawLine(forearm.position, elbow.position, Color.blue);
				}

				if (upperArm != null && target != null)
				{
					Debug.DrawLine(upperArm.position, target.position, Color.red);
				}
			}

		}

	}

	void OnDrawGizmos()
	{
		if (debug)
		{
			if (upperArm != null && elbow != null && hand != null && target != null && elbow != null)
			{
				Gizmos.color = Color.gray;
				Gizmos.DrawLine(upperArm.position, forearm.position);
				Gizmos.DrawLine(forearm.position, hand.position);
				Gizmos.color = Color.red;
				Gizmos.DrawLine(upperArm.position, target.position);
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(forearm.position, elbow.position);
			}
		}
	}

}
