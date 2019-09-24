using System;

public static class Auth
{
	public static string CanLogin(string login, string password)
	{
        if (login == "admin" && password == "admin") return "admin";
        else if (login == "user" && password == "user") return "user";
        else return "guest";
    }
}
