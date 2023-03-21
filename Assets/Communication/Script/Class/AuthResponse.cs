using System;

[Serializable]
public class AuthResponse
{
	public string token;
	public string refreshToken;
	public string scope;
	public override string ToString()
	{
		return UnityEngine.JsonUtility.ToJson(this, true);
	}
}


