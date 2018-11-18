using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using DemoQLNhanVien_BTL_;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private DataProvider daP;
        private ChucNang cn;
        private DataSet ds;
       // private DataTable daT;
        [TestInitialize]
        public void SetUp()
        {
            daP = new DataProvider();
            cn = new ChucNang();
            ds = cn.GetData();
        }
        [TestMethod]
        public void TestLogin1()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "Admin";
            string pass = "GiamDoc";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLogin2()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = "sâsa";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThem()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            Assert.AreEqual(1, daTt.Rows.Count);
           
        }
        [TestMethod]
        public void TestSua()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("12", "Nguyen Van A", "acb", "0123", "Nhân Viên");

            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("12", daTs.Rows[0][0]);
        }
        [TestMethod]
        public void TestXoa()
        {
            SetUp();
            DataTable daTx = ds.Tables[0];
            cn.Them(daTx, "1232123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            cn.Them(daTx, "12343", "Nguyen Van B", "acb", "0123", "Nhân Viên");//dong muon xoa
            cn.Them(daTx, "12353", "Nguyen Van C", "acb", "0123", "Nhân Viên");

            cn.Del(1, daTx);
            Assert.AreEqual(2, daTx.Rows.Count);
            cn.Del(0, daTx);
            cn.Del(0, daTx);
        }
        [TestMethod]
        public void TestUpdate()
        {
            SetUp();
            DataTable daTa = ds.Tables[0];
            cn.Them(daTa, "12332", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            cn.Them(daTa, "123432", "Nguyen Van B", "acb", "0123", "Nhân Viên");
            cn.Them(daTa, "123532", "Nguyen Van C", "acb", "0123", "Nhân Viên");
            cn.Update(daTa);

            DataTable tbNew = ds.Tables[0];
            Assert.AreEqual(3, tbNew.Rows.Count);
            cn.Del(0, daTa);
            cn.Del(0, daTa);
            cn.Del(0, daTa);

        }


    }
}
