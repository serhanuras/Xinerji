using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Exceptions;
using Xinerji.Integration;
using Xinerji.Jwt;
using Xinerji.Jwt.Algorithms;
using Xinerji.Jwt.Serializers;
using Xinerji.Utilities;

namespace Xinerji.Dc.Services
{

    public class SessionServiceImp : ISessionService
    {
        const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";


        #region LocalVariables
        SPExecutor spExecutor;
        #endregion

        #region Constructor
        public SessionServiceImp()
        {

        }
        #endregion

        #region CreateSession
        public Session CreateSession(long customerId, ChannelCodeEnum channelCode)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_createSession",
                       new object[] {
                       customerId,
                       channelCode,
                       SessionStatusEnum.Active,
                       DateTime.Now,
                       DateTime.Now
                       });

                Session session = SessionDataBinder.ToSession(dv);
                session.Token = CreateToken(session);

                return session;
            }
        }
        #endregion

        #region CreateToken
        public string CreateToken(Session session)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode<Session>(session, secret);

            return token;
        }
        #endregion

        #region ParseToken
        public Session ParseToken(string token)
        {
            if (token != "")
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                return decoder.DecodeToObj<Session>(token, secret, verify: true);
            }
            else
            {
                return new Session();
            }
        }
        #endregion

        #region FindSession
        public Session FindSession(string token, ChannelCodeEnum channelCode)
        {
            using (spExecutor = new SPExecutor())
            {
                Session tmpSession = ParseToken(token);

                DataView dv = spExecutor.ExecSProcDV("usp_findSession",
                        new object[] { tmpSession.Id });

                if (dv.Count == 0)
                {
                    throw new SessionNotFoundException();
                }

                Session session = SessionDataBinder.ToSession(dv);

                if (tmpSession.CustomerId != session.CustomerId || tmpSession.CreateDateTime != session.CreateDateTime)
                {
                    throw new SessionNotFoundException();
                }

                TimeSpan timeDifference = DateTime.Now.Subtract(session.LastModifiedDateTime);


                if (timeDifference.Minutes > 15 || session.Status != SessionStatusEnum.Active)
                {
                    ChangeSessionStatus(token, SessionStatusEnum.Timeout, channelCode);

                    throw new SessionNotFoundException();
                }

                return session;
            }
        }
        #endregion

        #region ChangeSessionStatus
        public bool ChangeSessionStatus(string token, SessionStatusEnum status, ChannelCodeEnum channelCode)
        {
            using (spExecutor = new SPExecutor())
            {
                Session tempSession = ParseToken(token);

                return spExecutor.ExecSProc("usp_changeSessionStatus",
                       new object[] { tempSession.Id, (int)status });
            }
        }
        #endregion

        #region GetSessionDataList
        public List<SessionData> GetSessionDataList(long sessionId)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_getSessionData",
                  new object[] {
                       sessionId
                  });


                return SessionDataDataBinder.ToSessionDataList(dv);
            }
        }
        #endregion

        #region InsertSessionData
        public List<SessionData> InsertSessionData(SessionData sessionData)
        {
            using (spExecutor = new SPExecutor())
            {
                List<SessionData> sessionDataList = GetSessionDataList(sessionData.SessionId);

                DataView dv;
                if (sessionDataList == null)
                {
                    dv = spExecutor.ExecSProcDV("usp_insertSessionData",
                        false,
                    new object[] {
                       sessionData.SessionId,
                       sessionData.Key,
                       sessionData.Value,
                       sessionData.InsertDateTime
                    });

                    sessionDataList = SessionDataDataBinder.ToSessionDataList(dv);
                }
                else
                {
                    sessionDataList = sessionDataList.Where(e => e.Key == sessionData.Key).ToList();

                    if (sessionDataList.Count > 0)
                    {
                        dv = spExecutor.ExecSProcDV("usp_updateSessionData",
                            false,
                                 new object[] {
                                   sessionDataList[0].Id,
                                   sessionData.Value
                                 });

                        sessionDataList = SessionDataDataBinder.ToSessionDataList(dv);
                    }
                    else
                    {

                        dv = spExecutor.ExecSProcDV("usp_insertSessionData",
                            false,
                           new object[] {
                               sessionData.SessionId,
                               sessionData.Key,
                               sessionData.Value,
                               sessionData.InsertDateTime
                           });

                        sessionDataList = SessionDataDataBinder.ToSessionDataList(dv);
                    }

                }


                return sessionDataList;
            }

        }
        #endregion

        #region GetSessionData
        public SessionData GetSessionData(long sessionId, string key)
        {

            List<SessionData> sessionDataList = GetSessionDataList(sessionId);

            if (sessionDataList == null)
            {
                return null;
            }
            else
            {
                sessionDataList = sessionDataList.Where(e => e.Key == key).ToList();

                if (sessionDataList.Count > 0)
                    return sessionDataList[0];
                else
                    return null;
            }
        }
        #endregion

        #region InsertSessionData
        public List<SessionData> InsertSessionData<T>(long sessionId, string key, T data)
        {
            SessionData sessionData = new SessionData
            {
                SessionId = sessionId,
                Key = key,
                Value = JsonSerializer.Seralize<T>(data),
                InsertDateTime = DateTime.Now
            };

            return InsertSessionData(sessionData);
        }
        #endregion

        #region GetSessionDataValueAsObject
        public T GetSessionDataValueAsObject<T>(long sessionId, string key)
        {
            SessionData sessionData = GetSessionData(sessionId, key);

            return JsonSerializer.Deserialize<T>(sessionData.Value);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
    }
}
