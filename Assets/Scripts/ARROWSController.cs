using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ARROWSController : MonoBehaviour
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
        Vector2 move2 = new Vector2(
            (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0),
            (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0)
        );
        SAI.MoveInput(move2);

        if (Input.GetKey(KeyCode.RightShift))
        {
            SAI.JumpInput(true);
        }
    }
}
