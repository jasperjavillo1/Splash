using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    //  damage dealt to the player when player interacts with the hazard
    public float dmgDealt = 0.0f;

    //  min seconds between player taking damage
    const float dmgBufferPeriod = .75f;
    Coroutine damager = null;
    bool takingDamage = false;

    //  if the hazard can deal damage to the player, defaulted to true
    public bool canDealDamageToPlayer { get; private set; } = true;


    public void setCanDamagePlayer(bool b) {
        canDealDamageToPlayer = b;

        //  animations / flair / color change / whatever when the hazard gets turned off or on
        if(b) turnOnAnimation();
        else  turnOffAnimation();
    }


    //  called when player interacts with the hazard
    //  deals dmg to player 
    protected void dealDamageToPlayer() {
        FindObjectOfType<PlayerHealth>().DecreaseHealth(dmgDealt);

        //  hurt animations
        playerHurtAnimation();
    }


    protected void startTakingDamage() {
        takingDamage = true;
        if(damager != null)
            return;
        damager = StartCoroutine(dealDamageWaiter());
    }
    protected void stopTakingDamage() {
        takingDamage = false;
    }
    //  deals damage to player, then waits for the invincibility period to end to damage it again
    IEnumerator dealDamageWaiter() {
        if(canDealDamageToPlayer) {
            dealDamageToPlayer();

            yield return new WaitForSeconds(dmgBufferPeriod);
        }
        yield return new WaitForEndOfFrame();

        damager = takingDamage ? StartCoroutine(dealDamageWaiter()) : null;
    }



    //      Animaitons

    void playerHurtAnimation() {
        //  do stuff
    }

    void turnOnAnimation() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    void turnOffAnimation() {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
