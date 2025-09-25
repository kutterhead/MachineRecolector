using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class MachineController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider slideVertical;
    public Slider slideHorizontal;
    public Slider slideBottonTop;
    public Transform limiteSI;
    public Transform limiteID;
    public Transform soporteCabezal;
    public bool isGripping = false;

    // Update is called once per frame
    Vector3 horizontalOrigen;
    Vector3 horizontalObjetivo;
    Vector3 posicionActual;
    //Vector3 inicioCabezal;

    public ClawController clawController;

    void Start()
    {
  


        //soporteCabezal.GetComponent<Rigidbody>().linearVelocity = transform.right *2;

        //StartCoroutine(bajaGarra());
    }


    void Update()
    {

        if (isGripping == false)
        {

            


            //return;
            float valorV = slideVertical.value;
            float valorH = slideHorizontal.value;
            float top = slideBottonTop.value;


            //Debug.Log(valorV);
            //desplazaY
            horizontalOrigen = new Vector3(soporteCabezal.position.x, limiteSI.position.y, soporteCabezal.position.z);
            horizontalObjetivo = new Vector3(soporteCabezal.position.x, limiteID.position.y, soporteCabezal.position.z);
            posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, top);

            soporteCabezal.position = posicionActual;

            //desplaza z
            horizontalOrigen = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteSI.position.z);
            horizontalObjetivo = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteID.position.z);

            posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, valorV);
            soporteCabezal.position = posicionActual;


            //desplaza x;



            horizontalOrigen = new Vector3(limiteSI.position.x, soporteCabezal.position.y, soporteCabezal.position.z);
            horizontalObjetivo = new Vector3(limiteID.position.x, soporteCabezal.position.y, soporteCabezal.position.z);

            posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, valorH);

            soporteCabezal.position = posicionActual;


        }


    }
    public void bajarBrazo()
    {
        StartCoroutine(bajaGarra());
    }

    IEnumerator bajaGarra()
    {
        
        float tiempo = 1f;

        isGripping = true;


        while (true)
        {

            tiempo -= Time.deltaTime / 2;
            if (tiempo > 0f)
            {

                horizontalOrigen = new Vector3(soporteCabezal.position.x, limiteSI.position.y, soporteCabezal.position.z);
                horizontalObjetivo = new Vector3(soporteCabezal.position.x, limiteID.position.y, soporteCabezal.position.z);
                Debug.Log("Tiempo garra: " + tiempo);
                posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, tiempo);
                soporteCabezal.position = posicionActual;

            }
            else
            {

                break;
            }
            yield return null;


        }

       yield return clawController.cierraGarra();



        tiempo = 0f;

        //isGripping = true;


        while (true)
        {

            tiempo += Time.deltaTime / 2;
            if (tiempo < 1f)
            {

                horizontalOrigen = new Vector3(soporteCabezal.position.x, limiteSI.position.y, soporteCabezal.position.z);
                horizontalObjetivo = new Vector3(soporteCabezal.position.x, limiteID.position.y, soporteCabezal.position.z);
                Debug.Log("Tiempo garra: " + tiempo);
                posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, tiempo);
                soporteCabezal.position = posicionActual;





            }
            else
            {

                break;
            }
            yield return null;


        }
        tiempo = slideVertical.value;
        while (true)
        {

            tiempo -= Time.deltaTime / 2;
            if (tiempo > 0f)
            {

            
                horizontalOrigen = new Vector3(limiteSI.position.x, soporteCabezal.position.y, soporteCabezal.position.z);
                horizontalObjetivo = new Vector3(limiteID.position.x, soporteCabezal.position.y, soporteCabezal.position.z);

                posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, tiempo);

                soporteCabezal.position = posicionActual;


            }
            else
            {

                break;
            }
            yield return null;


        }

        tiempo = slideHorizontal.value;
        while (true)
        {

            tiempo -= Time.deltaTime / 2;
            if (tiempo > 0f)
            {

                //desplaza z
                horizontalOrigen = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteSI.position.z);
                horizontalObjetivo = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteID.position.z);

                posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, tiempo);
                soporteCabezal.position = posicionActual;


            }
            else
            {

                break;
            }
            yield return null;


        }
       gripper grip = FindAnyObjectByType<gripper>();
        grip.sueltaObjeto();
        yield return clawController.abreGarra();
        // clawController.cerrarGarra();

    }

  

}
