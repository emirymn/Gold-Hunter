using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class OyunCont : MonoBehaviour
{
    public bool oyunAktif = true;
    public int altinSayi = 0;
    public TextMeshPro altinsayitext;
    public Text altinsayitext2;
    public Button baslabuton;
    //public Button tekrarbuton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void AltinArttir()
    {
        altinSayi += 1;
        altinsayitext2.text = "" + altinSayi;
    }
    public void OyunaBasla()
    {
        oyunAktif = true;
        baslabuton.gameObject.SetActive(false);
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("levelbir");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("levelbir");
    }
}
