using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class whimsyfallow : MonoBehaviour
{
    public static whimsyfallow Instance;
    public static float takipHizi = 5f;
    public string enemyTag = "Enemy";
    public Transform enemy;
    public bool takipEtmeyeDevamEt;
    public Transform hedefNesne;
    public float cooldowntimer;
    public float cooldown;
    public bool hatmode;
    public Transform hatPosition;
    public BoxCollider2D col;
    public bool thereIsNoEnemy;
    public bool hat;
    public int baseDamage = 0;

    private void Start()
    {
        Instance = this;

        hedefNesne = GameObject.Find("whimsyfallow").transform;

        hatPosition = GameObject.Find("hatposition").transform;

    }


    void Update()
    {

        float distance = Vector2.Distance(GameObject.Find("eva").transform.position, this.transform.position);

        if (distance < 0.5 && hatmode) 
        {

            this.transform.localScale = new Vector2(0, 0);
            hat = true;
        }
        else if (!hat)
        {
            this.transform.localScale = new Vector2(3, 3);

        }

        else
        {
            hat = false;
        }

        if (hat)
        {
            this.transform.localScale = new Vector2(0, 0);

        }

        if (!hatmode&&!hat)
        {
            this.transform.localScale = new Vector2(3, this.transform.localScale.y);
        }

       

        if (Input.GetMouseButtonDown(1)&& cooldowntimer <= 0 && !hatmode && !thereIsNoEnemy)
        {
            takipEtmeyeDevamEt = false;
            cooldowntimer = cooldown;
        }

        cooldowntimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(2))
        {
            hatmode = !hatmode;
        }


        if (takipEtmeyeDevamEt)
        {
            if (!hatmode && !thereIsNoEnemy)
            {
                // Eðer obje hareket ederken saða gidiyorsa
                if (transform.position.x < hedefNesne.position.x && !hat)
                {
                    transform.localScale = new Vector2(3, this.transform.localScale.y); // Saða dön
                }
                // Eðer obje hareket ederken sola gidiyorsa
                else if (transform.position.x > hedefNesne.position.x && !hat )
                {
                    transform.localScale = new Vector2(-3, this.transform.localScale.y); // Sola dön
                }
            }
        }

        if (takipEtmeyeDevamEt && !hatmode)
        {
            transform.position = Vector3.MoveTowards(transform.position, hedefNesne.position, takipHizi * Time.deltaTime);
            takipHizi = Random.Range(2, 5);
            col.isTrigger = true;
           // this.gameObject.transform.SetParent(null);

        }
        if (!takipEtmeyeDevamEt && !hatmode && !thereIsNoEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.position, takipHizi * Time.deltaTime);
            takipHizi = 24;
            col.isTrigger = false;
            //this.gameObject.transform.SetParent(null);

        }

        if (!whimsu.isRandomMoving)
        {
            // takipHizi = 7;
        }

        if (hatmode)
        {
            transform.position = Vector3.MoveTowards(transform.position, hatPosition.position, takipHizi * Time.deltaTime);
            takipHizi = 30;
            col.isTrigger = true;
            // this.gameObject.transform.SetParent(GameObject.Find("eva").transform);
            takipEtmeyeDevamEt = true;
        }

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            var closestEnemy = enemies.OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).ToList()[0];

            enemy = closestEnemy.transform;
            thereIsNoEnemy = false;
        }

        else if(enemies.Length <= 0)
        {
            thereIsNoEnemy = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag) && takipEtmeyeDevamEt)
        {
            if (enemy == other.transform && !takipEtmeyeDevamEt)
            {
                takipEtmeyeDevamEt = false;
            }
        }
       

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !takipEtmeyeDevamEt)
        {

            collision.gameObject.GetComponent<EnemyHealthSystem>().GetDamageFromWhimsy(baseDamage);

            //Destroy(collision.gameObject.transform.parent.gameObject);
            takipEtmeyeDevamEt = true;


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !takipEtmeyeDevamEt)
        {

            collision.gameObject.GetComponent<EnemyHealthSystem>().GetDamageFromWhimsy(baseDamage);

            //Destroy(collision.collider.gameObject.transform.parent.gameObject);
            takipEtmeyeDevamEt = true;


        }
    }

}





