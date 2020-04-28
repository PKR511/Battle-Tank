using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GenericSingleton <T>: MonoBehaviour where T : GenericSingleton<T>{

	//private variable
	private static T instance;

	//public Property
	public static T Instance {get{return instance;}}

	//Methods
	protected virtual void Awake(){
		
		// if the singleton hasn't been initialized yet
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
		} else {
			instance = (T)this;
		}
		//DontDestroyOnLoad( this.gameObject );
	
	}//Awake





}//Class
