using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats{
	private static int kills, health, blackPearls,inLayer;

	 public static int Kills 
    {
        get 
        {
            return kills;
        }
        set 
        {
            kills = value;
        }
    }

	public static int Health 
    {
        get 
        {
            return health;
        }
        set 
        {
            health = value;
        }
    }

		public static int BlackPearls
    {
        get 
        {
            return blackPearls;
        }
        set 
        {
            blackPearls = value;
        }
    }

    public static int InLayer
    {
        get 
        {
            return inLayer;
        }
        set 
        {
            inLayer = value;
        }
    }

}