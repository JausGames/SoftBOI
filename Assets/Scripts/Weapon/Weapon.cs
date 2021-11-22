using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float speedDamageModifier;
    [SerializeField] protected LayerMask hitableLayer;
    [SerializeField] protected Rigidbody body;
    [SerializeField] protected Player owner;
    [SerializeField] protected GameObject bloodPrefab;
 
}
