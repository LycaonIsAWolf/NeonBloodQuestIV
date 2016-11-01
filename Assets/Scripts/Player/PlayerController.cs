using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
	public static PlayerController player;
	public float speed;
	public float jumpForce;
	public bool isWalking;

	public Yarn.Unity.DialogueRunner dialogue;
	public SimpleSmoothMouseLook mouseLook;
	public Crosshair crosshair;

	private Rigidbody rigid;
	private bool grounded;

	public void SetPosition(Vector3 pos){
		transform.position = new Vector3(pos.x, 2, pos.y);
	}

	void Start(){
		player = this;
		rigid = GetComponent<Rigidbody>();
		dialogue = GameObject.Find("DialogueHandler").GetComponent<Yarn.Unity.DialogueRunner>();
		crosshair = GameObject.Find("Crosshair").GetComponent<Crosshair>();

	}

	void OnCollisionEnter(){
		grounded = true;
	}

	void Update(){
		crosshair.canInteract = false;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1)){
			Character c = hit.transform.gameObject.GetComponent<Character>();
			if(c != null){
				crosshair.canInteract = true;
				if(Input.GetButtonDown("Interact") && !dialogue.isDialogueRunning){
					dialogue.StartDialogue(c.name);
				}
			}
		}

		if(Input.GetMouseButtonDown(1)){
			Application.CaptureScreenshot("screenshot-"+Random.Range(1000,9999) +".png");
		}
	}
	
	void FixedUpdate () {
		rigid.velocity = new Vector3(0, Mathf.Clamp(rigid.velocity.y, Mathf.NegativeInfinity, jumpForce), 0);

		if(!dialogue.isDialogueRunning){
			mouseLook.lockMovement = false;

			//Get inputs for movement
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			if(horizontal != 0 || vertical != 0){
				isWalking = true;
			}
			else{
				isWalking = false;
			}
			
			Vector3 dir = new Vector3(horizontal, 0, vertical);
			dir *= Time.deltaTime;
			dir *= speed;

			dir = transform.TransformDirection(dir);

			rigid.AddForce(dir);

			if(Input.GetButton("Jump") && grounded){
				rigid.AddForce(Vector3.up * jumpForce);
				grounded = false;
			}
		}
		else{
			mouseLook.lockMovement = true;
		}

	}

}

