using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private string _tutorialText;
    [SerializeField] private TextMeshProUGUI _tutorialTextMeshPro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _tutorialTextMeshPro.gameObject.SetActive(true);
            _tutorialTextMeshPro.SetText(_tutorialText);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _tutorialTextMeshPro.gameObject.SetActive(false);
        }
    }
}
