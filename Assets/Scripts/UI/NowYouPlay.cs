using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NowYouPlay : MonoBehaviour
{

    //Esses métodos são apenas para os botões funcionarem, ent pense em cada método como uma função de um botão;

    //Carrega a cena do jogo
    public void PlayGameFirstAreaNaoSeiNomeMudaDpsAeNamoral()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Carrega a cena de configurações
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    //Teoricamente fecha o jogo
    public void QuitGame()
    {
        //Make it quit
        Debug.Log("Quiting...");
        Application.Quit();
    }

}
