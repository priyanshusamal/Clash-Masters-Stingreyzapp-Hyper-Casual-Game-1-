using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class RunnerSkinManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform skinsParent;
    [SerializeField] private Renderer[] spriteRenderer;
    private int currentSpriteIndex;
    private bool Minimize = false;

    private void Awake()
    {
        ShopManager.onItemSelected += SetSkin;

        LoadData();
    }

    private void OnDestroy()
    {
        ShopManager.onItemSelected -= SetSkin;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSkin(currentSpriteIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(Minimize==true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale,new Vector3(0.5f,0.5f,0.5f),0.01f);
        }
    }


    public void StartRunning()
    {
        skinsParent.GetChild(currentSpriteIndex).GetComponent<Animator>().SetInteger("State", 1);
        Minimize = true;
    }

    public void StopRunning()
    {
        skinsParent.GetChild(currentSpriteIndex).GetComponent<Animator>().SetInteger("State", 0);
    }

    public void SetSkin(int skinIndex)
    {
        currentSpriteIndex = skinIndex;

        for (int i = 0; i < skinsParent.childCount; i++)
            skinsParent.GetChild(i).gameObject.SetActive(i == skinIndex);

        SaveData();
    }

    public void DisableRenderer()
    {
        foreach (Renderer renderer in spriteRenderer)
            renderer.enabled = false;        
    }
    public void EnableRenderer()
    {
        foreach (Renderer renderer in spriteRenderer)
            renderer.enabled = true;        
    }

    // public Color GetColor()
    // {
    //     return spriteRenderer[0].material.GetColor("_BaseColor");
    // }

    public int GetSkinIndex()
    {
        return currentSpriteIndex;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("LastSkin", currentSpriteIndex);
    }

    private void LoadData()
    {
        currentSpriteIndex = PlayerPrefs.GetInt("LastSkin");
    }
}
