using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Enumurations
{
    public enum MessagingTemplateEnum
    {
        InternetBankingOTP = 1,
        InternetBankingMoneyTransferConfirmationOTP = 2,
        NewApplyEmail = 3,
        NewApplicationAcceptEmail = 4,
        NewApplicationRejectEmail = 5,
        Receipt = 6,
        ReNewPasswordSMS = 7,
        ReNewPasswordMail = 8,
        UpdateCellPhoneEmail = 9,
        InternetBankingRemindPassword = 10,
        UpdateCustomerInformation = 11
    }
}
