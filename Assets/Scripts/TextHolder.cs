using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHolder : MonoBehaviour
{

    public Transform follow;
    public Vector2 offset;

    private void Update()
    {

        this.gameObject.transform.position = new Vector2(follow.position.x + offset.x, follow.position.y + offset.y);

    }

}
