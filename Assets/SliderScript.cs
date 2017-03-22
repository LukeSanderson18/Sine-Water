using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

    public enum SliderType { size, reso, height, scale, speed, noise, xmult, zmult };
    public SliderType slidertype;
    public Text text;
    Slider slider;
	// Use this for initialization
	void Start () {

        slider = GetComponent<Slider>();

        switch(slidertype)
        {
            case SliderType.size:
                slider.value = PlayerPrefs.GetFloat("size");
                break;

            case SliderType.reso:
                slider.value = PlayerPrefs.GetInt("reso");
                break;

            case SliderType.height:
                slider.value = PlayerPrefs.GetFloat("height");
                break;

            case SliderType.scale:
                slider.value = PlayerPrefs.GetFloat("scale");
                break;

            case SliderType.speed:
                slider.value = PlayerPrefs.GetFloat("speed");
                break;

            case SliderType.noise:
                slider.value = PlayerPrefs.GetFloat("noise");
                break;

            case SliderType.xmult:
                slider.value = PlayerPrefs.GetFloat("xmult");
                break;

            case SliderType.zmult:
                slider.value = PlayerPrefs.GetFloat("zmult");
                break;

            default:
                print("whoops");
                break;
        }


        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        switch (slidertype)
        {
            case SliderType.size:
            PlayerPrefs.SetFloat("size", slider.value);
            print(slidertype);
                break;

            case SliderType.reso:
            PlayerPrefs.SetInt("reso", (int)slider.value);
            print(slidertype);

                break;

            case SliderType.height:
            PlayerPrefs.SetFloat("height", slider.value);
            print(slidertype);

                break;

            case SliderType.scale:
            PlayerPrefs.SetFloat("scale", slider.value);
            print(slidertype);

                break;

            case SliderType.speed:
            PlayerPrefs.SetFloat("speed", slider.value);
            print(slidertype);

                break;

            case SliderType.noise:
            PlayerPrefs.SetFloat("noise", slider.value);
            print(slidertype);

                break;

            case SliderType.xmult:
            PlayerPrefs.SetFloat("xmult", slider.value);
            print(slidertype);

                break;

            case SliderType.zmult:
            PlayerPrefs.SetFloat("zmult", slider.value);
            print(slidertype);

                break;

            default:
                print("whoops");
                break;

        }
        
	}
}
