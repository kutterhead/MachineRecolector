using UnityEngine;

using UnityEngine.UI;

public class MachineController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider slideVertical;
    public Slider slideHorizontal;

    public Slider slideBottonTop;

    public Transform limiteSI;
    public Transform limiteID;

    public Transform soporteCabezal;

 

    void Start()
    {
        //soporteCabezal.GetComponent<Rigidbody>().linearVelocity = transform.right *2;
    }

    // Update is called once per frame
    Vector3 horizontalOrigen;
    Vector3 horizontalObjetivo;
    Vector3 posicionActual;
    //Vector3 inicioCabezal;
    void Update()
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
