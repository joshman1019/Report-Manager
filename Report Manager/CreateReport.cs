using iText.IO.Font.Constants;
using iText.Kernel.Pdf;
using iText.Layout;
///
/// Constructs the report and returns a string indicating the path to the temporary file containing a PDF document.
/// Developer will pass variables through constructor, but minimal data and header information is all that is required.
/// Developer may read and set properties independantly if he/she wishes to change a property that is not
/// handled by a constructor (for example, a single border size, paper size, or the output file path). 
/// 
using Report_Manager.Builders;
using Report_Manager.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Report_Manager
{
    public class CreateReport
    {
        #region Properties

        /// <summary>
        /// Contains the output file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Represents the DataTable containing the body content of the report
        /// </summary>
        public DataTable ReportData { get; set; }

        /// <summary>
        /// Represents a StringBuilder containing the document header
        /// </summary>
        public StringBuilder DocumentHeader { get; set; }

        /// <summary>
        /// Represents whether or not the report creator would like to add a "report date" to the header of  the report
        /// </summary>
        public bool IncludeReportDate { get; set; }

        /// <summary>
        /// Represents whether the user would like to display an ***END OF RECORD*** indicator at the end of the report
        /// </summary>
        public bool IncludeEndOfRecordIndicator { get; set; }

        /// <summary>
        /// Represents the document size: 1=Letter Standard, 2=Letter Landscape, 3=Legal Standard, 4=Legal Landscape
        /// </summary>
        public int DocumentPageSizeCode { get; set; }

        /// <summary>
        /// Represents the Left Margin size as float = Recommended: 25f for letter size documents
        /// </summary>
        public float LeftMargin { get; set; }

        /// <summary>
        /// Represents the Right Margin size as float = Recommended: 25f for letter size documents
        /// </summary>
        public float RightMargin { get; set; }

        /// <summary>
        /// Represents the Top Margin size as float = Recommended: 35f for letter size documents
        /// </summary>
        public float TopMargin { get; set; }

        /// <summary>
        /// Represents the Bottom Margin size as float = Recommended: 25f for letter size documents
        /// </summary>
        public float BottomMargin { get; set; }

        /// <summary>
        /// List of column addresses that should be parsed as a Short Date String
        /// </summary>
        public List<int> ColumnsAsDates { get; set; } = new List<int>();
        #endregion

        #region Constructors
        // Full constructor
        public CreateReport(DataTable reportData, StringBuilder documentHeader, bool includeReportDate, bool includeEndOfRecordIndicator, 
            int documentPageSizeCode, float leftMargin, float rightMargin, float topMargin, float bottomMargin)
        {
            // Sets temporary file path which will be returned to the user as the location of the report
            FilePath = Path.GetTempFileName();

            // Sets other properties
            ReportData = reportData;
            DocumentHeader = documentHeader;
            IncludeReportDate = includeReportDate;
            IncludeEndOfRecordIndicator = includeEndOfRecordIndicator;
            DocumentPageSizeCode = documentPageSizeCode;
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
            TopMargin = topMargin;
            BottomMargin = bottomMargin;            
        }

        // All values at default
        public CreateReport(DataTable reportData, StringBuilder documentHeader)
        {
            // Sets temporary file path which will be returned to the user as the location of the report
            FilePath = Path.GetTempFileName();

            ReportData = reportData;
            DocumentHeader = documentHeader;
            IncludeReportDate = true;
            IncludeEndOfRecordIndicator = true;
            DocumentPageSizeCode = 2;
            LeftMargin = 25f;
            RightMargin = 25f;
            TopMargin = 35f;
            BottomMargin = 25f;
        }

        // Defaults with Date option
        public CreateReport(DataTable reportData, StringBuilder documentHeader, bool includeReportDate)
        {
            // Sets temporary file path which will be returned to the user as the location of the report
            FilePath = Path.GetTempFileName();

            // Sets other properties
            ReportData = reportData;
            DocumentHeader = documentHeader;
            IncludeReportDate = includeReportDate;
            IncludeEndOfRecordIndicator = true;
            DocumentPageSizeCode = 2;
            LeftMargin = 25f;
            RightMargin = 25f;
            TopMargin = 35f;
            BottomMargin = 25f;
        }

        // Defaults with Date and End of Record Indicator
        public CreateReport(DataTable reportData, StringBuilder documentHeader, bool includeReportDate, bool includeEndOfRecordIndicator)
        {
            // Sets temporary file path which will be returned to the user as the location of the report
            FilePath = Path.GetTempFileName();

            // Sets other properties
            ReportData = reportData;
            DocumentHeader = documentHeader;
            IncludeReportDate = includeReportDate;
            IncludeEndOfRecordIndicator = includeEndOfRecordIndicator;
            DocumentPageSizeCode = 2;
            LeftMargin = 25f;
            RightMargin = 25f;
            TopMargin = 35f;
            BottomMargin = 25f;
        }

        #endregion

        #region Public Methods
        // Returns document path to be passed to the PDF reader of the developer's choice
        public string GetDocumentPath()
        {
            return FilePath;
        }

        public string GetDocumentPathAsPDF()
        {
            // Creates a new report.pdf file in the temporary directory
            File.Copy(FilePath, Path.GetTempPath() + "report.pdf", true);
            // returns the new path
            return Path.GetTempPath() + "report.pdf";
        }

        public void CreateDocument()
        {
            try
            {
                // Creates a report document
                // Creates an instance of the PdfWriter
                PdfWriter writer = new PdfWriter(FilePath);
                ReportDocument Report = new ReportDocument(writer, DocumentPageSizeCode);
                // Adds the header content
                Document doc = new Document(Report);
                // Sets the document font
                doc.SetFontFamily(StandardFonts.COURIER); 
                doc.Add(new HeaderContentBuilder(DocumentHeader, IncludeReportDate).ReportHeader());
                // Adds the report body content
                doc.Add(new ReportBodyContentBuilder(ReportData, ColumnsAsDates).ReportBody());
                // Adds the report end of record indicator if requested
                if (IncludeEndOfRecordIndicator == true)
                {
                    doc.Add(new EndOfRecordIndicatorBuilder().EndOfRecordIndicator());
                }
                // Closes the report and saves changes
                Report.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error generating the report document...   " + ex.ToString());
            }
        }
        #endregion
    }
}
