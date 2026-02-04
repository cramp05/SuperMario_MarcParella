using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanLoader : MonoBehaviour
{
    public void ChangeScean(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

//esta es la forma de llamar la funcion change scene a trabes de codigo
    void Test ()
    {
        ChangeScean("Main Menu");
    }
}

