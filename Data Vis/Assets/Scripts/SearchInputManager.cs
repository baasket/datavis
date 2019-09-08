using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchInputManager : MonoBehaviour
{
    /**
     * Cette classe possède une seule méthode, qui est appelée lorsque le
     * bouton "Search" est pressé.
     * 
     * Frédéric 30.08.19
     */

    [Header("References")]
    public DataFetcher dataFetcher;

    [Header("Left Page Display")]
    public InputField inputField;

    public void BtnSearch()
    {
        dataFetcher.FetchData(inputField.text);
    }
}
