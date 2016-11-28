using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Principal;

namespace EfDemo
{
    [TestClass]
    public class EntityOperationTests
    {
        private string _connectionString;
        private DemoDbContext _db;

        [TestInitialize]
        public void TestInitialize()
        {
            // ref:https://www.connectionstrings.com/sql-server/
            _connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=T:\EFDemo.mdf;Initial Catalog=EFDemo;Integrated Security=True;ApplicationIntent=ReadWrite;";

            _db = new DemoDbContext(_connectionString);
            Database.SetInitializer(new DropCreateDatabaseAlways<DemoDbContext>());
            _db.Database.Initialize(true);

            _db.Accounts.Add(new AccountDataModel()
            {
                Account = "adminUpdate",
                Password = "password",
                Create = DateTime.UtcNow
            });

            _db.Accounts.Add(new AccountDataModel()
            {
                Account = "adminDelete",
                Password = "password",
                Create = DateTime.UtcNow
            });

            _db.SaveChanges();
        }

        [TestMethod]
        public void test_add_account()
        {
            _db.Accounts.Add(new AccountDataModel()
            {
                Account = "adminInsert",
                Password = "password",
                Create = DateTime.UtcNow
            });

            _db.SaveChanges();

            var actual = _db.Accounts.First(e => e.Account == "adminInsert");

            Assert.AreEqual("adminInsert", actual.Account);
        }

        [TestMethod]
        public void test_update_account()
        {
            var resultF = _db.Accounts.First(e => e.Account == "adminUpdate");

            resultF.Password = "adminNew";

            _db.Entry(resultF).State = EntityState.Modified;
            _db.SaveChanges();

            var actual = _db.Accounts.First(e => e.Account == "adminUpdate");

            Assert.AreEqual("adminNew", actual.Password);
        }

        [TestMethod]
        public void test_delete_account()
        {
            var resultF = _db.Accounts.First(e => e.Account == "adminDelete");
            _db.Accounts.Remove(resultF);
            _db.SaveChanges();

            var actual = _db.Accounts.Any(e => e.Account == "adminDelete");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void test_read_account()
        {
            var db = new DemoDbContext(_connectionString);
            db.Accounts.Add(new AccountDataModel()
            {
                Account = "admin",
                Password = "password",
                Create = DateTime.UtcNow
            });
            db.Accounts.Add(new AccountDataModel()
            {
                Account = "admin1",
                Password = "password",
                Create = DateTime.UtcNow
            });
            db.SaveChanges();

            // 取回單一筆資料，有多筆會有Exception
            var resultS = db.Accounts.Single(e => e.Account == "admin1");

            // 會有exception
            //var resultS = db.Accounts.Single(e => e.Account.Contains("admin"));

            // 取回一筆資料，有多筆，會取第一筆資料
            var resultF = db.Accounts.First(e => e.Account.Contains("admin"));

            // 取回多筆資料
            var resultW = db.Accounts.Where(e => e.Account.Contains("a"));
        }
    }
}