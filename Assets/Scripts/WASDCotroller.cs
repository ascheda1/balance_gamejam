using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WASDCotroller : MonoBehaviour
{
    StarterAssetsInputs SAI;
    // Start is called before the first frame update
    void Start()
    {
        SAI = this.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move1 = new Vector2(
            (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0),
            (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0)
        );
        SAI.MoveInput(move1);

        if (Input.GetKey(KeyCode.Q))
        {
            SAI.JumpInput(true);
        }
    }
}
