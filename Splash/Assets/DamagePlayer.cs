using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    private GameObject player;
    [SerializeField] AudioClip playerHurtSound;

    IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(.5f);
        player.GetComponent<PlayerHealth>().DecreaseHealth(damage);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().playSound(playerHurtSound);
            player = collision.gameObject;
            StartCoroutine(DamageWait());
        }
    }
}
