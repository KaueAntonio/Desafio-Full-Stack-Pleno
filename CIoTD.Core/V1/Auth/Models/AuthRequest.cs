﻿namespace CIoTD.Core.V1.Auth.Models;

public class AuthRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}