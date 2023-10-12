using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSphere : MonoBehaviour
{

    public GateGuardian gg;

    private void Start()
    {

        gg = GameObject.FindGameObjectWithTag("GateGuardian").GetComponent<GateGuardian>();

    }

    public void GetDamageFromEva()
    {

        Die();

    }

    public void GetDamageFromWhimsy()
    {

        Die();

    }

    public void GetDamageFromEvaWithWhimsy()
    {

        Die();

    }

    void Die()
    {

        gg.SphereBroken();

        Destroy(this.gameObject.transform.parent.gameObject);
        
    }

}
