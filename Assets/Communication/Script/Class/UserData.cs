using System;

[Serializable]
public class UserData
{
	public string username;
	public string password;
	public override string ToString()
	{
		return UnityEngine.JsonUtility.ToJson(this, true);
	}
}


