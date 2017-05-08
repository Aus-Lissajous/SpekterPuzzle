using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpekterFaces2 : MonoBehaviour {
    public AudioSource Audio;
    float[] spectrum = new float[256];
    public float ValueSpekter;
    public List<GameObject> Faces;
    void Update()
    {
        Audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        ValueSpekter = spectrum[1] * 100;
        gameObject.transform.Rotate(0,0.5f,0);
        if (ValueSpekter <= 0.5)
        {
            Faces[0].SetActive(true);
        }
        else if (ValueSpekter <= 0.8)
        {
            Faces[1].SetActive(true);
        }
        else if (ValueSpekter <= 1)
        {
            Faces[2].SetActive(true);
        }
        else if (ValueSpekter <= 1.2)
        {
            Faces[3].SetActive(true);
        }
        else if (ValueSpekter <= 1.8)
        {
            Faces[4].SetActive(true);
        }
        else if (ValueSpekter <= 2)
        {
            Faces[5].SetActive(true);
        }
        else
        {
            Faces[0].SetActive(false);
            Faces[1].SetActive(false);
            Faces[2].SetActive(false);
            Faces[3].SetActive(false);
            Faces[4].SetActive(false);
            Faces[5].SetActive(false);
        }
    }
}
