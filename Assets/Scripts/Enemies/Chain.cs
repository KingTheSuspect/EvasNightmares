using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{

    [SerializeField] private GateGuardian gg;
    [SerializeField] private float timer = 0f;
    [SerializeField] private Transform evaTransform;

    void Start()
    {

        gg = GameObject.FindGameObjectWithTag("GateGuardian").GetComponent<GateGuardian>();

        evaTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer >= gg.chainToPlayerTime)
        {

            if (Vector3.Distance(transform.position, evaTransform.position) < 1f)
            {

                gg.chainCaught = true;

            }

            Destroy(this.gameObject);

        }

    }

}
