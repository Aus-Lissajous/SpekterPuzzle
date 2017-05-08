using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpekterFaces : MonoBehaviour {
    private AudioSource Audio;
    float[] spectrum = new float[256];
    public float ValueSpekter;
    public float ValueSpekterRender;
    public List<GameObject> Faces;
    public List<Renderer> RendererFaces;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        ValueSpekter = spectrum[1] * 100;
        ValueSpekterRender = spectrum[1] * 50;
        gameObject.transform.Rotate(0,-0.5f, 0);
        ShaderEffect();
        if (ValueSpekter <= 0.5)
        {
            Faces[0].SetActive(true);
        }
        else if (ValueSpekter <= 1)
        {
            Faces[1].SetActive(true);
        }
        else if (ValueSpekter <= 1.5)
        {
            Faces[2].SetActive(true);
        }
        else if (ValueSpekter <= 2)
        {
            Faces[3].SetActive(true);
        }
        else if (ValueSpekter <= 2.5)
        {
            Faces[4].SetActive(true);
        }
        else if (ValueSpekter <= 3)
        {
            Faces[5].SetActive(true);
        }
        else if (ValueSpekter >= 5 || ValueSpekter <= 0)
        {
            Faces[0].SetActive(false);
            Faces[1].SetActive(false);
            Faces[2].SetActive(false);
            Faces[3].SetActive(false);
            Faces[4].SetActive(false);
            Faces[5].SetActive(false);
        }
    }

    public void ShaderEffect()
    {
        for (int i = 0; i < RendererFaces.Count; i++)
        {
            RendererFaces[i].transform.localScale = new Vector3(ValueSpekterRender / 2, ValueSpekterRender / 2, ValueSpekterRender / 2);
        }
    }
}
