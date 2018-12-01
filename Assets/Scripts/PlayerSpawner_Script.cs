using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner_Script : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private GameManager_Script _gameManagerScript;


    void Awake()
    {
        _gameManagerScript = GetComponent<GameManager_Script>();
        
    }
    
    public void SpawnNewPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab, _gameManagerScript.Checkpoint.position, Quaternion.identity);
        //Do some UI stuff for player remening or somthing...
        player.GetComponent<PlayerMovement_Script>().Setup(_gameManagerScript);
        _gameManagerScript.ActivePlayer = player.transform;
        
    }
}
