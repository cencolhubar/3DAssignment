using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private Vector3 startPos;
    public float scrSpeed;
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Time.deltaTime * scrSpeed;
        transform.Translate(Vector3.back * newPos);



    }
}
