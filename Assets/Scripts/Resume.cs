using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    [SerializeField]private GameManager gm;

    public void Rsm()
    {

        gm.paused = false;

    }

}
