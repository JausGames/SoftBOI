using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GlobalRagdoll : RagdollStatus
{
    public string statusName;
    public bool isGlobal;

    public float globalXDrive;
    public float globalYZDrive;
    public float globalMassScale;
    public float globalConnectedMassScale;

    public override void ApplyRagdollStatus(JointsManager joints)
    {
        if (isGlobal)
        {
            foreach (ConfigurableJoint joint in joints.getJoints())
            {
                JointDrive jointDrive = joint.angularXDrive;
                jointDrive.positionSpring = globalXDrive;
                joint.angularXDrive = jointDrive;
                joint.angularYZDrive = jointDrive;
                joint.massScale = globalMassScale;
                joint.connectedMassScale = globalConnectedMassScale;
            }
        }
    }
}
