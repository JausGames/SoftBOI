using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animmator;
    [Header("Infos")]
    [SerializeField] private int playerIndex = 0;
    [Header("Action")]
    [SerializeField] bool attacking;
    [SerializeField] bool attackingH;
    // Start is called before the first frame update

    public bool Attacking
    {
        get
        {
            return attacking;
        }
        set
        {
            if (!attacking && value)
            {
                attacking = value;
                Debug.Log("PlayerCombat, Attacking : attacking = " + attacking);
                Debug.Log("PlayerCombat, Attacking : value = " + value);
                animmator.SetBool("attack", attacking);
            }
            else if(attacking && !value)
            {
                attacking = value;
                animmator.SetBool("attack", attacking);
            }
        }
    }
    public bool AttackingH
    {
        get
        {
            return attackingH;
        }
        set
        {
            if (!attackingH && value)
            {
                attackingH = value;
                Debug.Log("PlayerCombat, Attacking : attacking horizontal = " + attackingH);
                Debug.Log("PlayerCombat, Attacking : value = " + value);
                animmator.SetBool("attackH", attackingH);
            }
            else if (attackingH && !value)
            {
                attackingH = value;
                animmator.SetBool("attackH", attackingH);
            }
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
}
