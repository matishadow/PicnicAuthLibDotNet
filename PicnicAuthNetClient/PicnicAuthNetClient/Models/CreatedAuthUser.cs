﻿using System;

namespace PicnicAuthNetClient.Models
{
    public class CreatedAuthUser
    {
        public string ExternalId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public Uri HotpQrCodeUri { get; set; }
        public Uri TotpQrCodeUri { get; set; }

        public string SecretInBase32 { get; set; }

        public Guid Id { get; set; }
    }
}