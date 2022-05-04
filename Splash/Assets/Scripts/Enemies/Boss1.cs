using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public int health = 50;
    [SerializeField] AudioClip bossDeath;

    private void Update()
    {
        if (health == 0)
        {
            FindObjectOfType<AudioManager>().PlaySound(bossDeath);

            transform.gameObject.SetActive(false);

        }
    }

}
