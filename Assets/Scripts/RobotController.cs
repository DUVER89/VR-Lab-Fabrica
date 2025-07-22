using UnityEngine;
using UnityEngine.AI;

public class RobotNavController : MonoBehaviour
{
    public Transform[] estaciones;
    public Animator animator;

    private NavMeshAgent agent;
    private int destinoActual = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (estaciones.Length > 0)
        {
            MoverARuta(destinoActual);
        }
    }

    void Update()
    {
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void MoverARuta(int indice)
    {
        if (indice >= 0 && indice < estaciones.Length)
        {
            destinoActual = indice;
            agent.SetDestination(estaciones[indice].position);
        }
        else
        {
            Debug.LogWarning("Índice de estación fuera de rango.");
        }
    }
}
