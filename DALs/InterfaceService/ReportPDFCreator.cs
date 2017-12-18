using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Custodian.Model.ClientReportVM;
using static Custodian.Model.VisualModels;

namespace Custodian.DALs.InterfaceService
{
    class ReportPDFCreator
    {
        private static string[] _clientdetails { get; set; }
        private static ObservableCollection<AllocationTable> _clientsummary { get; set; }
        private static string DpfName { get; set; }
        private Grid Dynamic { get; set; }
        private Grid CurrentP { get; set; }
        private Grid Legend { get; set; }
        private Grid RecomendPort { get; set; }
        private static Bitmap patchtologo = Properties.Resources.Castle_logo;
        private static DataRow client = Storage.datasetKlient.Tables["ClientInfo"].Rows[0];
        private HatPrint Hat { get; set; }
        private PageContentPrint Pcp { get; set; }
        private ObservableCollection<Diagramm> ActivesClasses { get; set; }
        double Totalport { get; set; }
        public bool open { get; set; }
        static string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Futuris Cyrillic.TTF");
        static string path = Environment.CurrentDirectory + "\\";


        public ReportPDFCreator(Model.ClientReportVM objModel, string Filename, System.Windows.Controls.Grid visualObj, Grid Recomend, Grid Dun, Grid Legend, double Totalport, bool openR)
        {
            DpfName = Filename;
            Hat = new HatPrint();
            Pcp = new PageContentPrint();
            this.open = openR;
            _clientdetails = new string[]
            {
            "Order : " + objModel.Order,
            "Name : " + objModel.FIO,
            "Date of Birth : " + objModel.DateofBirth,
            "Personal Consultant Number : " + objModel.Adviser,
            "Status : " + objModel.Status,
            };

            _clientsummary = objModel.AllocationCollection;
            this.CurrentP = visualObj;
            this.RecomendPort = Recomend;
            this.Dynamic = Dun;
            this.Legend = Legend;
            this.Totalport = Totalport;

            ActivesClasses =  objModel.DiagrammValueCollection;
        }

        public  void CreateReport()
        {
            try
            {
                 ReportAsync();
            }
            catch (System.IO.IOException)
            {
                //BOX.ShowInformation("Close Your Report File");         
            }
            catch (Exception ex)
            {
                BOX.ShowInformation(ex.Message);
            }
        }


