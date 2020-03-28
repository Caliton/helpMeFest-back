using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Services.Utils
{
    public class CryptoPass
    {
        private readonly string passwd;
        private Guid id;

        public CryptoPass(string pass, Guid Id)
        {
            this.passwd = pass;
            this.id = Id;
        }

        public string HashPass()
        {
            var salt = this.id.ToByteArray();
            var hashed = KeyDerivation.Pbkdf2(
                password: this.passwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );
            return Convert.ToBase64String(hashed);
        }
    }
}
