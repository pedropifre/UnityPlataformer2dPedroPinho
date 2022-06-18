using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject endGame;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.CompareTag(tagToCompare))
        {
            CallEndGame();  
        }
    }

    public void CallEndGame()
    {
        endGame.SetActive(true);
    }
}
