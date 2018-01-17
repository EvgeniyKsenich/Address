using PS.Business.Enteties;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.DB.Repositories
{
    public class ItemsRepositories : IItems<Item>
    {
        public IEnumerable<Item> GetList()
        {
            List<Item> List;
            using (AddressEntities db = new AddressEntities())
            {
                var items = db.Items.ToList<Items>();
                List = Mapper.Map<List<Item>>(items);
            }
            return List;
        }

        public void Save(Item item)
        {
            if (item != null)
            {
                using (AddressEntities db = new AddressEntities())
                {
                    db.Items.Add(Mapper.Map<Items>(item));
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public int SaveAll(List<Item> List)
        {
            int result = 0;
            if (List != null)
            {
                using (AddressEntities db = new AddressEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in List)
                            {
                                db.Items.Add(Mapper.Map<Items>(item));
                            }

                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            result = 1;
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            result = -1;
                        }
                    }
                }
            }
            return result;
        }
    }
}