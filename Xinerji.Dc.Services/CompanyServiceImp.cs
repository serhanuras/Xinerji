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
    public class CompanyServiceImp : ICompanyService
    {
        #region Local Variables
        SPExecutor spExecutor;
        private static List<Company> channelList = null;
        #endregion

        public Company ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Company company = null;
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeCompanyStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    company = CompanyDataBinder.ToCompany(dv);
                }

                return company;
            }
        }

        public void Dispose()
        {
            
        }

        public List<Company> GetAll(long firmId)
        {
            List<Company> companies = null;
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getCompanies",
                        new object[] {
                            firmId
                        });

                    companies = CompanyDataBinder.ToCompanyList(dv);
                }

                return companies;
            }
        }

        public Company Insert(Company company)
        {
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertCompany",
                        new object[] {
                            company.FirmId,
                            company.Name,
                            company.Address,
                            company.Email,
                            company.Phone,
                            company.Location,
                            (int)company.Status
                        });

                    company = CompanyDataBinder.ToCompany(dv);
                }

                return company;
            }
        }

        public Company Update(Company company)
        {
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateCompany",
                        new object[] {
                            company.Id,
                            company.Name,
                            company.Address,
                            company.Email,
                            company.Phone,
                            company.Location,
                            (int)company.Status
                        });

                    company = CompanyDataBinder.ToCompany(dv);
                }

                return company;
            }
        }
    }
}
