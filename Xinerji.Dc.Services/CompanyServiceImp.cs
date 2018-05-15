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
        
        public Tuple<List<Company>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage)
        {
            List<Company> companies = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataSet ds = spExecutor.ExecSProcDS("usp_getCompanies",
                        new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage
                        });

                    companies = CompanyDataBinder.ToCompanyList(ds.Tables[0].DefaultView);

                    totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());
                }

                return new Tuple<List<Company>, int>(companies, totalPageSize); ;
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

        
        public Tuple<List<Company>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInPage, string data)
        {
            List<Company> companies = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataSet ds = spExecutor.ExecSProcDS("usp_searchCompanies",
                        new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage,
                            data
                        });

                    companies = CompanyDataBinder.ToCompanyList(ds.Tables[0].DefaultView);

                    totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());
                }

                return new Tuple<List<Company>, int>(companies, totalPageSize); ;
            }
        }

        public Company GetById(long Id)
        {
            Company returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getCompanyById",
                        new object[] {
                            Id
                        });

                    returnvalue = CompanyDataBinder.ToCompany(dv);
                }

                return returnvalue;
            }
        }
    }
}
