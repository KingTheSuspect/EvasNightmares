using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{

    public int health = 100;
    public int getDamageFromEva = 100;
    public int getDamageFromEvaWithWhimsy = 100;
    public int getDamageFromWhimsy = 100;

    public GateGuardian gg;

    public bool dead = false;

    private void Start()
    {

        gg = GameObject.FindGameObjectWithTag("GateGuardian").GetComponent<GateGuardian>();

    }

    public void GetDamageFromEva(int baseDamage)
    {

        if (this.gameObject.tag == "GateGuardian" && gg.vulnerableToDamage)
            if (gg.vulnerableToDamage)
                health -= baseDamage + getDamageFromEva;
        else
            health -= baseDamage + getDamageFromEva;

        Check();

    }

    public void GetDamageFromWhimsy(int baseDamage)
    {

        if (this.gameObject.tag == "GateGuardian")
            if(gg.vulnerableToDamage)
                health -= baseDamage + getDamageFromWhimsy;
        else
            health -= baseDamage + getDamageFromWhimsy;

        Check();

    }

    public void GetDamageFromEvaWithWhimsy(int baseDamage)
    {

        if (this.gameObject.tag == "GateGuardian" && gg.vulnerableToDamage)
            if (gg.vulnerableToDamage)
                health -= baseDamage + getDamageFromEvaWithWhimsy;
        else
            health -= baseDamage + getDamageFromEvaWithWhimsy;

        Check();

    }

    public void Check()
    {

        if(this.gameObject.tag == "PowerSphere") 
        { 

            gg.SphereBroken();

            Destroy(this.gameObject.transform.parent.gameObject);

        }

        else
        {

            if (health <= 0 && !dead)
            {

                StartCoroutine(Die());

            }

        }

    }

    IEnumerator Die()
    {

        //AN�M

        dead = true;

        yield return new WaitForSeconds(1);

        //SpriteRenderer sa = GetComponent<SpriteRenderer>();

        /*for (int i = 100; i > 0; i--)
        {

            sa.color = new Color(sa.color.r, sa.color.g, sa.color.b, 0);

        }*/

        Destroy(this.gameObject.transform.parent.gameObject);

    }

}