        private void ReportAsync()
        {
            CloseReport();
            Document doc = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                using (var writer = PdfWriter.GetInstance(doc, new FileStream(path + DpfName, FileMode.Create, FileAccess.ReadWrite)))
                {
                    int page = 1;
                    BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontbold = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD);

                    doc.Open();
                    PdfContentByte cb = writer.DirectContent;

                #region 1 page
                doc.NewPage();
                doc.Add(new Paragraph("", font));
                HatsPrint(doc, cb, baseFont, ttf);

                cb.BeginText();
                cb.ShowTextAligned(0, "Chart", 300, 680, 0);
                cb.EndText();
                iTextSharp.text.Image HistoryChartIMG = Pcp.ImgScreenSchots(Dynamic, 0, 0);
                HistoryChartIMG.SetAbsolutePosition(25, 560);
                HistoryChartIMG.ScaleAbsolute(560, 95);
                cb.AddImage(HistoryChartIMG);

                Hat.DetailsPrint(cb, baseFont, "Return", 25, 545, 10);

                PDFTablesCreate tablecreator = new PDFTablesCreate(ActivesClasses, Convert.ToDecimal(Totalport));

                PdfPTable table = new PdfPTable(3);
                table = Pcp.TablePrint(null, font, tablecreator.ReturnT, 90, 45, 95);
                table.WriteSelectedRows(0, -1, 25, 530, cb);


                Hat.DetailsPrint(cb, baseFont, "Allocation", 325, 545, 10);
                table = new PdfPTable(3);
                table = Pcp.TablePrint(null, font, tablecreator.AllocationT, 90, 50, 100);
                table.WriteSelectedRows(0, -1, 325, 530, cb);
                LowHatPrint(cb, baseFont, page);
                page++;

                #endregion
                #region 2 page - 3diagramm
                doc.NewPage();
                HatsPrint(doc, cb, baseFont, ttf);

                Hat.DetailsPrint(cb, baseFont, "Current Portfel Chart", Convert.ToInt32(doc.PageSize.Width / 2 - 60), 680, 10);
                iTextSharp.text.Image CurrentPotrIMG = Pcp.ImgScreenSchots(CurrentP, 21, 21);
                CurrentPotrIMG.SetAbsolutePosition(0, 300); //1 картинка
                                                            //CurrentPotrIMG.ScaleAbsolute(440, 190);
                                                            //CurrentPotrIMG.ScaleAbsolute(200,200);
                cb.AddImage(CurrentPotrIMG);
                Hat.LinePrint(cb, 20, 523, 550, 523, 255, 255, 255, 26); // закрасить сверху
                Hat.LinePrint(cb, 20, 555, -120, 255, 255, 255, 255, 219); //закрасить слева


                //Легенда
                var colorsPortfels = Ext.CurPortBrush;
                int X = 465; int Y = 670;
                object KeyDiagramm = null;
                Diagramm dd = null;
                string isin = null;

                for (int i = 0; i < colorsPortfels.Count; i++)
                {
                    System.Windows.Media.Brush diagrammitem = colorsPortfels.Values.ElementAt(i);
                    KeyDiagramm = colorsPortfels.Keys.ElementAt(i);
                    dd = (Diagramm)KeyDiagramm;
                    isin = dd.Name;
                    Pcp.RectangleTextPrint(cb, baseFont, isin, diagrammitem, X, Y);
                    Y = Y - 15;
                }
                //
                LowHatPrint(cb, baseFont, page);
                page++;
                #endregion

                #region 3p Transactions
                doc.NewPage();
                HatsPrint(doc, cb, baseFont, ttf);
                string date = DateTime.Now.ToString().Remove(11);

                Hat.DetailsPrint(cb, baseFont, "Cell Results  * " + date, Convert.ToInt32(doc.PageSize.Width / 2 - 60),
                                                                        Convert.ToInt32(doc.PageSize.Height - 150), 10);
                table = Pcp.TablePrint(null, font, tablecreator.CellPolicy, 100, 100, 100, 130);
                table.WriteSelectedRows(0, -1, 100, 680, cb);

                Hat.DetailsPrint(cb, baseFont, "Holdings * " + date, Convert.ToInt32(doc.PageSize.Width / 2 - 60), Convert.ToInt32(doc.PageSize.Height - 270), 10);
                font.Size = 8;
                table = Pcp.TablePrint(new byte[] { 255, 255, 255 }, font, tablecreator.Holdings, 53, 35, 50, 55, 50, 70, 65, 70, 60, 50);
                table.WriteSelectedRows(0, -1, 25, 560, cb);
                LowHatPrint(cb, baseFont, page);




                table = new PdfPTable(5);
                var TBL = tablecreator.Transactions;
                var Count = Math.Abs(TBL.Rows.Count / 50) + 1;
                for (int i = 0; i < Count; i++)
                {
                    doc.NewPage();
                    HatsPrint(doc, cb, baseFont, ttf);
                    Hat.DetailsPrint(cb, baseFont, "Transactions * " + date, Convert.ToInt32(doc.PageSize.Width / 2 - 60),
                                                                     Convert.ToInt32(doc.PageSize.Height - 150), 10);
                    table = Pcp.TablePrint(null, font, TBL, 103, 103, 103, 103, 103, 0, 0, 0, 0, 0, i, 50, Count - 1);
                    table.WriteSelectedRows(0, -1, 25, 680, cb);
                    page++;
                    LowHatPrint(cb, baseFont, page);
                }
                page++;

                #endregion

                #region N page - end
                doc.NewPage();


                HatsPrint(doc, cb, baseFont, ttf);



                cb.BeginText();
                cb.ShowTextAligned(0, "Important Remarks : ", 30, 680,0);

                ColumnText ct = new ColumnText(cb);
                Phrase myText = new Phrase(BigTextData.Remarks, font);
                ct.SetSimpleColumn(myText, 30, 665, 580, 317, 15, Element.ALIGN_LEFT);
                ct.Go();

 

                cb.EndText();
                LowHatPrint(cb, baseFont, page);
                #endregion
                doc.Close();
                }
                if (open == true)
                OpenReport();
       
        }

