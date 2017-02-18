using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float acceleration;
    private bool addForce = false;
    private SerialPort stream = new SerialPort("COM4", 9600);
    public Rigidbody rb;

    public int horizontalSpeed = 10;
    public float limits = 4.5f;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stream.Open();
        Thread t1 = new Thread(serialRead);
        t1.Start();
    }

    void Update()
    {
        //rb.velocity = new Vector3(0, 0, 15);
        if (addForce)
        {
            rb.AddForce(new Vector3(0, 0, acceleration * 100 * rb.mass));
            addForce = false;
        }

        Vector3 newPosition = this.transform.position;

        if (moveRight || Input.GetKey("right"))
            newPosition += this.transform.right * horizontalSpeed * Time.deltaTime;
        if (moveLeft || Input.GetKey("left"))
            newPosition -= this.transform.right * horizontalSpeed * Time.deltaTime;

        if (newPosition.x < limits && newPosition.x > -limits)
            this.transform.position = newPosition;

    }

    void serialRead()
    {
        while (true)
        {
            string value = stream.ReadLine();

            if (value[0] == 'l' || value[0] == 'r')
                directionRead(value);
            else
                movementRead(value);
                
            stream.BaseStream.Flush();
        }

    }

    void directionRead(string value)
    {
        bool status;
        if (value[1] == '1')
            status = true;
        else
            status = false;

        if (value[0] == 'l')
            moveLeft = status;
        else
            moveRight = status;

    }

    void movementRead(string value)
    {
        acceleration = Convert.ToSingle(value);
        addForce = true;
    }

}