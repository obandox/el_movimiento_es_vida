using UnityEngine;
using System.Collections;

//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class ExtensionMethods
{
		public static Transform Search(this Transform target, string name)
		{
			if (target.name == name) return target;
			
			for (int i = 0; i < target.childCount; ++i)
			{
				var result = Search(target.GetChild(i), name);
				
				if (result != null) return result;
			}
			
			return null;
		}
	
}