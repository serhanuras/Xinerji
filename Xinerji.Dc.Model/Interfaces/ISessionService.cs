using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface ISessionService : IDisposable
    {
        Session CreateSession(long customerId, ChannelCodeEnum channelCode, long firmId, LanguageEnum languageEnum);

        Session FindSession(string Id, ChannelCodeEnum channelCode);

        Session ChangeLanguage(Session session, LanguageEnum language);

        bool ChangeSessionStatus(string Id, SessionStatusEnum status, ChannelCodeEnum channelCode);

        string CreateToken(Session session);

        Session ParseToken(string token);

        List<SessionData> GetSessionDataList(long sessionId);

        List<SessionData> InsertSessionData(SessionData sessionData);

        List<SessionData> InsertSessionData<T>(long sessionId, string key, T data);

        SessionData GetSessionData(long sessionId, string key);

        T GetSessionDataValueAsObject<T>(long sessionId, string key);
    }
}
