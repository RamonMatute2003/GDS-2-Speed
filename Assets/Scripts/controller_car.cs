using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_car : MonoBehaviour
{
    public GameObject car;//car=carro
    public float turning_angle;//turning_angle=angulo de giro
    public float speed;//speed=velocidad
    public GameObject motor_road;//motor_roads=motor carreteras
    public motor_roads motor_roads_script;

    void Start()
    {
        car = GameObject.FindObjectOfType<car>().gameObject;
        motor_road = GameObject.Find("motor_roads");
        motor_roads_script=motor_road.GetComponent<motor_roads>();
    }

    void Update()
    {
        if (motor_roads_script.game_over==false)
        {
            float angleZ = 0;//angle=angulo
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            angleZ = Input.GetAxis("Horizontal") * angleZ;
            car.transform.rotation = Quaternion.Euler(0, 0, -angleZ);
        }
    }
}
