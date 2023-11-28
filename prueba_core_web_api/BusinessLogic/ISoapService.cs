using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ServiceModel;

namespace prueba_core_web_api.BusinessLogic
{
    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract]
        string Sum(int num1, int num2);

        [OperationContract]
        string Search(string s);

        [OperationContract]
        Task<List<ART_AFFILIATIONs>> RunDBContext();

        [OperationContract]
        Task<List<ART_AFFILIATIONs>> AffiliationNameFilter(string s);

        [OperationContract]
        Task<List<ART_AFFILIATIONs>> AffiliationDescOrder();

        [OperationContract]
        Task<string> AffiliatioFilterCount(string s);

        //[OperationContract]
        //Task<List<ART_BIND_AFFILIATION_DEVICEs>> AffiliationDevId();

    }
    
    public class SoapService : ISoapService
    {
        public SoapService() //constructor
        {
            
        }
        public string Sum(int num1, int num2)
        {
            return $"Sum of two number is: {num1 + num2}";
        }

        public string Search(string s)
        {
            return s + " ok";
        }

        public async Task<List<ART_AFFILIATIONs>> RunDBContext()
        {
            try
            {
                var dbcontext = new ApplicationDbContext();
                return await dbcontext.ART_AFFILIATION.ToListAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }

        
        public async Task<List<ART_AFFILIATIONs>> AffiliationNameFilter(string s)
        {
            try
            {
                var dbcontext = new ApplicationDbContext();
                //return dbcontext.ART_AFFILIATION where ART_AFFILIATION.SAFF_NAME contains "s" (use linq)
                var filteredAffiliations = await dbcontext.ART_AFFILIATION
                .Where(a => a.SAFF_NAME.Contains(s))
                .OrderByDescending(x => x.IAFF_ID).ToListAsync();

                //var count = filteredAffiliations.Count;
                //string rows = $"There are {count} rows";
                return filteredAffiliations;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }

        public async Task<List<ART_AFFILIATIONs>> AffiliationDescOrder()
        {
            try
            {
                var dbcontext = new ApplicationDbContext();
                //order desc by iaf_id
                return await dbcontext.ART_AFFILIATION.OrderByDescending(x => x.IAFF_ID).ToListAsync();
                
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }

        public async Task<string> AffiliatioFilterCount(string s)
        {
            try
            {
                var dbcontext = new ApplicationDbContext();
                //return dbcontext.ART_AFFILIATION where ART_AFFILIATION.SAFF_NAME contains "s" (use linq)
                var filteredAffiliations = await dbcontext.ART_AFFILIATION
                .Where(a => a.SAFF_NAME.Contains(s))
                .OrderByDescending(x => x.IAFF_ID).ToListAsync();

                var count = filteredAffiliations.Count;
                string retunrMessage = $"There are {count} rows";
                return retunrMessage;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }

        //public async Task<List<ART_BIND_AFFILIATION_DEVICEs>> AffiliationDevId()
        //{
        //    try
        //    {
        //        var dbcontext = new ApplicationDbContext();
        //        var filter = await dbcontext.ART_BIND_AFFILIATION_DEVICE.ToListAsync();
        //        return filter;


        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        //}
    }
}