        private static void OpenReport()
        {
            System.Diagnostics.Process.Start("explorer", path + DpfName);
        }

        private static void CloseReport()
        {
            System.Diagnostics.Process[] Process = System.Diagnostics.Process.GetProcesses();
            foreach (var anti in Process)
            {
                if (anti.ProcessName.ToLower().Contains(DpfName.ToLower()))
                    anti.Kill();
            }
        }

        /// <summary>
        /// Печатает шапку, которая одинакова на каждой странице
        /// </summary>
        /// <param name="doc">Документ </param>
        /// <param name="cb">PdfContentByte</param>
        /// <param name="basefont">Шрифт</param>
        /// <param name="ttf">Путь до базового шрифта</param>
        private void HatsPrint(Document doc, PdfContentByte cb, BaseFont basefont, string ttf)
        {
            Hat.IMGPrint(doc);
            Hat.DetailsPrint(cb, basefont);
           // Hat.LinePrint(doc, 1.5f, 100.0f, BaseColor.BLACK, 0, 1);
        }
        /// <summary>
        /// Печатает нижнюю полосу которая одинакова на всех страницах КРОМЕ номера страницы
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="basefont"></param>
        /// <param name="number"></param>
        private void LowHatPrint(PdfContentByte cb, BaseFont basefont, int number)
        {
            Hat.LinePrint(cb, 20, 20, 575, 20, 0, 0, 0);
            Hat.DetailsPrint(cb, basefont, BigTextData.Markets, 90, 25, 6);
            Hat.DetailsPrint(cb, basefont, "Page : " + number.ToString(), 297, 34, 6);
        }

