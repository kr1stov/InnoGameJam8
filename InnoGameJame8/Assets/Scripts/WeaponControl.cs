using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

    [SerializeField]
    private Transform rightHand;

    [SerializeField]
    private Transform leftHand;

    [SerializeField]
    private GameObject weaponPrefab;

    [SerializeField]
    private int melonsPerHand;

    private GameObject weaponLeft;
    private GameObject weaponRight;



    // Use this for initialization
	void Start () {
        for (int i = 0; i < melonsPerHand; i++)
        { 
            AttachWeapons();
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AttachWeapons()
    {
        AttachWeaponToHand(out this.weaponLeft, this.leftHand);
        AttachWeaponToHand(out this.weaponRight, this.rightHand);
    }

    public void AttachWeaponToHand(out GameObject weapon, Transform slot)
    {
        weapon = Instantiate(this.weaponPrefab, slot.position, slot.rotation) as GameObject;
        //this.weaponRight.transform.parent = this.rightHand;
        weapon.GetComponent<SpringJoint>().connectedBody = slot.GetComponent<Rigidbody>();

        LineRendererManager lrm = weapon.GetComponent<LineRendererManager>();
        lrm.SetSlot(slot.gameObject);
        //lrm.vCount = 4;

        LineRenderer lr = weapon.GetComponent<LineRenderer>();
        //lr.SetVertexCount(lrm.vCount);
        
        lr.SetPosition(0, slot.position);
    }




}
