using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{

    public float velocidad = 30.0f;

    AudioSource fuenteDeAudio;

    public AudioClip audioGol, audioRaqueta, audioRebote, audioInicio, audioFinal;

    public int golesIzquierda = 0;
    public int golesDerecha = 0 ;

    public Text contadorIzquierda ;
    public Text contadorDerecha ;
    public Text ganador;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right *  velocidad;

        fuenteDeAudio = GetComponent<AudioSource>();

        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        
        fuenteDeAudio.clip = audioInicio;
        fuenteDeAudio.Play();

    }

    void OnCollisionEnter2D(Collision2D micolision){
        if(micolision.gameObject.name == "RaquetaIzquierda"){
            int x = 1;

            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x,y);
            
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        if (micolision.gameObject.name == "RaquetaDerecha"){
            int x = -1;
            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x,y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();

        }

        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }

    }

    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
        if(posicionBola.y > posicionRaqueta.y){
            return 1;
        }
        else if(posicionBola.y < posicionRaqueta.y){
            return -1;
        }else{
            return 0;
        }
    }

    IEnumerator waiter()
{
    

    //Wait for 2 seconds
    yield return new WaitForSeconds(12);

}

    public void reiniciarBola(string direccion){
         ganador.text = "";
        transform.position = Vector2.zero;

 velocidad = velocidad + 5f;

        if(direccion == "Derecha"){
            golesDerecha++ ;
            contadorDerecha.text = golesDerecha.ToString();
            contadorIzquierda.text = golesIzquierda.ToString();
            if(golesDerecha >= 5){
                golesDerecha = 0;
                golesIzquierda = 0;
                ganador.text = "FIN!";
                fuenteDeAudio.clip = audioFinal;
                fuenteDeAudio.Play();
               velocidad = 30.0f;
                
            }else{
                 fuenteDeAudio.clip = audioGol;
                fuenteDeAudio.Play();
                
            }

            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        }else if(direccion == "Izquierda"){
            golesIzquierda++;
            if(golesIzquierda >= 5){
                golesIzquierda = 0;
                golesDerecha = 0;
                ganador.text = "FIN!";
                fuenteDeAudio.clip = audioFinal;
                fuenteDeAudio.Play();
                velocidad = 30.0f;
            }else{
                 fuenteDeAudio.clip = audioGol;
                fuenteDeAudio.Play();
            }
            contadorIzquierda.text = golesIzquierda.ToString();
            contadorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
