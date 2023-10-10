using UnityEngine;
using System.Collections;

public class GateGuardian : MonoBehaviour
{
    [SerializeField] private GameObject powerSpherePrefab, chainPrefab;
    [SerializeField] private Transform[] sphereSpawnPoints;
    [SerializeField] private float chainDistance = 5f, chainSpeed = 10f, distanceToPlayer = 2f, chainAnimationDuration = 1f,
        attackCD = 3f, chainSwingTime, timer = 0;
    [SerializeField] private int chainDamage = 10, axeDamage = 50, lifeSteal = 10, remainingSphereCount;
    [SerializeField] private Transform chainSpawnPoint, playerTransform;
    [SerializeField] private bool stop = false, canThrowChain = true;

    public bool vulnerableToDamage = false, chainCaught = false;
    public float chainToPlayerTime = 2f;

    void Start()
    {

        remainingSphereCount = sphereSpawnPoints.Length;

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
        Vector2 chainDirection = (playerTransform.position - transform.position).normalized;
        chainRigidbody.velocity = chainDirection * chainSpeed;

        canThrowChain = true;

    }

    void InflictChainDamageToPlayer()
    {

        playerTransform.gameObject.GetComponent<healtsystem>().GetDamage(chainDamage);

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