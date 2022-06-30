using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent finalMoment;
    public UnityEvent failMoment;
    public int gold;
    public ParticleSystem goldTakeVfx;
    public GameObject goldicon;
    public TextMeshProUGUI goldText;
    public AstroidRotation astroidRotation;
    public float sayac;


    private void Update()
    {
        sayac += Time.deltaTime;
    }
    private void Awake()
    {
        instance = this;
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = gold.ToString();
    }
    public void UpdateGoldUI()
    {
        goldText.text = gold.ToString();
    }
    public void Next()
    {
        PlayerPrefs.SetInt("gold", gold);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

}
