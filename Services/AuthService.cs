using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuthService
{
    public bool Login(string username, string password)
    {
        // Replace with real authentication logic
        return username == "admin" && password == "password";
    }
}