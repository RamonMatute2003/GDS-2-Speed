using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class motor_roads : MonoBehaviour
{
    public float speed;//speed=velocidad
    public bool start_game;//start_game=incio de juego
    public bool game_over;//game_over=juego terminado
    public GameObject container_streets;//container_streets=contenedor de calles
    public GameObject[] container_streets_array;//container_streets_array=arreglo de contenedor de calles
    int street_counter=0;//street_counter=contador de calles
    int street_selector_number;//street_selector_number=número de selector de calles
    public GameObject previous_street;//previous_street=calle anterior
    public GameObject new_street;//new_street=calle nueva
    public float street_size;//street_size=tamaño calle
    public Vector3 screen_limit;//screen_limit=limite de pantalla
    public bool went_screen;//went_screen=salio de pantalla
    public GameObject camera_go;//camera_go=camara
    public Camera camera_component;//camera_component=componente de camara
    public GameObject car;//car=carro
    public GameObject audio_go;
    public audio audio_script;
    public GameObject end;//end=final

    void Start(){
        main_game();
    }

    void main_game()
    {//main_game=juego principal
        container_streets = GameObject.Find("container_streets");
        camera_go = GameObject.Find("Main Camera");
        camera_component=camera_go.GetComponent<Camera>();
        end = GameObject.Find("panel_game_over");
        end.SetActive(false);
        audio_go = GameObject.Find("audio");
        audio_script = audio_go.GetComponent<audio>();
        car=GameObject.FindObjectOfType<car>().gameObject;

        engine_speed();
        measure_screen();
        search_street();
    }

    void engine_speed()
    {//engine_speed=velocidad de motor
        speed = 15;
    }

    void search_street()
    {//search_street=buscar calle
        container_streets_array = GameObject.FindGameObjectsWithTag("streets");

        for (int i=0; i<container_streets_array.Length; i++)
        {
            container_streets_array[i].gameObject.transform.parent= container_streets.transform;
            container_streets_array[i].gameObject.SetActive(false);
            container_streets_array[i].gameObject.name = "street_" + i;
        }
        create_streets();
    }

    void create_streets()
    {//create_streets=crear calles
        street_counter++;
        street_selector_number = Random.Range(0, container_streets_array.Length);
        GameObject street = Instantiate(container_streets_array[street_selector_number]);
        street.SetActive(true);
        street.name = "street" + street_counter;
        street.transform.parent = gameObject.transform;
        street_position();
    }

    void street_position()//street_position=posicion de calle
    {
        previous_street=GameObject.Find("street"+(street_counter-1));
        new_street = GameObject.Find("street"+street_counter);
        measure_street();
        new_street.transform.position = new Vector3(previous_street.transform.position.x,previous_street.transform.position.y+street_size, 0);
        went_screen = false;
    }

    void measure_street()//measure_street=mido calle
    {
        for (int i=0; i < previous_street.transform.childCount; i++)
        {
            if (previous_street.transform.GetChild(i).gameObject.GetComponent<part>()!=null)
            {
                //piece_size=tamaño pieza
                float piece_size = previous_street.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                street_size = street_size + piece_size;
            }
        }
        
    }

    void measure_screen()//measure_screen=medir pantalla
    {
        screen_limit = new Vector3(0,camera_component.ScreenToWorldPoint(new Vector3(0,0,0)).y-0.5f,0);
    }

    void destroy_streets()//destroy_streets=destruir calles
    {
        Destroy(previous_street);
        street_size=0;
        previous_street = null;
        create_streets();
    }

    public void game_states()
    {//game_states=estados de juego
        car.GetComponent<AudioSource>().Stop();
        audio_script.music();
        end.SetActive(true);
    }

    void Update(){
        if (start_game==true && game_over==false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (previous_street.transform.position.y+street_size<screen_limit.y && went_screen==false)
            {
                went_screen = true;
                destroy_streets();
            }
        }
    }
}
