﻿namespace PicnicAuthNetClient.Models
{
    // ReSharper disable InconsistentNaming
    // in order to be compatible with OAuth Client
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }
}