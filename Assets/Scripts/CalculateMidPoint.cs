using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateMidPoint : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos1 = player1.transform.position;
        var pos2 = player2.transform.position;
        this.transform.position = (pos1 + pos2) / 2; 
    }
}
