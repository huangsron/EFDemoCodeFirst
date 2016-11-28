using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Principal;

namespace EfDemo
{
    [TestClass]
    public class CreateDbcontextTests
    {
        private string _connectionString;

        [TestInitialize]
        public void TestInitialize()
        {
            // ref:https://www.connectionstrings.com/sql-server/
            _connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=T:\EFDemo.mdf;Initial Catalog=EFDemo;Integrated Security=True;ApplicationIntent=ReadWrite;";
        }

        [TestMethod]
        public void CreateDemoDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DemoDbContext>());

            // get connection from app.config or web.config
            //var db = new DemoDbContext("DemoConnection");

            var db = new DemoDbContext(_connectionString);
            db.Database.Initialize(true);
        }
    }
}