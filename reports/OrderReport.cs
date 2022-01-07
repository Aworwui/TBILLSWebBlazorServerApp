using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.reports
{
    public class OrderReport: TBillsReport
    {
        IQueryable<OrderReportType> _orderList;
        public OrderReport(string[] ReportheaderList, string[] ColsTitleList, IQueryable<OrderReportType> OrderList)
           :base(1, ReportheaderList, ColsTitleList)
        {
            _orderList= OrderList;
        }

        public override void ReportBody(string[] ColumnsTitles)
        {
            this.ReportBody(ColumnsTitles);
            var secs = _orderList.Select(e => e.SecurityDescription).Distinct().ToList();
            foreach (string sec in secs)
            {
                var pdfCell = new PdfPCell(new Phrase(string.Concat("Tenure: " ,sec),_fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.Colspan = ColumnsTitles.Length;
                _pdfpTable.AddCell(pdfCell);
                _pdfpTable.CompleteRow();
                var ords = _orderList.Where(a => a.SecurityDescription == sec);
                foreach(OrderReportType o in ords)
                {
                    pdfCell = new PdfPCell(new Phrase(o.AccountNumber, _fontStyle));
                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.AccountName, _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.Price.ToString(), _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.Cost.ToString(), _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.DiscountRate.ToString(), _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.FaceValue.ToString(), _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.Instruction, _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    pdfCell = new PdfPCell(new Phrase(o.MaturityDate.ToString(), _fontStyle));
                    _pdfpTable.AddCell(pdfCell);
                    _pdfpTable.CompleteRow();
                }
            }
        }
    }
}
