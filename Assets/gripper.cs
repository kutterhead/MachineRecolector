using UnityEngine;

public class gripper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        


    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Item")){

            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.SetParent(transform.parent);


        }
    }

}
