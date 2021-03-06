﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.Logger;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.Unity;
using ShopOrderExcel.Interfaces;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopOrderExcel
{
    /// <summary>
    /// Базовый класс импорта данных из Excel
    /// </summary>
    public class ExcelImport : IExcelImport, IDisposable
    {
        [Dependency]
        public Logger Log { get; set; }

        protected IList<IDataRecord> DataRecords;

        protected Excel.Application Excelapp;
        protected Excel.Workbook Workbook;
        protected Excel.Sheets Excelsheets;
        protected Excel.Worksheet Sheet;
        protected Excel.Range Cells;

        public ExcelImport()
        {
            DataRecords = new List<IDataRecord>();
        }

        /// <exception cref="FormatException">Не правильный формат файла.</exception>
        protected virtual void ReadDoc()
        {
        }

        /// <exception cref="FileNotFoundException"><c>FileNotFoundException</c>.</exception>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public IList<IDataRecord> GetDataFromExcel(string filePath)
        {
            try
            {
                Log.Info("Начало импорта");  
                if (!File.Exists(filePath))
                    throw new FileNotFoundException(string.Format("Файл не найден. [{0}]", filePath));  
                               
                Excelapp = new Application { Visible = false };
                Workbook = Excelapp.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                            Type.Missing, Type.Missing);
                ReadDoc();            
            }
            catch( Exception e)
            {
                Log.Error("Ошибка импорта", e);
                throw;
            }
            finally
            {
                Workbook.Close();
                Excelapp.Quit();
                Excelapp = null;    
            }
            return DataRecords;
        }

        public void Dispose()
        {
            Excelapp = null;
        }
    }
}