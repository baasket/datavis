using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataFetcher : MonoBehaviour
{
    /**
     * Cette classe gère l'acquisiton des données en se connectant à IMDB et en
     * appelant ensuite les méthodes appropriées dans la classe 
     * MovieDataDisplayer.
     * 
     * Frédéric 30.08.19
     */

	public string apiKey = "";
    
	[Header("References")]
    public MovieDataDisplayer dataDisplayer;
	
    private string jsonURL = "";
    private string imgURL = "";
    private string baseRequestURL = "https://www.omdbapi.com/?apikey=e910c69e&";

    private void Start()
    {
        baseRequestURL = "https://www.omdbapi.com/?apikey=" + apiKey;
    }

    public void FetchData(string movieTitle)
    {
        jsonURL = baseRequestURL + ParseTitle(movieTitle);
        StartCoroutine(GetJsonText());
    }

    IEnumerator GetJsonText()
    {
        UnityWebRequest www = UnityWebRequest.Get(jsonURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            MovieData movieData = 
                JsonUtility.FromJson<MovieData>(www.downloadHandler.text);

            dataDisplayer.DisplayJsonData(movieData);


            if(movieData.Poster != "")
            {
                imgURL = movieData.Poster;
                StartCoroutine(GetPoster());
            }
        }
    }

    IEnumerator GetPoster()
    {
        UnityWebRequest www = 
            UnityWebRequestTexture.GetTexture(imgURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture moviePoster = 
                ((DownloadHandlerTexture)www.downloadHandler).texture;

            dataDisplayer.DisplayPoster(moviePoster);
        }
    }

    private string ParseTitle(string rawTitle)
    {
        string parsedTitle = rawTitle.ToLower();
        parsedTitle.Replace(" ", "+");

        return "t=" + parsedTitle;
    }
}
