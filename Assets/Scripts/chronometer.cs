using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class chronometer : MonoBehaviour
{
    public GameObject motor_road;//motor_roads=motor carreteras
    public motor_roads motor_roads_script;
    public float time;//time=tiempo
    public float distance;//distance=distancia
    public TMP_Text txt_time;
    public TMP_Text txt_distance;
    public Text txt_final_distance;

    void Start()
    {
        motor_road = GameObject.Find("motor_roads");
        motor_roads_script=motor_road.GetComponent<motor_roads>();

        txt_time.text = "2:00";
        txt_distance.text = "0";

        time = 120;
    }

    void Update()
    {
        if (motor_roads_script.start_game==true && motor_roads_script.game_over==false)
        {
            calculate_distance();
        }

        if (time <= 0 && motor_roads_script.game_over == false)
        {
            motor_roads_script.game_over = true;
            motor_roads_script.game_states();
            txt_final_distance.text= ((int)distance).ToString()+" Mts";
            txt_time.text = "0:00";
        }
    }

    void calculate_distance()
    { //calculate_distance=calcular distancia
        distance += Time.deltaTime * motor_roads_script.speed;
        txt_distance.text = ((int)distance).ToString();
        time-=Time.deltaTime;
        int minutes=(int)time/60;//minutes=minutos
        int seconds=(int)time%60;//seconds=segundos
        txt_time.text = minutes.ToString() + ":" +seconds.ToString().PadLeft(2,'0');
    }
}
