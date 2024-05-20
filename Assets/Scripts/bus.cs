using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus : MonoBehaviour
{
    public GameObject chronometer;//chronometer=cronometro
    public chronometer chronometer_script;
    public GameObject sound;//sound=sonido
    public audio audio_script;

    void Start()
    {
        chronometer=GameObject.FindObjectOfType<chronometer>().gameObject;
        chronometer_script = chronometer.GetComponent<chronometer>();
        sound=GameObject.FindObjectOfType<audio>().gameObject;
        audio_script=sound.GetComponent<audio>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<car>() != null)
        {
            audio_script.crash_sound();
            chronometer_script.time = chronometer_script.time - 20;
            Destroy(this.gameObject);
        }
    }
}
