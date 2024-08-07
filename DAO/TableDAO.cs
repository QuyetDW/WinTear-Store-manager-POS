﻿using DoAnChuyenNghanh1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnChuyenNghanh1.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            set { instance = value; }
        }

        public static int TableWidth = 80;
        public static int TableHeight = 70;
        private TableDAO()
        {

        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[]{id1, id2});
        }

        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows) 
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }


            return tablelist;

        }
    }
}
