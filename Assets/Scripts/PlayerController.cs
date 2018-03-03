using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {
    private Rigidbody rb;
    public float speed = 10f;
	public Text name;
	[SyncVar(hook="OnNameChange")] private string nameString;

    void Start() {
        rb = GetComponent<Rigidbody>();
		string[] names = new string[] { "Jack", "Jean", "Joan", "Janet", "John" };
		int r = Random.Range(0, names.Length - 1);
		nameString = names[r];
    }

    void FixedUpdate() {
        if (!isLocalPlayer) return;
             
        float moveHoz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveHoz*speed, 0, moveVert*speed));
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
        }
    }

    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
		GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnServerInitialized() {
        NetworkServer.SpawnObjects();
    }

	void OnNameChange(string name) {
		this.name.text = name;
	}

	public override void OnStartClient() {
		base.OnStartClient();
		OnNameChange(nameString);
	}
}
