﻿namespace RealTimeChat.ApplicationCore.Configuration
{
    public class JwtConfiguration
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double DurationInHours { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
    }
}
