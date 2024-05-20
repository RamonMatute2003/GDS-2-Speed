using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class molten : MonoBehaviour
{
    public Image molten_img;//molten_img=molten=fundido
    public string[] scenes;//scenes=escenas

    void Start()
    {
        molten_img.CrossFadeAlpha(0,0.5f,false);
    }

    public void fade_out(int scene)//fade_out=desaparecer
    {
        molten_img.CrossFadeAlpha(1,0.5f,false);
        StartCoroutine(scene_changes(scenes[scene]));
    }

    IEnumerator scene_changes(string scene)//scene_changes=cambios de escena
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
