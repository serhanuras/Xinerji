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
    public class UserLevelServiceImp : IUserLevelService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public UserLevel ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            UserLevel returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeUserLevelStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = UserLevelDataBinder.ToUserLevel(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
           
        }

        public List<UserLevel> GetAll(long firmId)
        {
            List<UserLevel> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getUserLevels",
                        new object[] {
                            firmId
                        });

                    returnValue = UserLevelDataBinder.ToToUserLevelList(dv);
                }

                return returnValue;
            }
        }

        public UserLevel Insert(UserLevel userLevel)
        {
            UserLevel returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertUserLevel",
                        new object[] {
                            userLevel.FirmId,
                            userLevel.Name,
                            (int) userLevel.Status
                        });

                    returnvalue = UserLevelDataBinder.ToUserLevel(dv);
                }

                return returnvalue;
            }
        }

        public UserLevel Update(UserLevel userLevel)
        {
            UserLevel returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateUserLevel",
                        new object[] {
                            userLevel.Id,
                            userLevel.Name,
                            userLevel.Status
                        });

                    returnvalue = UserLevelDataBinder.ToUserLevel(dv);
                }

                return returnvalue;
            }
        }
        
    }
}
