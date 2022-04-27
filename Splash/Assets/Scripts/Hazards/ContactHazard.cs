using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : Hazard {
    public enum contactHazardType {
        normal, timed, triggered
    }

    public contactHazardType type = contactHazardType.normal;
    public bool contacting { get; private set; } = false;   //  whether or not the player is colliding with the hazard

    public float triggeredActivationDelay = 0.0f;   //  the time in seconds it takes for the hazard to activate after the player steps on it
    public float triggeredActivationTime = 1.0f;    //  the min time in seconds that the hazard stays activated for after being triggered
    Coroutine triggerWaiter = null;

    public float dmgBufferPeriod = .5f; //  min seconds that pass between dealing player damage.

    /*  list of times that control the activation of the hazard
        x - time activated, y - time unactivated until next activation
        z - bool if the time should be repeated (z > 0.0f = gets repeated very cycle, z <= 0.0f = only gets run at the start)
        Ex. (1, 6, 0) - turns on for 1 sec, then turns off for 6 secs, doesn't repeat after the first cycle
        Ex. (2, 5, 1) - turns on for 2 sec, then turns off for 5 secs, repeats every cycle
    */
    public List<Vector3> activationTimes = new List<Vector3>(); //  NOTE: won't be a timed hazard unless the type is set to timed


    private void Enable() {
        if(activationTimes.Count > 0 && type == contactHazardType.timed)   //  starts the hazard timers if there are any and is not a triggered hazard
            StartCoroutine(activationTimer(true));

        if(type == contactHazardType.triggered)
            setCanDamagePlayer(false);
    }


    private void OnCollisionEnter2D(Collision2D col) {
        if(!contacting && col.gameObject.tag == "Player") {
            contacting = true;
            startTakingDamage();
            if(type == contactHazardType.triggered) {
                if(triggerWaiter == null)
                    triggerWaiter = StartCoroutine(triggerTimeWaiter());
            }
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

    IEnumerator triggerTimeWaiter() {
        yield return new WaitForSeconds(triggeredActivationDelay);

        setCanDamagePlayer(true);
        //  animation
        triggeredAnimation();

        while(contacting) { //  loops back if still contacting in the end
            while(contacting)   //  stays on until the player loses contact with the hazard
                yield return new WaitForEndOfFrame();

            yield return new WaitForSeconds(triggeredActivationTime);
        }

        //  turns the hazard off
        triggerWaiter = null;
        setCanDamagePlayer(false);
    }


    void triggeredAnimation() {
        //  do stuff
    }
}
