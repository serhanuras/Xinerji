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
    public class BranchServiceImp : IBranchService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public Branch ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Branch returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeBranchStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = BranchDataBinder.ToBranch(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<Branch> GetAll(long companyId)
        {
            List<Branch> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getBranchList",
                        new object[] {
                            companyId
                        });

                    returnValue = BranchDataBinder.ToBranchList(dv);
                }

                return returnValue;
            }
        }

        public Branch GetById(long Id)
        {
            Branch returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getBranchById",
                        new object[] {
                            Id
                        });

                    returnvalue = BranchDataBinder.ToBranch(dv);
                }

                return returnvalue;
            }
        }

        public Branch Insert(Branch branch)
        {
            Branch returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertBranch",
                        new object[] {
                            branch.CompanyId,
                            branch.Name,
                            branch.Phone,
                            branch.Email,
                            branch.Location,
                            branch.Address,
                            (int)branch.Status
                        });

                    returnvalue = BranchDataBinder.ToBranch(dv);
                }

                return returnvalue;
            }
        }

        public Branch Update(Branch branch)
        {
            Branch returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateBranch",
                        new object[] {
                            branch.Id,
                            branch.CompanyId,
                            branch.Name,
                            branch.Phone,
                            branch.Email,
                            branch.Location,
                            branch.Address,
                            (int)branch.Status
                        });

                    returnvalue = BranchDataBinder.ToBranch(dv);
                }

                return returnvalue;
            }
        }
    }
}
