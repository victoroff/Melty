using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
   // public GameObject completeLevelUI;

    // complete level - we are not completing levels because it is endless sliding
    //public void CompleteLevel()
    //{
    //    Debug.Log("Level Won");
    //    completeLevelUI.SetActive(true);
    //}

    // end game function
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("Game Over");
            gameHasEnded = true;

            //restart game
            Invoke("RestartGame", restartDelay);
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
