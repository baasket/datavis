using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieDataDisplayer : MonoBehaviour
{
    /**
     * Cette classe affiche les données qu'on passe en argument de ses méthodes
     * et gère donc la présentation de ces données sur "l'écran du film".
     * 
     * Frédéric 30.08.19
     */

    [Header("References")]
    public GameObject poster;
    public Material posterMaterial;

    [Header("Display")]
    public Text title;
    public Text director;
    public Text plot;
    public Text released;
    public Text runtime;
    public Text cast;

    private void Start()
    {
        title.text = "";
        director.text = "";
        plot.text = "";
        released.text = "";
        runtime.text = "";
        cast.text = "";
        poster.SetActive(false);
    }

    public void DisplayJsonData(MovieData movieData)
    {
        title.text = movieData.Title;
        director.text = "Directed by " + movieData.Director;
        plot.text = movieData.Plot;
        released.text = "Released on the " + movieData.Released;
        runtime.text = "This movie is " + movieData.Runtime + " long";
        cast.text = "With: " + movieData.Actors;
        poster.SetActive(false);
    }

    public void DisplayPoster(Texture texture)
    {
        if(texture != null)
        {
            posterMaterial.mainTexture = texture;
            poster.SetActive(true);
            Vector3 scale = poster.transform.localScale;
            scale.y = texture.height * scale.x / texture.width;
            poster.transform.localScale = scale;
        }
        else
        {
            poster.SetActive(false);
        }
    }
}
