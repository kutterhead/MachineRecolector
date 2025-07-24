using UnityEngine;
using System;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool MouseOnPad = false;

    RectTransform rt;//rectransform de panel


    float horizontalAxis = 0f;
    float verticalAxis = 0f;

    public Transform punteroMando;

    public Rigidbody cabezal;

    public Transform soportecabezal;


    public Slider sliderX;
    public Slider sliderY;
    Vector3 posicionAnterior;
    void Start()
    {
        posicionAnterior = soportecabezal.position;
        rt = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {

        if (MouseOnPad)
        {
            Vector3 mousePos = Input.mousePosition - rt.position ;
            horizontalAxis = mousePos.x / rt.sizeDelta.x;
            verticalAxis = mousePos.y / rt.sizeDelta.y;
            Debug.Log("X: " + horizontalAxis + " Y: "+ verticalAxis);
            punteroMando.position = Input.mousePosition;
            sliderX.value = horizontalAxis;
            sliderY.value = verticalAxis;

            if (cabezal.position!= posicionAnterior)
            {

            cabezal.AddForce((posicionAnterior - soportecabezal.position) * 100f,ForceMode.Acceleration);
            posicionAnterior = soportecabezal.position;
            }

        }
    }

    public void setMouseOnPad(bool state)
    {
        MouseOnPad = state;
    }


}
