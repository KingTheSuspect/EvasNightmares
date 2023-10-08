using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Button btn;

    public Vector3 pos1;
    public float flexY = 5f;

    private void Start()
    {

        pos1 = transform.position;

    }

    void Update()
    {

        this.transform.position = new Vector3(pos1.x, pos1.y + (btn.electric / 100 * flexY), pos1.z);

    }

}
