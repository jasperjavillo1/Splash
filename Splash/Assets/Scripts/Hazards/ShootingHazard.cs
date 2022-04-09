using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHazard : Hazard {
    public enum shootingHazardType {
        fixedProjectile, followingProjectile, 
    }

    public shootingHazardType type;
    public float timeBtwShots = .75f;
    public float targetSpeed = 10.0f;
    public float bulletSpeed = 10.0f;
    public float panningDegree; //  degree (in degrees) at which the turret pans back and forth

    bool panningRight = true;

    public GameObject bullet;

    GameObject target, barrel;

    Coroutine shotWaiter = null;


    private void Start() {
        target = transform.GetChild(0).gameObject;
        barrel = transform.GetChild(1).gameObject;
        shotWaiter = StartCoroutine(shotTimeWaiter());
    }

    private void Update() {
        moveTarget();
        rotateBarrel();

        if(!canDealDamageToPlayer && shotWaiter != null) {
            StopCoroutine(shotWaiter);
            shotWaiter = null;
        }
        else if(canDealDamageToPlayer && shotWaiter == null) {
            shotWaiter = StartCoroutine(shotTimeWaiter());
        }
    }


    void moveTarget() {
        switch(type) {
            case shootingHazardType.fixedProjectile:
                //  does nothing
                break;
            case shootingHazardType.followingProjectile:
                //  follows the player 
                target.transform.position = Vector2.MoveTowards(target.transform.position, FindObjectOfType<PlayerHealth>().transform.position, targetSpeed * Time.deltaTime);
                break;
        }

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, getFirstHitPoint());
    }

    void rotateBarrel() {
        Vector3 diff = target.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        barrel.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }


    void shoot() {
        var obj = Instantiate(bullet, transform.position, Quaternion.identity, transform.parent);
        obj.GetComponent<Bullet>().moveToTarget(getFarPoint(), 10.0f, dmgDealt);
    }

    Vector2 getFarPoint() {
        var offset = target.transform.position - transform.position;    //  target a point past the target for the bullet to go towards
        return offset * 50f;
    }

    Vector2 getFirstHitPoint() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, getFarPoint());
        // If it hits something...
        if(hit.collider != null && hit.collider.gameObject.GetComponent<Bullet>() == null) {
            return hit.point;
        }
        return target.transform.position;
    }


    IEnumerator shotTimeWaiter() {
        yield return new WaitForSeconds(timeBtwShots);

        shoot();

        shotWaiter = StartCoroutine(shotTimeWaiter());
    }
}
