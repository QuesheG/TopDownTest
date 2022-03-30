using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCController : MonoBehaviour, IInteragivel
{

    [SerializeField] private string fala;
    [SerializeField] private GameObject TextBox;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool txtWindow;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !txtWindow)
        {
            closeTextBox();
        }
    }

    public void Interage()
    {
        txtWindow = !txtWindow;
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().enabled = false;
        text.text = "";
        TextBox.SetActive(true);
        text.text = fala;
    }

    public void closeTextBox()
    {
        TextBox.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().enabled = true;
        txtWindow = !txtWindow;
    }

}
