using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TBILLSWebBlazorServerApp.reports
{
    public struct FontSetting
    {
        public string fontFamily { get; set; }
        public int fontSize { get; set; }
        public bool isBold { get; set; }
        public bool isItalic { get; set; }
        public bool isUnderlined { get; set; }
        public BaseColor foreColor { get; set; }
    }

    public abstract class TBillsReport
    {
        #region declaration
        int _maxColumn = 3;
        Document _document;
        public PdfPTable _pdfpTable = new PdfPTable(3);
        PdfPCell _pdfCell;
        public Font _fontStyle;
        MemoryStream _memoryStream = new MemoryStream();
        string[] _headerTitleList;
        string[] _ColsTitleList;
        Image _logo;
        PdfWriter _writer;
        private int v;
        private object p;
        private string[] colsTitleList;
        public FontSetting passFont = new FontSetting();
        #endregion


        public  TBillsReport(int maxColumn, string[] ReportheaderList, string[] ColsTitleList)
        {
            _maxColumn = maxColumn;
            _pdfpTable = new PdfPTable(_maxColumn);
            _headerTitleList = ReportheaderList;
            _ColsTitleList = ColsTitleList;
            // set up the highlight or bold font
            passFont.fontFamily = "Tahoma";
            passFont.fontSize = 12;
            passFont.isBold = true;
            passFont.isItalic = false;
            passFont.isUnderlined = false;
            passFont.foreColor = BaseColor.Black;

        }

        public byte[] Report()
        {
            ReportHeaderFooter headers = new ReportHeaderFooter();

            headers.boldFont = passFont;

            // now setup the normal text font
            passFont.fontSize = 12;
            passFont.isBold = false;

            headers.normalFont = passFont;

            headers.leftMargin = 10;
            headers.bottomMargin = 25;
            headers.rightMargin = 10;
            headers.topMargin = 25;
            headers.PageNumberSettings = ReportHeaderFooter.PageNumbers.FooterPlacement;
            headers.footerLine = "";
            headers.headerLines = _headerTitleList;
            _fontStyle = headers.fontTxtRegular;
            _document = new Document(PageSize.A4, headers.leftMargin, headers.rightMargin, headers.topMargin + headers.headerHeight, headers.bottomMargin + headers.FooterHeight);
            _writer = PdfWriter.GetInstance(_document, _memoryStream);
            _writer.PageEvent = headers;
            _document.Open();
            _document.NewPage();
            this.ReportBody(_ColsTitleList);
            //_pdfpTable.HeaderRows =_headerTitleList.Length;

            _document.Add(_pdfpTable);
            _document.Close();

            return _memoryStream.ToArray();
        }


        public virtual void ReportBody(string[] ColumnsTitles)
        {
            #region tableHeader
            _pdfpTable = new PdfPTable(ColumnsTitles.Length);
            foreach (string title in ColumnsTitles)
            {
                _pdfCell = new PdfPCell(new Phrase(title.ToUpper(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.Gray;
                _pdfpTable.AddCell(_pdfCell);
                _pdfpTable.CompleteRow();
            }
            #endregion
        }
    }

    public class ReportHeaderFooter : PdfPageEventHelper
    {
        #region Declaration

        private string[] _headerLines;
        private string _footerLine;

        private FontSetting _boldFont;
        private FontSetting _normalFont;

        public Font fontTxtBold;
        public Font fontTxtRegular;

        private int _fontPointSize = 0;

        private bool hasFooter = true;
        private bool hasHeader = true;

        private int _headerWidth = 0;
        private int _headerHeight = 0;

        private int _footerWidth = 0;
        private int _footerHeight = 0;

        private int _leftMargin = 0;
        private int _rightMargin = 0;
        private int _topMargin = 0;
        private int _bottomMargin = 0;
        private Image _logo = Image.GetInstance("~/databanklogo-1.png");
        
        private PageNumbers NumberSettings;

        private readonly DateTime runTime = DateTime.Now;

        public enum PageNumbers
        {
            None,
            HeaderPlacement,
            FooterPlacement
        }

        PdfContentByte cb;

        PdfTemplate headerTemplate;
        PdfTemplate footerTemplate;

        public string[] headerLines
        {
            get
            {
                return _headerLines;
            }
            set
            {
                _headerLines = value;
                hasHeader = true;
            }
        }

        public string footerLine
        {
            get
            {
                return _footerLine;
            }
            set
            {
                _footerLine = value;
                hasFooter = true;
            }
        }

        public FontSetting boldFont
        {
            get
            {
                return _boldFont;
            }
            set
            {
                _boldFont = value;
            }
        }

        public FontSetting normalFont
        {
            get
            {
                return _normalFont;
            }
            set
            {
                _normalFont = value;
            }
        }

        public int fontPointSize
        {
            get
            {
                return _fontPointSize;
            }
            set
            {
                _fontPointSize = value;
            }
        }

        public int leftMargin
        {
            get
            {
                return _leftMargin;
            }
            set
            {
                _leftMargin = value;
            }
        }

        public int rightMargin
        {
            get
            {
                return _rightMargin;
            }
            set
            {
                _rightMargin = value;
            }
        }

        public int topMargin
        {
            get
            {
                return _topMargin;
            }
            set
            {
                _topMargin = value;
            }
        }

        public int bottomMargin
        {
            get
            {
                return _bottomMargin;
            }
            set
            {
                _bottomMargin = value;
            }
        }

        public int headerHeight
        {
            get
            {
                return _headerHeight;
            }
        }

        public int FooterHeight
        {
            get
            {
                return _footerHeight;
            }
        }

        public PageNumbers PageNumberSettings
        {
            get
            {
                return NumberSettings;
            }

            set
            {
                NumberSettings = value;
            }
        }

        #endregion

        #region Write_Headers_Footers

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            if (hasHeader)
            {
                // left side is the string array passed in
                // right side is a built in string array (0 = date, 1 = time, 2(optional) = page)
                float[] widths = new float[2] { 90f, 10f };

                PdfPTable hdrTable = new PdfPTable(2);
                hdrTable.TotalWidth = document.PageSize.Width - (_leftMargin + _rightMargin);
                hdrTable.WidthPercentage = 95;
                hdrTable.SetWidths(widths);
                hdrTable.LockedWidth = true;

                for (int hdrIdx = 0; hdrIdx < (_headerLines.Length < 2 ? 2 : _headerLines.Length); hdrIdx++)
                {
                    string rightLine = (hdrIdx < _headerLines.Length ? _headerLines[hdrIdx] : string.Empty);

                    Paragraph rightPara = new Paragraph(5, rightLine, (hdrIdx == 0 ? fontTxtBold : fontTxtRegular));

                    switch (hdrIdx)
                    {
                        case 0:
                            {
                                _logo.Alignment = Image.ALIGN_LEFT;
                                
                                PdfPCell leftCell = new PdfPCell(_logo);
                                leftCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                leftCell.Border = 0;

                                PdfPCell rightCell = new PdfPCell(rightPara);
                                rightCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                rightCell.Border = 0;
                                rightCell.BackgroundColor = BaseColor.Gray;

                                hdrTable.AddCell(leftCell);
                                hdrTable.AddCell(rightCell);
                                break;
                            }
                    
                        default:
                            {
                                PdfPCell leftCell = new PdfPCell(rightPara);
                                leftCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                leftCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                leftCell.Border = 0;
                                leftCell.Colspan = 2;
                                hdrTable.AddCell(leftCell);
                                break;
                            }
                    }
                }

                hdrTable.WriteSelectedRows(0, -1, _leftMargin, document.PageSize.Height - _topMargin, writer.DirectContent);

                cb.MoveTo(_leftMargin, document.Top + 10);
                cb.LineTo(document.PageSize.Width - _leftMargin, document.Top + 10);
                cb.Stroke();
            }

            if (hasFooter)
            {
                PdfPTable ftrTable = new PdfPTable(1);
                float[] widths = new float[1] { 100 };

                ftrTable.TotalWidth = document.PageSize.Width - 10;
                ftrTable.WidthPercentage = 95;
                ftrTable.SetWidths(widths);

                string OneLine;

                if (NumberSettings == PageNumbers.FooterPlacement)
                {
                    OneLine = string.Concat(_footerLine, " Page " + writer.PageNumber.ToString(), " of ");
                }
                else
                {
                    OneLine = _footerLine;
                }

                Paragraph onePara = new Paragraph(0, OneLine, fontTxtRegular);
                onePara.Font.Size = _fontPointSize;

                PdfPCell oneCell = new PdfPCell(onePara);
                oneCell.HorizontalAlignment = Element.ALIGN_CENTER;
                oneCell.Border = 0;
                ftrTable.AddCell(oneCell);

                ftrTable.WriteSelectedRows(0, -1, _leftMargin, (_footerHeight), writer.DirectContent);

                //Move the pointer and draw line to separate footer section from rest of page
                cb.MoveTo(_leftMargin, document.PageSize.GetBottom(_footerHeight + 2));
                cb.LineTo(document.PageSize.Width - _leftMargin, document.PageSize.GetBottom(_footerHeight + 2));
                cb.Stroke();
            }
        }

        #endregion


        #region Setup_Headers_Footers_Happens_here

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            // create the fonts that are to be used
            // first the hightlight or Bold font
            fontTxtBold = FontFactory.GetFont(_boldFont.fontFamily, _boldFont.fontSize, _boldFont.foreColor);
            if (_boldFont.isBold)
            {
                fontTxtBold.SetStyle(Font.BOLD);
            }
            if (_boldFont.isItalic)
            {
                fontTxtBold.SetStyle(Font.ITALIC);
            }
            if (_boldFont.isUnderlined)
            {
                fontTxtBold.SetStyle(Font.UNDERLINE);
            }

            // next the normal font
            fontTxtRegular = FontFactory.GetFont(_normalFont.fontFamily, _normalFont.fontSize, _normalFont.foreColor);
            if (_normalFont.isBold)
            {
                fontTxtRegular.SetStyle(Font.BOLD);
            }
            if (_normalFont.isItalic)
            {
                fontTxtRegular.SetStyle(Font.ITALIC);
            }
            if (_normalFont.isUnderlined)
            {
                fontTxtRegular.SetStyle(Font.UNDERLINE);
            }

            // now build the header and footer templates
            try
            {
                float pageHeight = document.PageSize.Height;
                float pageWidth = document.PageSize.Width;

                _headerWidth = (int)pageWidth - ((int)_rightMargin + (int)_leftMargin);
                _footerWidth = _headerWidth;

                if (hasHeader)
                {
                    // i basically dummy build the headers so i can trial fit them and see how much space they take.
                    float[] widths = new float[1] { 90f };

                    PdfPTable hdrTable = new PdfPTable(1);
                    hdrTable.TotalWidth = document.PageSize.Width - (_leftMargin + _rightMargin);
                    hdrTable.WidthPercentage = 95;
                    hdrTable.SetWidths(widths);
                    hdrTable.LockedWidth = true;

                    _headerHeight = 0;

                    for (int hdrIdx = 0; hdrIdx < (_headerLines.Length < 2 ? 2 : _headerLines.Length); hdrIdx++)
                    {
                        Paragraph hdrPara = new Paragraph(5, hdrIdx > _headerLines.Length - 1 ? string.Empty : _headerLines[hdrIdx], (hdrIdx > 0 ? fontTxtRegular : fontTxtBold));
                        PdfPCell hdrCell = new PdfPCell(hdrPara);
                        hdrCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        hdrCell.Border = 0;
                        hdrTable.AddCell(hdrCell);
                        _headerHeight = _headerHeight + (int)hdrTable.GetRowHeight(hdrIdx);
                    }

                    // iTextSharp underestimates the size of each line so fudge it a little 
                    // this gives me 3 extra lines to play with on the spacing
                    _headerHeight = _headerHeight + (_fontPointSize * 3);

                }

                if (hasFooter)
                {
                    _footerHeight = (_fontPointSize * 2);
                }

                document.SetMargins(_leftMargin, _rightMargin, (_topMargin + _headerHeight), _footerHeight);

                cb = writer.DirectContent;

                if (hasHeader)
                {
                    headerTemplate = cb.CreateTemplate(_headerWidth, _headerHeight);
                }

                if (hasFooter)
                {
                    footerTemplate = cb.CreateTemplate(_footerWidth, _footerHeight);
                }
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        #endregion

        #region Cleanup_Doc_Processing

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            if (hasHeader)
            {
                headerTemplate.BeginText();
                headerTemplate.SetTextMatrix(0, 0);

                if (NumberSettings == PageNumbers.HeaderPlacement)
                {
                    headerTemplate.ShowText((writer.PageNumber - 1).ToString());
                }

                headerTemplate.EndText();
            }

            if (hasFooter)
            {
                footerTemplate.BeginText();
                footerTemplate.SetTextMatrix(0, 0);

                if (NumberSettings == PageNumbers.FooterPlacement)
                {
                    footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                }

                footerTemplate.EndText();
            }
        }

        #endregion

    }
}
