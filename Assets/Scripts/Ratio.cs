
using UnityEngine;
 
public class AspectRatioUtility : MonoBehaviour
{
    private Vector3 scale;
    void Start()
    {
        scale = transform.localScale;
        Adjust();
    }
 
    public void Adjust()
    {
       
        float targetaspect = 16f / 9.0f;
 
        float windowaspect = (float)Screen.width / (float)Screen.height;
 
        float scaleheight = windowaspect / targetaspect;
        
 
        if (scaleheight < 1.0f)
        { 
            
            
            scale = transform.localScale;
            scale.x = 0.7f;
            transform.localScale = scale;
            Debug.Log("tue");
          
        }
        else
        {
            scale = transform.localScale;
            scale.x = 1.0f;
            transform.localScale = scale;
            Debug.Log("rue");
        }
 
    }
}