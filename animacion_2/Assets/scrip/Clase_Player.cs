using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase_Player : MonoBehaviour
{
    public Logica_Player jugador_1;
    private void OnTriggerStay(Collider other)
    {
        jugador_1.Salte = true;
    }

    private void OnTriggerExit(Collider other)
    {
        jugador_1.Salte = false;
    }

}
