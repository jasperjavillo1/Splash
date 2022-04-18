using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinConScript : MonoBehaviour
{
    public GameObject winCon;
    public PlayerCheckpointManager playerCheckpointManager;
    [SerializeField] AudioClip StageClear;

    // Start is called before the first frame update
    void Start()
    {
        winCon.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            winCon.SetActive(true);
            FindObjectOfType<AudioManager>().playSound(StageClear);

            playerCheckpointManager.ResetToFirstCheckpoint();

        }
    }
    



}
