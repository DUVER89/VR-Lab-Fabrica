using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Transform robot;           // El objeto robot
    public Transform[] estaciones;    // Array de estaciones
    public float velocidad = 5f;      // Velocidad de movimiento

    private Transform destinoActual;
    private bool mover = false;

    void Update()
    {
        if (mover && destinoActual != null)
        {
            robot.position = Vector3.MoveTowards(robot.position, destinoActual.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(robot.position, destinoActual.position) < 0.01f)
            {
                mover = false;
            }
        }
    }

    public void MoverRobotA(int indiceEstacion)
    {
        if (indiceEstacion >= 0 && indiceEstacion < estaciones.Length)
        {
            destinoActual = estaciones[indiceEstacion];
            mover = true;
        }
        else
        {
            Debug.LogWarning("Índice fuera del rango de estaciones.");
        }
    }
}