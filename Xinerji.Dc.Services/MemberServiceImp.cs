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
using Xinerji.Integration;
using Xinerji.Utilities;

namespace Xinerji.Dc.Services
{
    public class MemberServiceImp : IMemberService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public Member ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeMemberStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<Member> GetAll(long firmId)
        {
            List<Member> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getMembers",
                        new object[] {
                            firmId
                        });

                    returnValue = MemberDataBinder.ToMemberList(dv);
                }

                return returnValue;
            }
        }

        public Member GetById(long Id)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getMemberById",
                        new object[] {
                            Id
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }

        public Member GetByLogonCrendetial(string email, string password)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                password = CryptoUtil.SHA256Encrypt(password);

                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getByLogonCrendetial",
                        new object[] {
                            email,
                            password
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }

        public Member Insert(Member member)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                member.Password = CryptoUtil.SHA256Encrypt(member.Password);
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertMember",
                        new object[] {
                            member.FirmId,
                            member.TCIdentifier,
                            member.Name,
                            member.MiddleName,
                            member.Surname,
                            member.Birthdate,
                            member.Email,
                            member.CompanyId,
                            member.Password,
                            member.Phone,
                            member.MemberTypeId,                            
                            (int)member.Status
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }

        public Member Update(Member member)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateMember",
                        new object[] {
                            member.Id,
                            member.TCIdentifier,
                            member.Name,
                            member.MiddleName,
                            member.Surname,
                            member.Birthdate,
                            member.Email,
                            member.CompanyId,
                            member.Password,
                            member.Phone,
                            member.MemberTypeId,
                            (int)member.Status
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }

        public Member UpdatePassword(Member member)
        {
            Member returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateMemberPassword",
                        new object[] {
                            member.Id,
                            member.Password
                        });

                    returnvalue = MemberDataBinder.ToMember(dv);
                }

                return returnvalue;
            }
        }
    }
}
