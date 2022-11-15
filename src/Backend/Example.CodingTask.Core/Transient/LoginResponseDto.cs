using System;

namespace Example.CodingTask.Core.Transient
{
    public class LoginResponseDto
    {
        public string UserName { set; get; }

        public Guid Id { set; get; }

        public string Token { set; get; }

        public string RefreshToken { set; get; }
    }
}
