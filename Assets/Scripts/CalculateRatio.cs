using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateRatio : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float distance;
    public float alpha;
    public float cosAlpha;

    public int percentPlayer1;
    public int percentPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = this.transform.position.x;
        alpha = Vector3.Angle(player1.transform.position - player2.transform.position, Vector3.left) - 90.0f;
        cosAlpha = alpha / 90.0f;

        percentPlayer1 = (int)(5 * (10.0f - distance * cosAlpha));
        percentPlayer2 = 100 - percentPlayer1;
    }
}
