using UnityEngine;
using System.Collections;

public class GateGuardian : MonoBehaviour
{
    public GameObject powerSpherePrefab;
    public Transform[] sphereSpawnPoints;
    public float chainDistance = 5f;
    public float chainSpeed = 10f;
    public float distanceToPlayer = 2f;
    public float chainToPlayerTime = 2f;
    public int chainDamage = 10;
    public float chainAnimationDuration = 1f;
    public GameObject chainPrefab;
    public Transform chainSpawnPoint;
    public Transform playerTransform;

    public int axeDamage = 50;

    public int lifeSteal = 10;
    public float attackCD = 3f;

    private int remainingSphereCount;
    public bool vulnerableToDamage = false;
    private bool canThrowChain = true;
    public bool chainCaught = false;
    private float chainSwingTime;
    private Transform evaTransform;
    public float timer = 0;
    public bool stop = false;

    void Start()
    {

        remainingSphereCount = sphereSpawnPoints.Length;

        evaTransform = GameObject.Find("eva").transform;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        SpawnSpheres();

    }

    void Update()
    {

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if(distance <= 3f)
        {

            if(!stop)
                StartCoroutine(Attack());

        }

        else if (distance <= chainDistance && canThrowChain && !stop)
        {

            canThrowChain = false;

            StartCoroutine(ThrowChain());

        }

        if (chainCaught)
        {

            if (Time.time > chainSwingTime + chainAnimationDuration)
            {

                chainCaught = false;

                InflictChainDamageToPlayer();

            }

        }

    }

    IEnumerator ThrowChain()
    {

        yield return new WaitForSeconds(chainToPlayerTime);

        GameObject chain = Instantiate(chainPrefab, chainSpawnPoint.position, Quaternion.identity);
        Rigidbody2D chainRigidbody = chain.GetComponent<Rigidbody2D>();
        Vector2 chainDirection = (evaTransform.position - transform.position).normalized;
        chainRigidbody.velocity = chainDirection * chainSpeed;

        canThrowChain = true;

    }

    void InflictChainDamageToPlayer()
    {

        evaTransform.gameObject.GetComponent<healtsystem>().GetDamage(chainDamage);

        if(this.gameObject.GetComponent<EnemyHealthSystem>().health <= 100)
            this.gameObject.GetComponent<EnemyHealthSystem>().health += lifeSteal;

    }

    IEnumerator Attack()
    {

        stop = true;

        yield return new WaitForSeconds(2);

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if (distance <= 3f)
        {

            playerTransform.gameObject.GetComponent<healtsystem>().GetDamage(axeDamage);

        }

        stop = false;

    }

    public void SphereBroken()
    {

        remainingSphereCount--;

        if (remainingSphereCount <= 0)
        {

            vulnerableToDamage = true;

        }

    }

    public void SpawnSpheres()
    {

        foreach (Transform spawnPoint in sphereSpawnPoints)
        {

            Instantiate(powerSpherePrefab, spawnPoint.position, spawnPoint.rotation);
        }

    }

}