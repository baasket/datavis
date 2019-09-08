using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovieData
{
    public string Title;
    public string Year;
    public string Released;
    public string Runtime;
    public string Genre;
    public string Director;
    public string Plot;
    public string Actors;

    public string Poster;
}

[System.Serializable]
public class RatingsData
{
    public string Source;
    public string Value;
}
