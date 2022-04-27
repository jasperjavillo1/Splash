using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHealth : MonoBehaviour
{
    [SerializeField] AudioClip goombaDamageSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile") || collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().playSound(goombaDamageSound);

            transform.parent.gameObject.SetActive(false);

        }
    }
}
