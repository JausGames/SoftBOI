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
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void SetPlayerIndex(int nb)
    {
        playerIndex = nb;
    }
}
