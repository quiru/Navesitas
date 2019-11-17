using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Verific : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
        Boss.canonDestruidos = 0;
    }

    public void SalirMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Inicio()
    {
        SceneManager.LoadScene("SampleScene");
        Boss.canonDestruidos = 0;
    }

    public void Salir()
    {
        Application.Quit();
    }
}