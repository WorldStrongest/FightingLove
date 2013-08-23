using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum InputCommand
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
	Queue<InputCommand> Inputs;
	int lineCount;
	int rectX;
	int rectY;
	
	void Awake()
	{
		Inputs = new Queue<InputCommand>();
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
		foreach( int i in Inputs )
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
			Inputs.Enqueue( InputCommand.UpRight );
		}
		else if( Input.GetKey( KeyCode.W ) && Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( InputCommand.UpLeft );
		}
		else if( Input.GetKey( KeyCode.S ) && Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( InputCommand.DownLeft );
		}
		else if( Input.GetKey( KeyCode.S ) && Input.GetKey( KeyCode.D ) )
		{
			Inputs.Enqueue( InputCommand.DownRight );
		}
		else if( Input.GetKey( KeyCode.W ) )
		{
			Inputs.Enqueue( InputCommand.Up );
		}
		else if( Input.GetKey( KeyCode.A ) )
		{
			Inputs.Enqueue( InputCommand.Left );
		}
		else if( Input.GetKey( KeyCode.S ) )
		{
			Inputs.Enqueue( InputCommand.Down );
		}
		else if( Input.GetKey( KeyCode.D ) )
		{
			Inputs.Enqueue( InputCommand.Right) ;
		}
	}
}
