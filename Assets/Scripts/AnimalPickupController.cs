using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimalPickupController : MonoBehaviour
{
	[SerializeField] private Transform holdPoint;
	[SerializeField] private float pickupRange = 3f;

	[SerializeField] private float throwPower = 8f;
	[SerializeField] private float throwUpPower = 5f;

	[SerializeField] private float pickupCooldown = 0.5f;

	private float pickupCooldownTimer;

	// 現在持っているオブジェクト
	private PickupObject heldObject;

	private void Update()
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

	private void TryPickup()
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

	private void ThrowObject()
	{
		// 持ってないなら何もしない
		if(heldObject == null)
		{
			return;
		}
		Vector3 throwDirection = transform.forward;
		heldObject.Throw(throwDirection,throwPower,throwUpPower);
		heldObject = null;
		pickupCooldownTimer = pickupCooldown;
	}
}