        private class HatPrint
        {
            public void IMGPrint(Document doc)
            {
                //System.Drawing.Image img = Properties.Resources.Castle_logo;
                System.Drawing.Image img = Properties.Resources.tituln;
                iTextSharp.text.Image fonpicture = iTextSharp.text.Image.GetInstance(img, BaseColor.WHITE);
                //fonpicture.ScalePercent(22);
                fonpicture.SetAbsolutePosition(0,0);
                fonpicture.ScaleAbsolute(600, 800);
                doc.Add(fonpicture);
            }
            public void LinePrint(Document doc, float height, float width, BaseColor color, int allign, int rotate)
            {
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(height, width, color, allign, rotate)));
                doc.Add(p);
            }
            public void LinePrint(PdfContentByte cb, int xstart, int ystart, int xend, int yend, int colorR, int colorG, int colorB)
            {
                cb.SetLineWidth(2);
                cb.SetColorStroke(new BaseColor(colorR, colorG, colorB));
                cb.MoveTo(xstart, ystart);
                cb.LineTo(xend, yend);
                cb.Stroke();
            }
            public void LinePrint(PdfContentByte cb, int xstart, int ystart, int xend, int yend, int colorR, int colorG, int colorB, int width)
            {
                cb.SetLineWidth(width);
                cb.SetColorStroke(new BaseColor(colorR, colorG, colorB));
                cb.MoveTo(xstart, ystart);
                cb.LineTo(xend, yend);
                cb.Stroke();
            }
            public void DetailsPrint(PdfContentByte cb, BaseFont basefont)
            {
                // iTextSharp.text.Font basefontBold = FontFactory.GetFont(fontpath, 10, iTextSharp.text.Font.BOLD);

                DateTime clientregister = Convert.ToDateTime(client[19]);
                string valuat = "VALUATION STATEMENT";
                string policy = "Polycy : ";
                string period = "Period : ";
                string printdate = "Print Date :" ;
                string cellholder = "Cell holder :";
                var bluefontcolor = new BaseColor(69, 103, 112);
                var blackfontcolor = BaseColor.BLACK;

                cb.BeginText();
                cb.SetColorFill(bluefontcolor);
                cb.SetFontAndSize(BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);

                cb.ShowTextAligned(0, valuat, 160, 760, 0);
                cb.SetFontAndSize(basefont, 10);
                cb.ShowTextAligned(0, policy, 160, 746, 0);

                cb.SetColorFill(blackfontcolor);
                cb.ShowTextAligned(0, client[6].ToString(), 195, 746, 0);

                cb.SetColorFill(bluefontcolor);
                cb.ShowTextAligned(0, period, 160, 736, 0);

                cb.SetColorFill(blackfontcolor);
                cb.ShowTextAligned(0, clientregister.ToString("d MMM yyyy") + " - " + DateTime.Now.ToString("d MMM yyyy"), 195, 736, 0);

                cb.SetColorFill(bluefontcolor);
                cb.ShowTextAligned(0, printdate, 160, 726, 0);

                cb.SetColorFill(blackfontcolor);
                cb.ShowTextAligned(0, DateTime.Now.ToString("d MMM yyyy"), 210, 726, 0);

                cb.SetColorFill(bluefontcolor);
                cb.ShowTextAligned(0, cellholder, 160, 716, 0);

                cb.SetColorFill(blackfontcolor);
                cb.ShowTextAligned(0, client[7].ToString() + " " + client[8].ToString(), 215, 716, 0);


                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 10);
                cb.EndText();
            }
            public void DetailsPrint(PdfContentByte cb, BaseFont basefont, string text, int x, int y, int fontsize)
            {

                cb.SetFontAndSize(basefont, fontsize);
                cb.BeginText();
                cb.ShowTextAligned(0, text, x, y, 0);
                cb.EndText();
            }
        }
        private class PageContentPrint
        {
            private int pagetotable {get; set;}
            public iTextSharp.text.Image ImgScreenSchots(Grid OScreen, int ActualWidthPluss, int ActualHeightPluss)
            {
                int Width = (int)OScreen.ActualWidth + ActualWidthPluss;
                int Heith = (int)OScreen.ActualHeight + ActualHeightPluss;
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(Width, Heith, 96, 96, PixelFormats.Default);
                renderTargetBitmap.Render(OScreen);
                PngBitmapEncoder pngImage = new PngBitmapEncoder();
                pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                Bitmap bm = new Bitmap(Width, Heith);
                var bitmapImage = new BitmapImage();
                using (var stream = new MemoryStream())
                {
                    pngImage.Save(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    bm = new Bitmap(stream);
                }
                System.Drawing.Image Img = bm;
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(Img, System.Drawing.Imaging.ImageFormat.Jpeg);

                return pic;
            }

            public PdfPTable TablePrint(byte[] RGBcolorBorderMass, iTextSharp.text.Font font, DataTable PDFTables, int Fcolumn = 0, int Mcolumn = 0, 
                int Ecolumn = 0, int Ncolumn = 0, int TColumn = 0,  int Rcolumn = 0, int Ycolumn = 0, int Acolumn = 0, int Bcolumn = 0, int CColumn = 0, 
                int CurrentPage = 0, int RowsonPage = 0, int Allpages = 0)

            {
                PdfPTable Table = new PdfPTable(PDFTables.Columns.Count);
                PdfPCell cell = new PdfPCell(new Phrase(""));

                if (RGBcolorBorderMass != null)
                {
                    cell.BorderColorBottom = new BaseColor(RGBcolorBorderMass[0], RGBcolorBorderMass[1], RGBcolorBorderMass[2]);
                    cell.BorderColorTop = new BaseColor(RGBcolorBorderMass[0], RGBcolorBorderMass[1], RGBcolorBorderMass[2]);
                }

                int Allrows = PDFTables.Rows.Count;

                int maxk = 0;
                if (CurrentPage != Allpages)
                    maxk = (RowsonPage + CurrentPage * RowsonPage) - 1;
                else
                    maxk = Allrows;


                for (int j = 0; j < PDFTables.Columns.Count; j++)
                    {
                        cell = new PdfPCell(new Phrase(new Phrase(PDFTables.Columns[j].ColumnName, font)))
                        {
                            BackgroundColor = new BaseColor(69, 103, 112),
                            HorizontalAlignment = PdfPCell.ALIGN_CENTER
                        };
                        Table.AddCell(cell);
                    }
                    for (int k = 0 + CurrentPage * RowsonPage; k < maxk;  k++)
                    {
                        for (int c = 0; c < PDFTables.Columns.Count; c++)
                        {
                            PdfPCell cellcontent = new PdfPCell(new Phrase(PDFTables.Rows[k][c].ToString(), font));
                            cellcontent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            if (RGBcolorBorderMass != null)
                            {
                                cellcontent.BorderColorBottom = BaseColor.BLACK;
                                cellcontent.BorderColorTop = BaseColor.BLACK;
                                cellcontent.BorderColorLeft = new BaseColor(RGBcolorBorderMass[0], RGBcolorBorderMass[1], RGBcolorBorderMass[2]);
                                cellcontent.BorderColorRight = new BaseColor(RGBcolorBorderMass[0], RGBcolorBorderMass[1], RGBcolorBorderMass[2]);
                                cellcontent.BorderWidthLeft = 0.3f;
                                cellcontent.BorderWidthRight = 0.3f;
                                cellcontent.BorderWidthTop = 0.3f;
                                cellcontent.BorderWidthBottom = 0.3f;
                            }
                            Table.AddCell(cellcontent);
                            Table.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        }
                    }
                

                
                float[] columnswidth = new float[] { };
                if (Ncolumn == 0)
                {
                    columnswidth = new float[3] { Fcolumn, Mcolumn, Ecolumn };
                }
                else if (Ncolumn != 0 && TColumn == 0)
                {
                    columnswidth = new float[4] { Fcolumn, Mcolumn, Ecolumn, Ncolumn };
                }
                else if (TColumn!=0 && Rcolumn == 0)
                {
                    columnswidth = new float[5] { Fcolumn, Mcolumn, Ecolumn, Ncolumn, TColumn };
                }
                else
                {
                    columnswidth = new float[10]
                    {
                        Fcolumn, Mcolumn, Ecolumn, Ncolumn, TColumn,
                        Rcolumn, Ycolumn, Acolumn, Bcolumn, CColumn
                    };

                }
                Table.SetTotalWidth(columnswidth);

                return Table;
            }
            public void RectangleTextPrint(PdfContentByte cb, BaseFont basefont, string text, 
                System.Windows.Media.Brush color, int posX, int posY, int width = 5, int height = 10)
            {
                HatPrint Hat = new HatPrint();
                byte r = 0;
                byte g = 0;
                byte b = 0;
                //var solid = (SolidColorBrush)color;  // тоже самое только новым синтаксисом =>
                //if (color is SolidColorBrush solid)
                //{
                //    r = solid.Color.R;
                //    g = solid.Color.G;
                //    b = solid.Color.B;
                //}
                var rect = new iTextSharp.text.Rectangle(posX, posY, posX + width, posY + height)
                {
                    Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER, 
                    BorderWidth = 5,
                    BorderColor = new BaseColor(r, g, b),
                };
                cb.Rectangle(rect);
                Hat.DetailsPrint(cb, basefont, text, posX + 15, posY + 2, 10);
            }

        }
        private static class BigTextData
        {
            public static string Markets =
@"Mayfair Capital Markets Limited (Ref. No. 768029) | 53 Davies Street, Mayfair, London W1K 5JH | UNITED KINGDOM | orders@castle-gaaf.sg | www.castle-gaaf.sg";
            public static string Remarks =
"1. All figures shown are for informative purpose and are indicative. \n" + 
"2. Whilst considerable care is taken in preparing this valuation, it is based on the latest unit prices / values provided by third parties and the accuracy or completeness of these cannot be guaranteed." +
"3. Please, note that this valuation does not consider any redemption penalties that may become payable on the underlying funds should they be encashed early.\r\n 4. The exchange rates used are based on daily currency rates." +
"5. Unit prices are subject to frequent changes therefore the prices shown in this valuation may no longer be indicative.\r\n 6. Please note that the value of investments may go down as well as up and investors may not get back the original amount they invested. Past performance is not a guide to future performance." +
"7. Please refer any queries regarding this valuation to your Financial Consultant.\r\n 8. Pending Transactions: due to the nature of some assets it is possible for transactions to take longer to complete. Transactions that have been executed but not finalised at the statement date are reflected under “Pending Transactions”. ";
            
        }
    }
}

