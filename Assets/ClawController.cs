using UnityEngine;
//using UnityEngine.UIElements;
using System.Collections;

using UnityEngine.UI;

public class ClawController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] garraRoot;
    
    
    [SerializeField]Transform[] garra;


    [SerializeField]Transform[] inicioCarrera;
    [SerializeField]public Transform[] finCarrera;
    //Vector3 posInicial;
    public Slider slideClaw;

    public bool operaGarra = false;
    public bool garraAbiertaCerrada = false;

    public Joint cabeza;

    void Start()
    {
        // posInicial[0] = garra[0].position;
        //garra.eulerAngles = finCarrera.position;
        System.Array.Resize(ref inicioCarrera, garraRoot.Length);
        System.Array.Resize(ref finCarrera, garraRoot.Length);
        System.Array.Resize(ref garra, garraRoot.Length);

        for (int i = 0; i < garra.Length; i++)
        {
            inicioCarrera[i] = garraRoot[i].GetComponentInParent<FingerClaw>().inicioCarrera;
            finCarrera[i] = garraRoot[i].GetComponentInParent<FingerClaw>().finCarrera;
            garra[i] = garraRoot[i].GetComponentInParent<FingerClaw>().garra;
        }
        StartCoroutine(abreGarra());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (operaGarra)
        {


                for (int i = 0; i< garra.Length;i++)
                {

                garra[i].transform.eulerAngles = Vector3.Lerp(inicioCarrera[i].eulerAngles, finCarrera[i].eulerAngles, slideClaw.value);
                }
        }
        */
    }
/*
    public void cerrarGarra()
    {
        StartCoroutine(cierraGarra());

    }
*/
    public IEnumerator cierraGarra()
    {

        float tiempo = 0.0f;


       

        while (true) { 
        
            tiempo += Time.deltaTime/2;
            Debug.Log("Tiempo garra: " + tiempo);
            if (tiempo <= 1f) {

                for (int i = 0; i < garra.Length; i++)
                {

                    garra[i].transform.eulerAngles = Vector3.Lerp(inicioCarrera[i].eulerAngles, finCarrera[i].eulerAngles, tiempo);
                }


            }
            else
            {

                break;
            }
                yield return null;



        }
        garraAbiertaCerrada = true;



    }





    public IEnumerator abreGarra()
    {

        float tiempo = 1f;




        while (true)
        {

            tiempo -= Time.deltaTime / 2;
            Debug.Log("Tiempo garra: " + tiempo);
            if (tiempo >= 0f)
            {

                for (int i = 0; i < garra.Length; i++)
                {

                    garra[i].transform.eulerAngles = Vector3.Lerp(inicioCarrera[i].eulerAngles, finCarrera[i].eulerAngles, tiempo);
                }


            }
            else
            {

                break;
            }
            yield return null;



        }
        garraAbiertaCerrada = false;


    }

}
