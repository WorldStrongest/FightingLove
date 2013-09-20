using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Transform _transform;
	public float speed;
	bool moveLeft;
	bool moveRight;
	
	void Awake ()
	{
		_transform = transform;
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown( KeyCode.A ) )
		{
			moveLeft = true;
			moveRight = false;
		}
		if( Input.GetKeyDown( KeyCode.D ) )
		{
			moveRight = true;
			moveLeft = false;
		}
		
		if( moveLeft )
		{
			_transform.position = new Vector3( _transform.position.x - speed, _transform.position.y, _transform.position.z );
		}
		else if( moveRight )
		{
			_transform.position = new Vector3( _transform.position.x + speed, _transform.position.y, _transform.position.z );
		}
		
		if( Input.GetKeyUp( KeyCode.A) )
		{
			moveLeft = false;
		}
		if( Input.GetKeyUp( KeyCode.D ) )
		{
			moveRight = false;
		}
	}
}
