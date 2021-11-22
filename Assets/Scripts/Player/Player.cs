using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] PlayerController controller;
    [SerializeField] PlayerCombat combat;
    [SerializeField] List<RagdollStatus> statusList;
    //[SerializeField] List<ConfigurableJoint> joints;
    [SerializeField] JointsManager joints;
    [Header("Player infos")]
    [SerializeField] float playerIndex = 0;
    [SerializeField] Color color = Color.white;
    [SerializeField] float health = 200f;
    [SerializeField] bool isAlive = true;
    [SerializeField] RagdollStatus currentStatus;

    private void Awake()
    {
        joints = new JointsManager();
        ConfigurableJoint[] jointCmp = GetComponentsInChildren<ConfigurableJoint>();

        joints.thighs = new ConfigurableJoint[2];
        joints.shins = new ConfigurableJoint[2];
        joints.upperarms = new ConfigurableJoint[2];
        joints.forearms = new ConfigurableJoint[2];
        joints.hands = new ConfigurableJoint[2];
        joints.weapons = new ConfigurableJoint[2];
        
        foreach(ConfigurableJoint joint in jointCmp)
        {
            if (joint.gameObject.name == "spine") joints.spine = joint;
            else if (joint.gameObject.name == "spine.002") joints.middleSpine = joint;
            else if (joint.gameObject.name == "spine.006") joints.neck = joint;
            else if (joint.gameObject.name == "thigh.R") joints.thighs[0] = joint;
            else if (joint.gameObject.name == "thigh.L") joints.thighs[1] = joint;
            else if (joint.gameObject.name == "shin.R") joints.shins[0] = joint;
            else if (joint.gameObject.name == "shin.L") joints.shins[1] = joint;
            else if (joint.gameObject.name == "upper_arm.R") joints.upperarms[0] = joint;
            else if (joint.gameObject.name == "upper_arm.L") joints.upperarms[1] = joint;
            else if (joint.gameObject.name == "forearm.R") joints.forearms[0] = joint;
            else if (joint.gameObject.name == "forearm.L") joints.forearms[1] = joint;
            else if (joint.gameObject.name == "hand.R") joints.hands[0] = joint;
            else if (joint.gameObject.name == "hand.L") joints.hands[1] = joint;
            else if (joint.gameObject.name == "Weapon") joints.weapons[0] = joint;
        }

        Debug.Log("Player, Awake : JointsManager = " + joints.getJoints().ToString());
    }

    public RagdollStatus RagdollStatus
    {
        get => currentStatus;
        set 
        {
            currentStatus = value;
            currentStatus.ApplyRagdollStatus(joints);
        }
    }
    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Max(value, 0f);
        }
    }
    public bool IsAlive
    {
        get => isAlive;
        set => isAlive = value;
    }

    public bool GetHit(float damage, Player opponent)
    {
        Debug.Log("Player, GetHit : damage = " + damage + ", opponent = " + opponent);
        if (!isAlive) return true;
        if (health > damage) { Health -= damage; return true; }
        Die();
        return false;
    }

    private void Die()
    {
        RagdollStatus = statusList[0];
        isAlive = false;
    }
}
public struct JointsManager
{
    public ConfigurableJoint spine;
    public ConfigurableJoint middleSpine;
    public ConfigurableJoint neck;
    public ConfigurableJoint[] thighs;
    public ConfigurableJoint[] shins;
    public ConfigurableJoint[] upperarms;
    public ConfigurableJoint[] forearms;
    public ConfigurableJoint[] hands;
    public ConfigurableJoint[] weapons;

    public List<ConfigurableJoint> getJoints()
    {
        var joints = new List<ConfigurableJoint>();
        joints.Add(spine);
        joints.Add(middleSpine);
        joints.Add(neck);
        joints.AddRange(thighs);
        joints.AddRange(shins);
        joints.AddRange(upperarms);
        joints.AddRange(forearms);
        joints.AddRange(hands);
        joints.AddRange(weapons);
        return joints;
    }
}

