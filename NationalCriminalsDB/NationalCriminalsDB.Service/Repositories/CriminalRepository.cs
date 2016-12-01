using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NationalCriminalsDB.Service.Helpers;
using NationalCriminalsDB.Service.Models;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service.Repositories
{
    public interface ICriminalRepository
    {
        IEnumerable<ICriminal> Get(ISearchViewModel criteria);
    }

    public class CriminalRepository : ICriminalRepository
    {
        public IEnumerable<ICriminal> Get(ISearchViewModel criteria)
        {
            var res = new List<ICriminal>().AsEnumerable();
            using (var container = (UnityContainer)UnityConfig.GetConfiguredContainer())
            {
                using (var db = container.Resolve<ServiceDbContext>())
                {
                    res = db.Criminals.Include(c => c.CriminalHistory).AsEnumerable();
                    if (criteria != null && criteria.HasAtLeastOneFilter)
                    {
                        //Strings
                        if (!string.IsNullOrEmpty(criteria.Address))
                            res = res.Where(r => r.Address.ToLower() == criteria.Address.ToLower());
                        if (!string.IsNullOrEmpty(criteria.FirstName))
                            res = res.Where(r => r.FirstName.ToLower() == criteria.FirstName.ToLower());
                        if (!string.IsNullOrEmpty(criteria.LastName))
                            res = res.Where(r => r.LastName.ToLower() == criteria.LastName.ToLower());
                        if (!string.IsNullOrEmpty(criteria.Nationality))
                            res = res.Where(r => r.Nationality.ToLower() == criteria.Nationality.ToLower());
                        //Ranges
                        if (criteria.FromDateOfBirth.HasValue)
                            res = res.Where(r => r.DateOfBirth >= criteria.FromDateOfBirth.Value);
                        if (criteria.ToDateOfBirth.HasValue)
                            res = res.Where(r => r.DateOfBirth <= criteria.ToDateOfBirth.Value);
                        if (criteria.MinAge.HasValue)
                            res = res.Where(r => r.Age >= criteria.MinAge.Value);
                        if (criteria.MaxAge.HasValue)
                            res = res.Where(r => r.Age <= criteria.MaxAge.Value);
                        if (criteria.MinHeight.HasValue)
                            res = res.Where(r => r.Height >= criteria.MinHeight.Value);
                        if (criteria.MaxHeight.HasValue)
                            res = res.Where(r => r.Height <= criteria.MaxHeight.Value);
                        if (criteria.MinWeight.HasValue)
                            res = res.Where(r => r.Weight >= criteria.MinWeight.Value);
                        if (criteria.MaxWeight.HasValue)
                            res = res.Where(r => r.Weight <= criteria.MaxWeight.Value);
                        //Values
                        if (criteria.Sex.HasValue)
                            res = res.Where(r => r.Sex == criteria.Sex.Value);
                        if (criteria.MaxResultCount.HasValue)
                            res = res.Take(criteria.MaxResultCount.Value);
                    }
                    res = res.ToList();
                }
            }
            return res;
        }
    }
}
