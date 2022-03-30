using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltaAe : MonoBehaviour
{

    //Volta para a tela inicial (Esse método é apenas para o botão)

    public void ReturnToContext()
    {
        SceneManager.LoadScene("Mainmenu");
    }

}
