using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    [SerializeField]
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public Transform player;
    public Transform spawnPoint;
    private MyNavMeshAgent enemyPos;

    public void RespawnPlayer()
    {
        
        foreach(GameObject enemy in enemies)
        {

            enemyPos = enemy.GetComponent<MyNavMeshAgent>();
            enemyPos.EnemyPosReset();
        }

        player.transform.position = spawnPoint.transform.position;
        player.gameObject.SetActive(true);


    }

    public static void KillPlayer(PlayerScript player)
    {


        player.gameObject.SetActive(false);
        gm.RespawnPlayer();

        
        

    }
}
