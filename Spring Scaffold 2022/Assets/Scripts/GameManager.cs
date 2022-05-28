using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager handles game logic that involves interactions between multiple objects in the scene such as Game Over and current checkPoint location
/// </summary>
public class GameManager : MonoBehaviour {

    public GameObject player; //The player GameObject on the scene
    private Transform SpawnPosition; //The location that the player will spawn
	
    // Use this for initialization
	void Start () {
        
	}
	

    //Updates the spawnPosition
    public void UpdateSpawnPosition(Transform newPosition)
    {
        SpawnPosition = newPosition;
    }

    //Moves the player to the SpawnPosition
    public void GameOver(float n)
    {
        StartCoroutine(RestartGame(n));
    }

    //Restarts Players health and position with a given delay
    IEnumerator RestartGame(float n)
    {
        yield return new WaitForSeconds(n);
        player.transform.position = SpawnPosition.position;
    }
}
