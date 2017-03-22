using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRepeat : MonoBehaviour {

    private static AudioRepeat instance = null;
    public static AudioRepeat Instance
    {
        get { return instance; }
    }
    void Awake() {
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
             return;
         } else {
             instance = this;
         }
         DontDestroyOnLoad(this.gameObject);
     }

}
