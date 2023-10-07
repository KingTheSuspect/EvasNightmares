using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuStarter : MonoBehaviour
{
    bool didmenuwasstarted;
    public Animator anims;
    float time;
    public GameObject blink;
    private void Update()
    {
        if(!didmenuwasstarted && Input.GetMouseButtonDown(0))
        {
            anims.SetTrigger("begin");
            didmenuwasstarted = true;
        }

        if (didmenuwasstarted)
        {
            time += Time.deltaTime;


        }

        if (time > 0.6f)
        {
            GameObject.Find("ButtonManager").GetComponent<ButtonManager>().main.SetActive(true);
            Destroy(blink);
        }

    }
}
