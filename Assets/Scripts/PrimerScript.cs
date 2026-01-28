using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    private int numeroEntero = 5;
    private float numeroDecimal = 7.5f;
    private bool verdaderoFalse = false;
    private string cadenaTexto = "hola";
    private char letra = 'a';
    

    private int[] intArray = new int[5]{2, 9, 5, 4, 3}; 
    //como no puedes asignarlo en el inspector aqui pones de cuanto quieres que sea el array con = new int[numero que desees], y detras pondrias {y dentro el valor de cada uno};

    void Start()
    {
        intArray[2] = 27; 
        //con esto accedes al nuemro del array que quieres y puedes canviarle su valor poniendo intArray[dentro la cajita qeu deas cojer] = y asignas el nuevo valor:
        
        numeroEntero = 37;

        cadenaTexto = "hola Mundo";

        Debug.Log(cadenaTexto + "adios");
        Debug.Log(numeroEntero);

        Calcule();

    }

    void Calcule()
    {
        numeroEntero = 7 + 5;
        numeroEntero = 2 - 7;
        numeroEntero = 6 * 9;
        numeroEntero = 4 / 3;

        numeroEntero = numeroEntero + 2;
        numeroEntero++;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
