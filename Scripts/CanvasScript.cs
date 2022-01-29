using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject PanelID1;
    [SerializeField] private GameObject PanelID2;
    [SerializeField] private GameObject PanelID3;
    [SerializeField] private GameObject PanelID4;
    [SerializeField] private GameObject PanelID5;

    public void TurnOffPanelID1()
    {
        PanelID1.SetActive(false);
    }

    public void TurnOffPanelID2()
    {
        PanelID2.SetActive(false);
    }

    public void TurnOffPanelID3()
    {
        PanelID3.SetActive(false);
    }

    public void TurnOffPanelID4()
    {
        PanelID4.SetActive(false);
    }

    public void TurnOffPanelID5()
    {
        PanelID5.SetActive(false);
    }
}
