using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logica_Player : MonoBehaviour
{
    public float correrveloz = 5.0f;
    public float rotacioncorre = 200.0f;
    public Animator animar;
    private float x, y;


    public Rigidbody rg;
    public float Inpulso_Salto = 8f;
    public bool Salte;

    public float veloInicial;//guardar la velocidad de moviento 
    public float veloAgachado;//controlar para agacharse el personaje


    void Start()
    {

        Salte = false;
        animar = GetComponent<Animator>();
        veloInicial = correrveloz;
        veloAgachado = correrveloz * 0.5f;//la velocidad va disminuir en 50 porciento 
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotacioncorre, 0);
        transform.Translate(0, 0, y * Time.deltaTime * correrveloz);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animar.SetFloat("VelX", x);
        animar.SetFloat("VelY", y);

        if (Salte)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animar.SetBool("Saltar", true);
                rg.AddForce(new Vector3(0, Inpulso_Salto, 0), ForceMode.Impulse);
            }
            if (Salte)
            {
                if (Input.GetKey(KeyCode.LeftControl))//sucedera el evento miesntyras esta apretada
                {
                    animar.SetBool("Agachar", true);
                    correrveloz = veloAgachado;
                }
                else
                {
                    animar.SetBool("Agachar", false);
                    correrveloz = veloInicial;
                }

            }
            animar.SetBool("Suelo", true);
        }
        else

            Cayendo();
    }

    public void Cayendo()
    {
        animar.SetBool("Saltar", false);
        animar.SetBool("Suelo", false);
    }


}




