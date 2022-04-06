using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : Hazard {
    //  whether or not the player is colliding with the hazard
    public bool contacting = false;
    //  min seconds that pass between dealing player damage.
    public float dmgBufferPeriod = .5f;

    /*  list of times that control the activation of the hazard
        x - time activated, y - time unactivated until next activation
        z - bool if the time should be repeated (z > 0.0f = gets repeated very cycle, z <= 0.0f = only gets run at the start)
        Ex. (1, 6, 0) - turns on for 1 sec, then turns off for 6 secs, doesn't repeat after the first cycle
        Ex. (2, 5, 1) - turns on for 2 sec, then turns off for 5 secs, repeats every cycle
    */
    public List<Vector3> activationTimes = new List<Vector3>();


    private void Start() {
        if(activationTimes.Count > 0)   //  starts the hazard timers if there are any
            StartCoroutine(activationTimer(true));
    }


    private void OnCollisionEnter2D(Collision2D col) {
        if(!contacting && col.gameObject.tag == "Player") {
            contacting = true;
            startTakingDamage();
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if(contacting && col.gameObject.tag == "Player") {
            contacting = false;
            stopTakingDamage();
        }
    }

    IEnumerator activationTimer(bool firstCycle = false) {
        foreach(var i in activationTimes) {
            if(i.z > 0.0f || (i.z <= 0.0f && firstCycle)) {
                setCanDamagePlayer(true);   //  turns hazard on
                if(contacting) {    //  checks if is contacting with the player
                    startTakingDamage();
                }
                yield return new WaitForSeconds(i.x);
                setCanDamagePlayer(false);  //  turns hazard off
                yield return new WaitForSeconds(i.y);
            }
        }
        StartCoroutine(activationTimer());
    }
}
