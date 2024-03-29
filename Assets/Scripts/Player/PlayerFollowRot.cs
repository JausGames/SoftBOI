using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowRot : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    [SerializeField] private ConfigurableJoint m_ConfigurableJoint;
    Quaternion targetInitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        this.m_ConfigurableJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }
    private void FixedUpdate()
    {
        SetTarget();
    }
    public void SetTarget()
    {
        this.m_ConfigurableJoint.targetRotation = copyRotation();
    }

    private Quaternion copyRotation() {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
