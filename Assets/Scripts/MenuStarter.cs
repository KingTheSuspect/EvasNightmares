using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuStarter : MonoBehaviour
{
    bool didmenuwasstarted;
    [SerializeField] private Animator anims;
    float time;
    [SerializeField] private GameObject blink;
    private void Update()
    {
        if(!didmenuwasstarted && Input.GetMouseButtonDown(0))
        {
            //anims.SetTrigger("begin");
            didmenuwasstarted = true;
        }

        if (didmenuwasstarted)
        {
            time += Time.deltaTime;


        }

        if (time > 0.6f)
        {
            Destroy(blink);
        }

    }
}
