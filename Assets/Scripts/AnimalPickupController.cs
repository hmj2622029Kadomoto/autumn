using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimalPickupController : MonoBehaviour
{
	[SerializeField] Transform holdPoint;
	[SerializeField] float pickupRange = 3f;

	[SerializeField] float throwPower = 8f;
	[SerializeField] float throwUpPower = 5f;

	[SerializeField] AudioClip throwSE;

	[SerializeField] float pickupCooldown = 0.5f;

	AudioSource audioSource;
	float pickupCooldownTimer;

	// 現在持っているオブジェクト
	PickupObject heldObject;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (pickupCooldownTimer > 0f)
		{
			pickupCooldownTimer -= Time.deltaTime;
		}
		else
		{
			TryPickup();
		}
		if (Keyboard.current.eKey.wasPressedThisFrame)
		{
			ThrowObject();
		}
	}

	void TryPickup()
	{
		// すでに持っているなら拾わない
		if(heldObject != null)
		{
			return;
		}

		if(holdPoint == null)
		{
			return;
		}
		Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);

		foreach(Collider collider in colliders)
		{
			PickupObject pickupObject = collider.GetComponentInParent<PickupObject>();
			if(pickupObject == null)
			{
				continue;
			}
			pickupObject.Pickup(holdPoint);

			// 今持ったオブジェクトを記録
			heldObject = pickupObject;
			break;
		}
	}

	void ThrowObject()
	{
		// 持ってないなら何もしない
		if(heldObject == null)
		{
			return;
		}
		Vector3 throwDirection = transform.forward;
		heldObject.Throw(throwDirection,throwPower,throwUpPower);

		if(throwSE != null)
		{
			audioSource.PlayOneShot(throwSE);
		}
		heldObject = null;
		pickupCooldownTimer = pickupCooldown;
	}
}
