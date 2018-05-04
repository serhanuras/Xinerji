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


namespace Xinerji.Dc.Services
{
    public class MemberTypeServiceImp : IMemberTypeService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public MemberType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            MemberType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeMemberTypeStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = MemberTypeDataBinder.ToMemberType(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<MemberType> GetAll(long firmId)
        {
            List<MemberType> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getMemberTypes",
                        new object[] {
                            firmId
                        });

                    returnValue = MemberTypeDataBinder.ToMemberTypeList(dv);
                }

                return returnValue;
            }
        }

        public MemberType GetById(long Id)
        {
            MemberType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getMemberTypeById",
                        new object[] {
                            Id
                        });

                    returnvalue = MemberTypeDataBinder.ToMemberType(dv);
                }

                return returnvalue;
            }
        }

        public MemberType Insert(MemberType memberType)
        {
            MemberType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertMemberType",
                        new object[] {
                            memberType.FirmId,
                            memberType.UserLevelId,
                            memberType.Type,
                            memberType.Status
                        });

                    returnvalue = MemberTypeDataBinder.ToMemberType(dv);
                }

                return returnvalue;
            }
        }

        public MemberType Update(MemberType memberType)
        {
            MemberType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateMemberType",
                        new object[] {
                            memberType.Id,
                            memberType.UserLevelId,
                            memberType.Type,
                            memberType.Status
                        });

                    returnvalue = MemberTypeDataBinder.ToMemberType(dv);
                }

                return returnvalue;
            }
    }
}
