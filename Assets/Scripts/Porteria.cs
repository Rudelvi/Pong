using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D bola){
        if(bola.name == "Bola"){
            if(this.name == "Izquierda"){
                bola.GetComponent<Bola>().reiniciarBola("Derecha");
            }
            else if(this.name == "Derecha"){
                bola.GetComponent<Bola>().reiniciarBola("Izquierda");
            }
        }
    }
}
