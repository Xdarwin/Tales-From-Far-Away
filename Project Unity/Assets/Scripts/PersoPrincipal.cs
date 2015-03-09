using UnityEngine;
using System.Collections;

public class PersoPrincipal : MonoBehaviour {

	private static int health;
	public static int Health {
		get { return health; }
		set {
			if (value < 0)
				health = 0;
			else if (value > health)
				health = max_health;
			else

				health = value;
		}
	}
	private static int max_health;
	public static int Max_Health{
		get { return max_health;}
		set {
			if (value <0)
				max_health = -value;
			else 
				max_health = value;
		}
	}

	void Start() {
		Max_Health = 100;
		Health = Max_Health;
	}

}
