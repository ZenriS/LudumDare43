using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public Transform ActivePlayer;
    public CamFollow_Script CamFollowScript;
    public List<GameObject> DeadPlayers;
    public int MaxDeaths;
    private PlayerSpawner_Script _playerSpawnerScript;
    public Transform Checkpoint;
    private UIManager_Script _uiManagerScript;

    void Start()
    {
        _playerSpawnerScript = GetComponent<PlayerSpawner_Script>();
        _uiManagerScript = GetComponent<UIManager_Script>();
        NewPlayer();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Quit();
        }
    }

    public void NewPlayer()
    {
        if (DeadPlayers.Count <= MaxDeaths)
        {
            _playerSpawnerScript.SpawnNewPlayer();
            CamFollowScript.Player = ActivePlayer;
        }
        else
        {
            Debug.Log("No More Lifes");
            _uiManagerScript.DoGameOverScreen("Game Over!");
        }

        int lifes = MaxDeaths - DeadPlayers.Count;
        _uiManagerScript.SetLifes(lifes);
    }

    public void Winner()
    {
        _uiManagerScript.DoGameOverScreen("You Win!!");
        Destroy(ActivePlayer.gameObject);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
