using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update

    
       public enum colour { red, blue, green };

    [SerializeField] colour chooseColour;
   
        void Start()
        {
        Debug.Log("Iam started");
        }

        colour consoleColour(colour col)
        {
        if (col == colour.red)
            Debug.Log("Its red");
        else if (col == colour.blue)
            Debug.Log("Its blue");
        else if (col == colour.green)
            Debug.Log("Its blue");
        

            return col;
        }
    
    // Update is called once per frame
    void FixedUpdate()
{
        static void OnTriggerEnter(Collider other)
        
        {
            Debug.Log("hit");
        }
    }
}
