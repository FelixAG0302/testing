

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Domain.Model;
using testing.Domain.Settings;

namespace testing.Application.Utils.SessionHandler
{
    public class CurrentSession
    {
        private readonly SessionKeys _sessionKeys;
        private readonly AuthenticationResponce _currentUserInfo;

        public CurrentSession(IHttpContextAccessor httpContextAccessor, IOptions<SessionKeys> sessionKeys)
        {
            _sessionKeys = sessionKeys.Value;
            _currentUserInfo = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
        }

        public static  bool IsAnUserLogIn()
        {
            return _currentUserInfo == null;
        }
    }
}
