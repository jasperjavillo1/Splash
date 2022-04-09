using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour
{

   public void PassToNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        
    }


}
