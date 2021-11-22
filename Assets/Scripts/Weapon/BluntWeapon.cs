using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluntWeapon : Weapon
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BluntWeapon, onCollisionEnter : " + collision.gameObject.layer);
        if(hitableLayer == (hitableLayer | (1 << collision.gameObject.layer)) && collision.gameObject.GetComponentInParent<Player>())
        {
            var hitDamage = damage * body.velocity.sqrMagnitude * speedDamageModifier;
            collision.gameObject.GetComponentInParent<Player>().GetHit(hitDamage, owner);
            if(hitDamage>15f)
            {
                var blood = Instantiate<GameObject>(bloodPrefab, collision.GetContact(0).point, Quaternion.identity, null);
                blood.transform.LookAt(blood.transform.position + collision.GetContact(0).normal.x * Vector3.right + collision.GetContact(0).normal.z * Vector3.forward);
                //blood.transform.localScale = new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z);
            }
        }
    }
}