#region
//private void MassiveWrite(string[] masstext, PdfContentByte _cd, int alignment, int floatx, int floaty, int rotate, int padding)
//{
//    for (int i = 0; i < masstext.Length; i++)
//    {
//        _cd.ShowTextAligned(alignment, masstext[i], floatx, floaty, rotate);
//        floaty = floaty - padding;
//    }
//    Yallign = Yallign - (16 * masstext.Length);
//}
//private void ListWrire(ObservableCollection<AllocationTable> masstextcolection, PdfContentByte _cb, int alignment, int floatx, int floaty, int rotate, int padding)
//{
//    PdfPTable summarytable = new PdfPTable(3);
//    var collect = masstextcolection.ToList();
//    summarytable.AddCell("Type");
//    summarytable.AddCell("USD Value");
//    summarytable.AddCell("Weight");

//    for (int i = 0; i < collect.Count; i++)
//    {
//        summarytable.AddCell(collect[i].Type);
//        summarytable.AddCell(collect[i].USD);
//        summarytable.AddCell(collect[i].Wieght);
//    }
//    summarytable.TotalWidth = 400;
//    summarytable.WriteSelectedRows(0, -1, floatx, floaty, _cb);
//    Yallign = Yallign - (16 * (collect.Count + 1));
//}
//private iTextSharp.text.Image ImgScreenSchots(Grid OScreen)
//{
//    int Width = (int)OScreen.ActualWidth;
//    int Heith = (int)OScreen.ActualHeight + 30;
//    RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(Width, Heith, 96, 96, PixelFormats.Default);
//    renderTargetBitmap.Render(OScreen);
//    PngBitmapEncoder pngImage = new PngBitmapEncoder();
//    pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
//    Bitmap bm = new Bitmap(Width, Heith);
//    var bitmapImage = new BitmapImage();
//    IMGHeight = Heith;
//    IMGWidth = Width;
//    using (var stream = new MemoryStream())
//    {
//        pngImage.Save(stream);
//        stream.Seek(0, SeekOrigin.Begin);
//        bitmapImage.BeginInit();
//        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
//        bitmapImage.StreamSource = stream;
//        bitmapImage.EndInit();
//        bm = new Bitmap(stream);

//    }
//    System.Drawing.Image Img = (System.Drawing.Image)bm;
//    iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(Img, System.Drawing.Imaging.ImageFormat.Jpeg);

//    return pic;
//}

#endregion