using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Ranged Attack")]
public class RangedAttackAction : Action
{
    public GameObject bulletPrefab;
    public EnemyData enemyData;

    public override void Act(FiniteStateMachine fsm)
    {
        enemyData.shootTimer += Time.deltaTime;
        if (enemyData.shootTimer >= enemyData.coolDownShootTime)
        {
            enemyData.shootTimer = 0;
            GameObject bullet = Instantiate(bulletPrefab, fsm.transform.GetChild(0).position + (fsm.transform.forward * 1.5f), Quaternion.identity);
            Vector3 bulletDirection = Vector3.Normalize(fsm.GetAgent().target.position - fsm.transform.GetChild(0).position);
            //float playerDistance = Vector3.Distance(fsm.transform.position, fsm.GetAgent().target.position);
            //float travelTime = playerDistance / enemyData.bulletSpeed;

            //Vector3 predictedPosition = fsm.GetAgent().target.position + fsm.GetAgent().target.GetComponent<CharacterController>().velocity * travelTime;
            //predictedPosition = predictedPosition.normalized;
            //Debug.Log(fsm.GetAgent().target.GetComponent<CharacterController>().velocity);

            bullet.GetComponent<Rigidbody>().velocity = bulletDirection * enemyData.bulletSpeed;
        }
        fsm.transform.LookAt(fsm.GetAgent().target.position);
        
    }//fsm.GetAgent().target.GetComponent<PlayerMovement>().characterSpeedVector
}
