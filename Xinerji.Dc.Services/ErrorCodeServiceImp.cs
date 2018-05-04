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

namespace Xinerji.Dc.Services
{
    public class ErrorCodeServiceImp : IErrorCodeService
    {
        #region Local Variables
        private const int SUCCEED_CODE = 0;
        private const string SUCCEED_DESC = "SUCCEED";
        private const int UNKNOWN_CODE = -1;
        private const string UNKNOWN_DESC = "UNKNOWN!";


        SPExecutor spExecutor;
        #endregion

        #region Constructor
        public ErrorCodeServiceImp()
        {

        }
        #endregion

        #region FindDescription
        private Error FindDescription(int ErrorCode, ChannelCodeEnum channelCode)
        {
            Error errorDescription = null;
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_findDescriptionByErrorCode",
                         new object[] { ErrorCode, (int)channelCode });

                errorDescription = ErrorDataBinder.ToErrorDescription(dv);

                if (errorDescription == null)
                {
                    dv = spExecutor.ExecSProcDV("usp_findDescriptionByErrorCode",
                     new object[] { errorDescription.ErrorCode, (int)ChannelCodeEnum.General });

                    errorDescription = ErrorDataBinder.ToErrorDescription(dv);

                    if (errorDescription == null)
                    {
                        errorDescription = new Error();
                        errorDescription.ErrorCode = UNKNOWN_CODE;
                        errorDescription.ErrorDescriptionENG = UNKNOWN_DESC;
                        errorDescription.ErrorDescriptionTR = UNKNOWN_DESC;
                        errorDescription.DateLastModified = DateTime.Now;
                    }
                }
            }

            return errorDescription;
        }
        #endregion

        #region FindDescriptionByErrorCode
        public Error FindDescriptionByErrorCode(Error errorDescription)
        {
            using (spExecutor = new SPExecutor())
            {
                if (errorDescription.ErrorCode == SUCCEED_CODE)
                {
                    errorDescription.ErrorCode = SUCCEED_CODE;
                    errorDescription.ErrorDescriptionENG = SUCCEED_DESC;
                    errorDescription.ErrorDescriptionTR = SUCCEED_DESC;
                    errorDescription.DateLastModified = DateTime.Now;
                }
                else
                {
                    errorDescription = FindDescription(errorDescription.ErrorCode, errorDescription.ChannelCode);

                    if (errorDescription == null)
                    {
                        errorDescription = new Error();
                        errorDescription.ErrorCode = UNKNOWN_CODE;
                        errorDescription.ErrorDescriptionENG = UNKNOWN_DESC;
                        errorDescription.ErrorDescriptionTR = UNKNOWN_DESC;
                        errorDescription.DateLastModified = DateTime.Now;

                    }
                }

                return errorDescription;
            }
        }
        #endregion

        #region FindDescriptionById
        public Error FindDescriptionById(long id)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_findDescriptionById",
                      new object[] { id });

                return ErrorDataBinder.ToErrorDescription(dv);
            }
        }
        #endregion

        #region FindDescriptionByException
        public Error FindDescriptionByException(Exception ex)
        {
            if (ex is SessionNotFoundException)
            {
                return FindDescriptionByErrorCode(new Error() { ErrorCode = 998, ChannelCode = ChannelCodeEnum.General });
            }
           
            else if (ex is NoDataFoundException)
            {
                return FindDescriptionByErrorCode(new Error() { ErrorCode = 19, ChannelCode = ChannelCodeEnum.General });
            }
            else if (ex is ThirdPartyServiceException)
            {
                return new Error()
                {
                    ErrorCode = 990,
                    ErrorDescriptionTR = ex.Message
                };
            }
            else
            {
                return FindDescriptionByErrorCode(new Error() { ErrorCode = 999, ChannelCode = ChannelCodeEnum.General });
            }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
    }
}
