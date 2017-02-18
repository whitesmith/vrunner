using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string movementPort = "COM3";
    public string directionPort = "COM4";
    private SerialPort movementSerial;
    private SerialPort directionSerial;

    public Rigidbody rb;
    private bool addForce = false;
    private float acceleration;

    public float limits = 4.5f;
    public int horizontalSpeed = 10;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Thread t1 = new Thread(movementThread);
        Thread t2 = new Thread(directionThread);
        t1.Start();
        t2.Start();
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

    void movementThread()
    {
        movementSerial = new SerialPort(movementPort, 9600);
        movementSerial.Open();
        while (true){
            string value = movementSerial.ReadLine();
            acceleration = Convert.ToSingle(value);
            addForce = true;
            movementSerial.BaseStream.Flush();
        }
    }

    void directionThread()
    {
        directionSerial = new SerialPort(directionPort, 9600);
        directionSerial.Open();
        while (true){
            string value = directionSerial.ReadLine();
            bool status;
            if (value[1] == '1')
                status = true;
            else
                status = false;

            if (value[0] == 'l')
                moveLeft = status;
            else
                moveRight = status;

            directionSerial.BaseStream.Flush();
        }
    }

    public void OnApplicationQuit()
    {
        if (movementSerial != null && movementSerial.IsOpen)
            movementSerial.Close();
        if (directionSerial != null && directionSerial.IsOpen)
            directionSerial.Close();

    }
}