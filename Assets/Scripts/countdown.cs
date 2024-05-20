using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
    public GameObject motor_road;//motor_roads=motor carreteras
    public motor_roads motor_roads_script;
    public Sprite[] numbers;
    public GameObject number_counter;//number_counter=contador de numeros
    public SpriteRenderer number_counter_component;//number_counter_component=contador de numeros componente
    public GameObject controller_car;//controller_car=controller_car=controlador de carro
    public GameObject car;//car=carro

    void Start()
    {
        component_start();
    }

    void component_start()//component_start=inicio de componentes
    {
        motor_road = GameObject.Find("motor_roads");
        motor_roads_script = motor_road.GetComponent<motor_roads>();
        number_counter = GameObject.Find("counter_numbers");
        number_counter_component = number_counter.GetComponent<SpriteRenderer>();
        car = GameObject.Find("car");
        controller_car = GameObject.Find("controller_car");
        countdown_start();
    }

    void countdown_start()
    {//countdown_start=inicio de cuenta atras
        StartCoroutine(counting());
    }

    IEnumerator counting()//counting=contando
    {
        controller_car.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        number_counter_component.sprite = numbers[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        number_counter_component.sprite = numbers[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        number_counter_component.sprite = numbers[3];
        motor_roads_script.start_game = true;
        number_counter.GetComponent <AudioSource>().Play();
        car.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        number_counter.SetActive(false);
    }
}
