using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : EnemyController
{
    [Header("Skill")] public float kickForce = 25;

    public GameObject rockPrefab;

    public Transform handPos;

    public GameObject attackRock;
    
    //Animation Event
    public void KickOff()
    {
        if (attackTarget != null && transform.IsFacingTarget(attackTarget.transform))
        {
            var targetStats = attackTarget.GetComponent<CharacterStats>();
            Vector3 direction = (attackTarget.transform.position - transform.position).normalized;

            attackTarget.GetComponent<NavMeshAgent>().isStopped = true;
            attackTarget.GetComponent<NavMeshAgent>().velocity = direction * kickForce;
            
            attackTarget.GetComponent<Animator>().SetTrigger("Dizzy");

        }
    }

    private void Update()
    {
        base.Update();
        if (attackRock)
        {
            attackRock.transform.position = handPos.position;
        }
    }

    //Animation Event
    public void CreateRock()
    {
        if (attackRock == null)
        {
            attackRock = Instantiate(rockPrefab, handPos.position, Quaternion.identity);    
        }
    }
    
    
    //Animation Event
    public void ThrowRock()
    {
        if (attackTarget != null)
        {
            var rock = attackRock.GetComponent<Rock>();
            rock.target = attackTarget;
            rock.attacker = gameObject;
            rock.FlyToTarget();
            attackRock = null;
        }
    }
    
}
