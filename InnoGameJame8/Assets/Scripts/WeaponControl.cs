using UnityEngine;
using System.Collections;

 //[ExecuteInEditMode]
public class WeaponControl : MonoBehaviour {

    [SerializeField]
    Transform rightHand;

    [SerializeField]
    Transform leftHand;

    [SerializeField]
    GameObject weapon;

    GameObject weaponLeft;
    GameObject weaponRight;

    // Use this for initialization
	void Start () {
        //for (int i = 0; i < 10; i++ )
        //{ 
            AttachWeapons();
        //}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AttachWeapons()
    {
        AttachWeaponToHand(this.weaponLeft, this.leftHand);
        AttachWeaponToHand(this.weaponRight, this.rightHand);
    }

    public void AttachWeaponToHand(GameObject weapon, Transform slot)
    {
        weapon = Instantiate(this.weapon, slot.position, slot.rotation) as GameObject;
        //this.weaponRight.transform.parent = this.rightHand;
        weapon.GetComponent<SpringJoint>().connectedBody = slot.GetComponent<Rigidbody>();
    }


}
