using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateMidRotation : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rot = Vector3.Cross(this.transform.forward, player1.transform.position - player2.transform.position);
        this.transform.localRotation = Quaternion.LookRotation(center.transform.position - this.transform.position, rot);
    }
}
