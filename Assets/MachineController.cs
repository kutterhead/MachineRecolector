using UnityEngine;

using UnityEngine.UI;

public class MachineController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider slideVertical;
    public Slider slideHorizontal;

    public Transform limiteSI;
    public Transform limiteID;

    public Transform soporteCabezal;

 

    void Start()
    {
        //soporteCabezal.GetComponent<Rigidbody>().linearVelocity = transform.right *2;
    }

    // Update is called once per frame
    void Update()
    {
        //return;
        float valorV = slideVertical.value;
        float valorH = slideHorizontal.value;
        
        Debug.Log(valorV);


        Vector3 horizontalOrigen = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteSI.position.z);
        Vector3 horizontalObjetivo = new Vector3(soporteCabezal.position.x, soporteCabezal.position.y, limiteID.position.z);

        Vector3 posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, valorV);


        Vector3 inicioCabezal = soporteCabezal.position;

        soporteCabezal.position = posicionActual;


        horizontalOrigen = new Vector3(limiteSI.position.x, soporteCabezal.position.y, soporteCabezal.position.z);
        horizontalObjetivo = new Vector3(limiteID.position.x, soporteCabezal.position.y, soporteCabezal.position.z);

        posicionActual = Vector3.Lerp(horizontalOrigen, horizontalObjetivo, valorH);

        soporteCabezal.position = posicionActual;


      

    }
}
