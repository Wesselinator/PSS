using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    public static class PSSListExtentions
    {
        public static BaseList<T> ToBaseList<T>(this IEnumerable<T> source) where T : BaseTable, new()
        {
            BaseList<T> ret = new BaseList<T>();
            foreach (T item in source)
            {
                ret.Add(item);
            }
            return ret;
        }

        public static BaseList<ServiceRequest> GetServiceRequests(this MultiIDList<BusinessClientServiceRequest> BCSRs)
        {
            return BCSRs.Select(bcsr => bcsr.ServiceRequest).ToBaseList();
        }

        public static BaseList<ServiceRequest> GetServiceRequests(this MultiIDList<IndividualClientServiceRequest> ICSRs)
        {
            return ICSRs.Select(icsr => icsr.ServiceRequest).ToBaseList();
        }


        public static BaseList<Contract> GetContracts(this MultiIDList<BusinessClientContract> BCCs)
        {
            return BCCs.Select(bcc => bcc.Contract).ToBaseList();
        }

        public static BaseList<Contract> GetContracts(this MultiIDList<IndividualClientContract> ICCs)
        {
            return ICCs.Select(icc => icc.Contract).ToBaseList();
        }


        public static BaseList<FollowUpReport> GetFollowUps(this MultiIDList<BusinessClientFollowUp> BCFUs)
        {
            return BCFUs.Select(bcfu => bcfu.FollowUp).ToBaseList();
        }

        public static BaseList<FollowUpReport> GetFollowUps(this MultiIDList<IndividualClientFollowUp> ICFUs)
        {
            return ICFUs.Select(icfu => icfu.FollowUp).ToBaseList();
        }

        public static BaseList<Person> GetBusinessClientPeople(this MultiIDList<BusinessClientPerson> BCPs)
        {
            return BCPs.Select(bcp => bcp.Person).ToBaseList();
        }
    }
}
