using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Vector3 ReadInput()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            x = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) 
            x = 1;

        float y = 0;
        if (Input.GetKey(KeyCode.UpArrow))
            y = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) 
            y = -1;

        if (x!= 0 || y!=0)
        {
            Vector3 direction = new Vector3(x, y, 0);
            return direction;
        }
        return Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
