using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    //  damage dealt to the player when player interacts with the hazard
    public float dmgDealt = 0.0f;
    //  if the hazard can deal damage to the player, defaulted to true
    public bool canDealDamageToPlayer { get; private set; } = true;


    public void setCanDamagePlayer(bool b) {
        canDealDamageToPlayer = b;

        //  animations / flair / color change / whatever when the hazard gets turned off or on
        GetComponent<SpriteRenderer>().color = b ? Color.red : Color.gray;
    }


    //  called when player interacts with the hazard
    //  deals dmg to player 
    public void dealDamageToPlayer() {
        FindObjectOfType<PlayerHealth>().DecreaseHealth(dmgDealt);

        //  hurt animations
    }
}
