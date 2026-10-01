using UnityEngine;

public class PickupObject : MonoBehaviour
{
	public void Pickup(Transform holdPoint)
	{
		Rigidbody rbody = GetComponent<Rigidbody>();
		if(rbody != null)
		{
			// 拾う前に速度をリセット
			if(!rbody.isKinematic)
			{
				rbody.linearVelocity = Vector3.zero;
				rbody.angularVelocity = Vector3.zero;
			}
			// 物理演算を止める
			rbody.isKinematic = true;
		}
		// 子にあるColliderも含めて無効化
		Collider[] colliders = GetComponentsInChildren<Collider>();

		foreach(Collider collider in colliders)
		{
			collider.enabled = false;
		}
		// 頭の上に親子付け
		transform.SetParent(holdPoint);

		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Throw(Vector3 direction,float throwPower,float throwUpPower)
	{
		// 親子関係を解除
		transform.SetParent(null);
		// Colliderを有効化
		Collider[] colliders = GetComponentsInChildren<Collider>();

		foreach (Collider collider in colliders)
		{
			collider.enabled = true;
		}
		Rigidbody rbody = GetComponent<Rigidbody>();
		if(rbody != null)
		{
			// 物理演算を有効化
			rbody.isKinematic = false;
			// 投げる速度を設定
			Vector3 velocity = direction.normalized * throwPower;
			velocity.y += throwPower;

			rbody.linearVelocity = velocity;
		}
	}
}
