using System;
using BitMobile.DbEngine;

namespace Test.Catalog
{
    public class ListOfPayments : DbEntity
    {
        public DbRef Id { get; set; }
        public string Description { get; set; }
        public int FrNumber { get; set; }
}


}
    