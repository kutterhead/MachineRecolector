using UnityEngine;

public class gripper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Rigidbody body;
    public GameObject grippedObject;    

    public ClawController clawController;

    bool gripped = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && clawController.garraAbiertaCerrada==true && gripped==false)
        {
            grippedObject = other.gameObject;
            //Destroy(other.gameObject);
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //other.transform.SetParent(transform.parent);

            other.gameObject.AddComponent<CharacterJoint>();
            other.gameObject.GetComponent<CharacterJoint>().connectedBody = body;

            gripped = true;
        }
    }
    /*
        private void OnTriggerEnter(Collider other)
        {
           if(other.gameObject.CompareTag("Item")){

                //Destroy(other.gameObject);
                //other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //other.transform.SetParent(transform.parent);

                other.gameObject.AddComponent<CharacterJoint>();
                other.gameObject.GetComponent<CharacterJoint>().connectedBody = body;   


            }
        }
    */


    public void sueltaObjeto()
    {
        if (grippedObject)
        {
            Destroy(grippedObject.GetComponent<CharacterJoint>());
        }


    }

}
