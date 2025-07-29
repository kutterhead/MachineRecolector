using UnityEngine;
//using UnityEngine.UIElements;

using UnityEngine.UI;

public class ClawController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] garra;
    public Transform[] inicioCarrera;
    public Transform[] finCarrera;
    //Vector3 posInicial;
    public Slider slideClaw;

    public bool operaGarra = false;
    void Start()
    {
       // posInicial[0] = garra[0].position;
        //garra.eulerAngles = finCarrera.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (operaGarra)
        {


                for (int i = 0; i< garra.Length;i++)
                {

                garra[i].transform.eulerAngles = Vector3.Lerp(inicioCarrera[i].eulerAngles, finCarrera[i].eulerAngles, slideClaw.value);
                }
        }
    }





}
