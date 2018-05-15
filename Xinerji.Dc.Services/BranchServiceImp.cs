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

        public Tuple<List<Branch>, int> GetAll(long companyId, int selectedPageNumber, int numberOfItemsInPage)
        {
            List<Branch> branches = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                if (branches == null)
                {
                    DataSet ds = spExecutor.ExecSProcDS("usp_getBranchList",
                        new object[] {
                            companyId,
                            selectedPageNumber,
                            numberOfItemsInPage
                        });

                    branches = BranchDataBinder.ToBranchList(ds.Tables[0].DefaultView);

                    totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());
                }

                return new Tuple<List<Branch>, int>(branches, totalPageSize); ;
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

        public Tuple<List<Branch>, int> Search(long companyId, int selectedPageNumber, int numberOfItemsInPage, string data)
        {
            List<Branch> branches = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                if (branches == null)
                {
                    DataSet ds = spExecutor.ExecSProcDS("usp_searchBranches",
                        new object[] {
                            companyId,
                            selectedPageNumber,
                            numberOfItemsInPage,
                            data
                        });

                    branches = BranchDataBinder.ToBranchList(ds.Tables[0].DefaultView);

                    totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());
                }

                return new Tuple<List<Branch>, int>(branches, totalPageSize); ;
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
