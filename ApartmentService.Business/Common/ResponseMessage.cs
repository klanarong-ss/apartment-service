using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.Business.Common
{
    public static class ResponseMessage
    {
        public static string Success = "Success";
        public static string InsertSuccess = "Insert Success";
        public static string DeleteSuccess = "Delete Success";
        public static string UpdateSuccess = "Update Success";
        public static string GenerateBillingSuccess = "Generate Billing Success";
        public static string NotFoundRoomSetting = "Not Found Room Setting";
        public static string GenerateBillingAlready = "รอบบิลนี้มีอยู่แล้ว";
    }
}
