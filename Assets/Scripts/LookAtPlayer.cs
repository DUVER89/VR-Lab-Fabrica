using UnityEngine;
using UnityEngine.AI;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null && agent != null)
        {
            // Solo mirar al jugador si el robot ya llegó a su destino
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
            }
        }
    }
}
