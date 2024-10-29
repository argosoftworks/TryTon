using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    public GameObject[] poses;
    private Transform transform;
    public int index;
    
    public void TopLeft()
    {
        if (poses[0].activeSelf)
        {
            poses[0].SetActive(false);
            poses[1].SetActive(true);
            buttons[1].interactable = false;
            buttons[2].interactable = false;
            buttons[3].interactable = false;
            index = 1;
        }
    }
    public void BottomLeft()
    {
        if (poses[0].activeSelf)
        {
            poses[0].SetActive(false);
            poses[2].SetActive(true);
            buttons[0].interactable = false;
            buttons[2].interactable = false;
            buttons[3].interactable = false;
            index = 2;

        }
          
    }
    public void TopRight()
    {
        if (poses[0].activeSelf)
        {
            poses[0].SetActive(false);
            poses[3].SetActive(true);
            buttons[0].interactable = false;
            buttons[1].interactable = false;
            buttons[3].interactable = false;
            index = 3;
        }
    }

    public void BottomRight()
    {
        if (poses[0].activeSelf)
        {
            poses[0].SetActive(false);
            poses[4].SetActive(true);
            buttons[0].interactable = false;
            buttons[1].interactable = false;
            buttons[2].interactable = false;
            index = 4;
        }
    }

    public void Reset()
    {
        poses[index].SetActive(false);
        index = 0;
        for (int i = 0; i <= buttons.Length -1 ; i++)
        {
           buttons[i].interactable = true; 
           poses[0].SetActive(true);
        }
    }
    public void _setDefault()
    {
        poses[index].SetActive(false);
        index = 0;
        poses[0].SetActive(true);
        
    }
 }
