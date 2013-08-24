using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InputCommand
{
	Up,
	UpRight,
	Right,
	DownRight,
	Down,
	DownLeft,
	Left,
	UpLeft,
	light,
	medium,
	heavy,
	special
};



public class InputManager : MonoBehaviour {
	public struct playerInput
	{
		public InputCommand input;
		public float timeAlive;
		
		public playerInput( InputCommand input, float timeAlive )
		{
			this.input = input;
			this.timeAlive = timeAlive;
		}
	};
	Queue<playerInput> Inputs;
	static float MAX_TIME_TO_LIVE = .3f;
	//for displaying on GUI
	int lineCount;
	int rectX;
	int rectY;
	
	void Awake()
	{
		Inputs = new Queue<playerInput>();
	}
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		AddCommand();
		while( Inputs.Count > 8 )
		{
			Inputs.Dequeue();
		}
//		lineCount = 0;
		Debug.Log( Inputs.Count );
	}
	
	void OnGUI()
	{
		foreach( int i in Inputs.input )
		{
			rectY = lineCount * 30 + 50;
			++lineCount;
			GUI.Label( new Rect( 50, rectY, 125, 125 ), i+"\n" );
		}
		lineCount = 0;
	}
	
	void AddCommand()
	{
		if( Input.GetKey( KeyCode.W ) && Input.GetKey( KeyCode.D ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.UpRight, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.W ) && Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.UpLeft, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.S ) && Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.DownLeft, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.S ) && Input.GetKey( KeyCode.D ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.DownRight, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.W ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.Up, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.Left, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.S ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.Down, Time.time + MAX_TIME_TO_LIVE ) );
		}
		else if( Input.GetKey( KeyCode.D ) )
		{
			Inputs.Enqueue( new playerInput( InputCommand.Right, Time.time + MAX_TIME_TO_LIVE ) ) ;
		}
	}
}
