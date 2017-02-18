using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private float acceleration;
    private bool addForce = false;
    private SerialPort stream = new SerialPort("COM3", 9600);
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stream.Open();
        Thread t1 = new Thread(serialRead);
        t1.Start();
    }

    void Update()
    {
        if (addForce)
        {
            rb.AddForce(new Vector3(0, 0, acceleration*100 * rb.mass));
            addForce = false;
        }
    }

    void serialRead()
    {
        while (true)
        {
            string value = stream.ReadLine();
            acceleration = Convert.ToSingle(value);
            addForce = true;
            stream.BaseStream.Flush();
        }

    }
}
