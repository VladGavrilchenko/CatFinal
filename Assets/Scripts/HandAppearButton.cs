using UnityEngine;
using UnityEngine.UI; 
public class HandAppearButton : MonoBehaviour
{
    public Button showHandButton; 
    public GameObject handObject;  
    public float handVisibleTime = 2f;  

    private void Start()
    {
        
        if (handObject != null)
        {
            handObject.SetActive(false);  
        }

       
        if (showHandButton != null)
        {
            showHandButton.onClick.AddListener(ShowHand);
        }

    }

    
    private void ShowHand()
    {
        if (handObject != null)
        {
           
            handObject.SetActive(true);
          
            StartCoroutine(HideHandAfterTime(handVisibleTime));
        }
    }

    
    private System.Collections.IEnumerator HideHandAfterTime(float time)
    {
        yield return new WaitForSeconds(time);  
        if (handObject != null)
        {
            handObject.SetActive(false);
        }
    }
}
