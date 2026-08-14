using ScintillaNET;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace ScintillaPrinting
{


    /// <summary>
    /// Type of border to print for a Page Information section
    /// </summary>
    public enum PageInformationBorder
    {
        /// <summary>
        /// No border
        /// </summary>
        None,
        /// <summary>
        /// Border along the top
        /// </summary>
        Top,
        /// <summary>
        /// Border along the bottom
        /// </summary>
        Bottom,
        /// <summary>
        /// A full border around the page information section
        /// </summary>
        Box
    }

    /// <summary>
    /// Type of data to display at one of the positions in a Page Information section
    /// </summary>
    public enum InformationType
    {
        /// <summary>
        /// Nothing is displayed at the position
        /// </summary>
        Nothing,
        /// <summary>
        /// The page number is displayed in the format "Page #"
        /// </summary>
        PageNumber,
        /// <summary>
        /// The document name is displayed
        /// </summary>
        DocumentName
    }

    /// <summary>
    /// Class for determining how and what to print for a header or footer.
    /// </summary>
    public class PageInformation
    {
        /// <summary>
        /// Default font used for Page Information sections
        /// </summary>
        public static readonly Font DefaultFont = new Font(FontFamily.GenericSansSerif, 8F);

        private const int c_iBorderSpace = 2;

        private int m_iMargin;
        private Font m_oFont;
        private PageInformationBorder m_eBorder;
        private InformationType m_eLeft;
        private InformationType m_eCenter;
        private InformationType m_eRight;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PageInformation()
            : this(PageInformationBorder.None, InformationType.Nothing, InformationType.Nothing, InformationType.Nothing)
        {
        }

        /// <summary>
        /// Normal Use Constructor
        /// </summary>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public PageInformation(PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
            : this(3, DefaultFont, eBorder, eLeft, eCenter, eRight)
        {
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="iMargin">Margin to use</param>
        /// <param name="oFont">Font to use </param>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public PageInformation(int iMargin, Font oFont, PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
        {
            m_iMargin = iMargin;
            m_oFont = oFont;
            m_eBorder = eBorder;
            m_eLeft = eLeft;
            m_eCenter = eCenter;
            m_eRight = eRight;
        }

        #region Properties

        /// <summary>
        /// Space between the Page Information section and the rest of the page
        /// </summary>
        public virtual int Margin
        {
            get { return m_iMargin; }
            set { m_iMargin = value; }
        }

        /// <summary>
        /// Font used in printing the Page Information section
        /// </summary>
        virtual public Font Font
        {
            get { return m_oFont; }
            set { m_oFont = value; }
        }


        /// <summary>
        /// Border style used for the Page Information section
        /// </summary>
        virtual public PageInformationBorder Border
        {
            get { return m_eBorder; }
            set { m_eBorder = value; }
        }

        /// <summary>
        /// Information printed on the left side of the Page Information section
        /// </summary>
        virtual public InformationType Left
        {
            get { return m_eLeft; }
            set { m_eLeft = value; }
        }

        /// <summary>
        /// Information printed in the center of the Page Information section
        /// </summary>
        virtual public InformationType Center
        {
            get { return m_eCenter; }
            set { m_eCenter = value; }
        }

        /// <summary>
        /// Information printed on the right side of the Page Information section
        /// </summary>
        virtual public InformationType Right
        {
            get { return m_eRight; }
            set { m_eRight = value; }
        }

        #endregion

        /// <summary>
        /// Whether there is a need to display this item, true if left, center, or right are not nothing.
        /// </summary>
        [Browsable(false)]
        public bool Display
        {
            get
            {
                return (m_eLeft != InformationType.Nothing) ||
                    (m_eCenter != InformationType.Nothing) ||
                    (m_eRight != InformationType.Nothing);
            }
        }

        /// <summary>
        /// Height required to draw the Page Information section based on the options selected.
        /// </summary>
        [Browsable(false)]
        public int Height
        {
            get
            {
                int iHeight = Font.Height;

                switch (m_eBorder)
                {
                    case PageInformationBorder.Top:
                    case PageInformationBorder.Bottom:
                        iHeight += c_iBorderSpace;
                        break;

                    case PageInformationBorder.Box:
                        iHeight += 2 * c_iBorderSpace;
                        break;

                    case PageInformationBorder.None:
                    default:
                        break;
                }

                return iHeight;
            }
        }

        /// <summary>
        /// Draws the page information section in the specified rectangle
        /// </summary>
        /// <param name="oGraphics"></param>
        /// <param name="oBounds"></param>
        /// <param name="strDocumentName"></param>
        /// <param name="iPageNumber"></param>
        public void Draw(Graphics oGraphics, Rectangle oBounds, String strDocumentName, int iPageNumber)
        {
            StringFormat oFormat = new StringFormat(StringFormat.GenericDefault);
            Pen oPen = Pens.Black;
            Brush oBrush = Brushes.Black;

            // Draw border
            switch (m_eBorder)
            {
                case PageInformationBorder.Top:
                    oGraphics.DrawLine(oPen, oBounds.Left, oBounds.Top, oBounds.Right, oBounds.Top);
                    break;
                case PageInformationBorder.Bottom:
                    oGraphics.DrawLine(oPen, oBounds.Left, oBounds.Bottom, oBounds.Right, oBounds.Bottom);
                    break;
                case PageInformationBorder.Box:
                    oGraphics.DrawRectangle(oPen, oBounds);
                    oBounds = new Rectangle(oBounds.Left + c_iBorderSpace, oBounds.Top, oBounds.Width - (2 * c_iBorderSpace), oBounds.Height);
                    break;
                case PageInformationBorder.None:
                default:
                    break;
            }

            // Center vertically
            oFormat.LineAlignment = StringAlignment.Center;

            // Draw left side
            oFormat.Alignment = StringAlignment.Near;
            switch (m_eLeft)
            {
                case InformationType.DocumentName:
                    oGraphics.DrawString(strDocumentName, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.PageNumber:
                    oGraphics.DrawString("Page " + iPageNumber, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.Nothing:
                default:
                    break;
            }

            // Draw center
            oFormat.Alignment = StringAlignment.Center;
            switch (m_eCenter)
            {
                case InformationType.DocumentName:
                    oGraphics.DrawString(strDocumentName, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.PageNumber:
                    oGraphics.DrawString("Page " + iPageNumber, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.Nothing:
                default:
                    break;
            }

            // Draw right side
            oFormat.Alignment = StringAlignment.Far;
            switch (m_eRight)
            {
                case InformationType.DocumentName:
                    oGraphics.DrawString(strDocumentName, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.PageNumber:
                    oGraphics.DrawString("Page " + iPageNumber, m_oFont, oBrush, oBounds, oFormat);
                    break;
                case InformationType.Nothing:
                default:
                    break;
            }
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class HeaderInformation : PageInformation
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HeaderInformation()
            : base(PageInformationBorder.None, InformationType.Nothing, InformationType.Nothing, InformationType.Nothing)
        {
        }

        /// <summary>
        /// Normal Use Constructor
        /// </summary>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public HeaderInformation(PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
            : base(3, DefaultFont, eBorder, eLeft, eCenter, eRight)
        {
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="iMargin">Margin to use</param>
        /// <param name="oFont">Font to use </param>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public HeaderInformation(int iMargin, Font oFont, PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
            : base(iMargin, oFont, eBorder, eLeft, eCenter, eRight)
        {
        }

        internal bool ShouldSerialize()
        {
            return ShouldSerializeBorder() ||
                ShouldSerializeCenter() ||
                ShouldSerializeFont() ||
                ShouldSerializeLeft() ||
                ShouldSerializeMargin() ||
                ShouldSerializeRight();
        }

        public override int Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

        private bool ShouldSerializeMargin()
        {
            return Margin != 3;
        }

        private void ResetMargin()
        {
            Margin = 3;
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        private bool ShouldSerializeFont()
        {
            return !DefaultFont.Equals(Font);
        }

        private void ResetFont()
        {
            Font = DefaultFont;
        }

        public override PageInformationBorder Border
        {
            get
            {
                return base.Border;
            }
            set
            {
                base.Border = value;
            }
        }

        private bool ShouldSerializeBorder()
        {
            return Border != PageInformationBorder.Bottom;
        }

        private void ResetBorder()
        {
            Border = PageInformationBorder.Bottom;
        }

        public override InformationType Center
        {
            get
            {
                return base.Center;
            }
            set
            {
                base.Center = value;
            }
        }

        private bool ShouldSerializeCenter()
        {
            return Center != InformationType.Nothing;
        }

        private void ResetCenter()
        {
            Center = InformationType.Nothing;
        }

        public override InformationType Left
        {
            get
            {
                return base.Left;
            }
            set
            {
                base.Left = value;
            }
        }

        private bool ShouldSerializeLeft()
        {
            return Left != InformationType.DocumentName;
        }

        private void ResetLeft()
        {
            Left = InformationType.DocumentName;
        }

        public override InformationType Right
        {
            get
            {
                return base.Right;
            }
            set
            {
                base.Right = value;
            }
        }

        private bool ShouldSerializeRight()
        {
            return Right != InformationType.PageNumber;
        }

        private void ResetRight()
        {
            Right = InformationType.PageNumber;
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FooterInformation : PageInformation
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FooterInformation()
            : base(PageInformationBorder.None, InformationType.Nothing, InformationType.Nothing, InformationType.Nothing)
        {
        }

        /// <summary>
        /// Normal Use Constructor
        /// </summary>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public FooterInformation(PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
            : base(3, DefaultFont, eBorder, eLeft, eCenter, eRight)
        {
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="iMargin">Margin to use</param>
        /// <param name="oFont">Font to use </param>
        /// <param name="eBorder">Border style</param>
        /// <param name="eLeft">What to print on the left side of the page</param>
        /// <param name="eCenter">What to print in the center of the page</param>
        /// <param name="eRight">What to print on the right side of the page</param>
        public FooterInformation(int iMargin, Font oFont, PageInformationBorder eBorder, InformationType eLeft, InformationType eCenter, InformationType eRight)
            : base(iMargin, oFont, eBorder, eLeft, eCenter, eRight)
        {
        }

        internal bool ShouldSerialize()
        {
            return ShouldSerializeBorder() ||
                ShouldSerializeCenter() ||
                ShouldSerializeFont() ||
                ShouldSerializeLeft() ||
                ShouldSerializeMargin() ||
                ShouldSerializeRight();
        }


        public override int Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

        private bool ShouldSerializeMargin()
        {
            return Margin != 3;
        }

        private void ResetMargin()
        {
            Margin = 3;
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        private bool ShouldSerializeFont()
        {
            return !DefaultFont.Equals(Font);
        }

        private void ResetFont()
        {
            Font = DefaultFont;
        }

        public override PageInformationBorder Border
        {
            get
            {
                return base.Border;
            }
            set
            {
                base.Border = value;
            }
        }

        private bool ShouldSerializeBorder()
        {
            return Border != PageInformationBorder.Top;
        }

        private void ResetBorder()
        {
            Border = PageInformationBorder.Top;
        }

        public override InformationType Center
        {
            get
            {
                return base.Center;
            }
            set
            {
                base.Center = value;
            }
        }

        private bool ShouldSerializeCenter()
        {
            return Center != InformationType.Nothing;
        }

        private void ResetCenter()
        {
            Center = InformationType.Nothing;
        }

        public override InformationType Left
        {
            get
            {
                return base.Left;
            }
            set
            {
                base.Left = value;
            }
        }

        private bool ShouldSerializeLeft()
        {
            return Left != InformationType.Nothing;
        }

        private void ResetLeft()
        {
            Left = InformationType.Nothing;
        }

        public override InformationType Right
        {
            get
            {
                return base.Right;
            }
            set
            {
                base.Right = value;
            }
        }

        private bool ShouldSerializeRight()
        {
            return Right != InformationType.Nothing;
        }

        private void ResetRight()
        {
            Right = InformationType.Nothing;
        }
    }







    /// <summary>
    /// ScintillaNET derived class for handling printed page settings.  It holds information 
    /// on how and what to print in the header and footer of pages.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PageSettings : System.Drawing.Printing.PageSettings
    {
        public enum PrintColorMode
        {
            /// <summary>
            /// Normal
            /// </summary>
            Normal = 0,
            /// <summary>
            /// Inverts the colors
            /// </summary>
            InvertLight = 1,
            /// <summary>
            /// Black Text on white background
            /// </summary>
            BlackOnWhite = 2,

            /// <summary>
            /// Styled color text on white background
            /// </summary>
            ColorOnWhite = 3,

            /// <summary>
            /// Styled color text on white background for unstyled background colors
            /// </summary>
            ColorOnWhiteDefaultBackground = 4,
        }

        /// <summary>
        /// Default header style used when no header is provided.
        /// </summary>
        public static readonly PageInformation DefaultHeader = new PageInformation(PageInformationBorder.Bottom, InformationType.DocumentName, InformationType.Nothing, InformationType.PageNumber);
        /// <summary>
        /// Default footer style used when no footer is provided.
        /// </summary>
        public static readonly PageInformation DefaultFooter = new PageInformation(PageInformationBorder.Top, InformationType.Nothing, InformationType.Nothing, InformationType.Nothing);

        private HeaderInformation m_oHeader;
        private FooterInformation m_oFooter;
        private short m_sFontMagnification;
        private PrintColorMode m_eColorMode;
        private bool baseColor;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageSettings()
        {
            // Keep track of the base color for designer serialization. This is a workaround that should
            // last until the PageSettings can be redesigned.
            baseColor = base.Color;


            m_oHeader = new HeaderInformation(PageInformationBorder.Bottom, InformationType.DocumentName, InformationType.Nothing, InformationType.PageNumber);
            m_oFooter = new FooterInformation(PageInformationBorder.Top, InformationType.Nothing, InformationType.Nothing, InformationType.Nothing);
            m_sFontMagnification = 0;
            m_eColorMode = PrintColorMode.Normal;

            // Set default margins to 1/2 inch (50/100ths)
            base.Margins.Top = 50;
            base.Margins.Left = 50;
            base.Margins.Right = 50;
            base.Margins.Bottom = 50;
        }

        internal bool ShouldSerialize()
        {
            return ShouldSerializeColor() ||
                ShouldSerializeColorMode() ||
                ShouldSerializeFontMagnification() ||
                ShouldSerializeFooter() ||
                ShouldSerializeHeader() ||
                ShouldSerializeLandscape() ||
                ShouldSerializeMargins();
        }

        #region Properties

        /// <summary>
        /// Page Information printed in header of the page
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public HeaderInformation Header
        {
            get { return m_oHeader; }
            set { m_oHeader = value; }
        }

        private bool ShouldSerializeHeader()
        {
            return m_oHeader.ShouldSerialize();
        }

        /// <summary>
        /// Page Information printed in the footer of the page
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FooterInformation Footer
        {
            get { return m_oFooter; }
            set { m_oFooter = value; }
        }

        private bool ShouldSerializeFooter()
        {
            return m_oFooter.ShouldSerialize();
        }

        /// <summary>
        /// Number of points to add or subtract to the size of each screen font during printing
        /// </summary>
        public short FontMagnification
        {
            get { return m_sFontMagnification; }
            set { m_sFontMagnification = value; }
        }

        private bool ShouldSerializeFontMagnification()
        {
            return m_sFontMagnification != 0;
        }

        private void ResetFontMagnification()
        {
            m_sFontMagnification = 0;
        }

        /// <summary>
        /// Method used to render colored text on a printer
        /// </summary>
        public PrintColorMode ColorMode
        {
            get { return m_eColorMode; }
            set { m_eColorMode = value; }
        }

        private bool ShouldSerializeColorMode()
        {
            return m_eColorMode != PrintColorMode.Normal;
        }

        private void ResetColorMode()
        {
            m_eColorMode = PrintColorMode.Normal;
        }

        #endregion


        //	All these properties below merely call into their base class.
        //	So why have new versions of these? The PageSettings class
        //	isn't designer friendly.

        [Browsable(false)]
        public new Rectangle Bounds
        {
            get
            {
                return base.Bounds;
            }
        }

        public new bool Color
        {
            get
            {
                return base.Color;
            }
            set
            {
                base.Color = value;
            }
        }

        private bool ShouldSerializeColor()
        {
            return Color != baseColor;
        }

        private void ResetColor()
        {
            Color = baseColor;
        }

        [Browsable(false)]
        public new float HardMarginX
        {
            get
            {
                return base.HardMarginX;
            }
        }

        [Browsable(false)]
        public new float HardMarginY
        {
            get
            {
                return base.HardMarginY;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new PaperSize PaperSize
        {
            get
            {
                return base.PaperSize as PaperSize;
            }
            set
            {
                base.PaperSize = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new PaperSource PaperSource
        {
            get
            {
                return base.PaperSource;
            }
            set
            {
                base.PaperSource = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RectangleF PrintableArea
        {
            get
            {
                return base.PrintableArea;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new PrinterResolution PrinterResolution
        {
            get
            {
                return base.PrinterResolution;
            }
            set
            {
                base.PrinterResolution = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new PrinterSettings PrinterSettings
        {
            get
            {
                return base.PrinterSettings;
            }
            set
            {
                base.PrinterSettings = value;
            }
        }


        public new bool Landscape
        {
            get
            {
                return base.Landscape;
            }
            set
            {
                base.Landscape = value;
            }
        }

        private bool ShouldSerializeLandscape()
        {
            return Landscape;
        }

        private void ResetLandscape()
        {
            Landscape = false;
        }

        public new Margins Margins
        {
            get
            {
                return base.Margins;
            }
            set
            {
                base.Margins = value;
            }
        }

        private bool ShouldSerializeMargins()
        {
            return Margins.Bottom != 50 || Margins.Left != 50 || Margins.Right != 50 || Margins.Bottom != 50;
        }

        private void ResetMargins()
        {
            Margins = new Margins(50, 50, 50, 50);
        }



    }





    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Printing
    {
        public Scintilla scintilla { get; set; }
        internal Printing(Scintilla scintilla)
        {
            _printDocument = new PrintDocument(scintilla);
        }

        internal bool ShouldSerialize()
        {
            return ShouldSerializePageSettings() || ShouldSerializePrintDocument();
        }

        public bool Print()
        {
            return Print(true);
        }

        public bool Print(bool showPrintDialog)
        {
            try
            {
                if (showPrintDialog)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.Document = _printDocument;
                    pd.UseEXDialog = true;
                    pd.AllowCurrentPage = true;
                    pd.AllowSelection = true;
                    pd.AllowSomePages = true;
                    pd.PrinterSettings = PageSettings.PrinterSettings;

                    if (pd.ShowDialog(scintilla) == DialogResult.OK)
                    {
                        _printDocument.PrinterSettings = pd.PrinterSettings;
                        _printDocument.Print();
                        return true;
                    }

                    return false;
                }

                _printDocument.Print();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public DialogResult PrintPreview()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.WindowState = FormWindowState.Maximized;

            ppd.Document = _printDocument;
            return ppd.ShowDialog();
        }

        public DialogResult PrintPreview(IWin32Window owner)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.WindowState = FormWindowState.Maximized;

            if (owner is Form)
                ppd.Icon = ((Form)owner).Icon;

            ppd.Document = _printDocument;
            return ppd.ShowDialog(owner);
        }

        public DialogResult ShowPageSetupDialog()
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.PageSettings = PageSettings;
            psd.PrinterSettings = PageSettings.PrinterSettings;
            return psd.ShowDialog();
        }

        public DialogResult ShowPageSetupDialog(IWin32Window owner)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.AllowPrinter = true;
            psd.PageSettings = PageSettings;
            psd.PrinterSettings = PageSettings.PrinterSettings;

            return psd.ShowDialog(owner);
        }

        private PrintDocument _printDocument;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PrintDocument PrintDocument
        {
            get
            {
                return _printDocument;
            }
            set
            {
                _printDocument = value;
            }
        }

        private bool ShouldSerializePrintDocument()
        {
            return _printDocument.ShouldSerialize();
        }


        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PageSettings PageSettings
        {
            get
            {
                return _printDocument.DefaultPageSettings as PageSettings;
            }
            set
            {
                _printDocument.DefaultPageSettings = value;
            }
        }

        private bool ShouldSerializePageSettings()
        {
            return PageSettings.ShouldSerialize();
        }
    }







    /// <summary>
    /// ScintillaNET derived class for handling printing of source code from a Scintilla control.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PrintDocument : System.Drawing.Printing.PrintDocument
    {
        private Scintilla m_oScintillaControl;

        private int m_iPosition;
        private int m_iPrintEnd;
        private int m_iCurrentPage;
        private const int SCI_SETPRINTMAGNIFICATION = 2146;
        private const int SCI_SETPRINTCOLOURMODE = 2148;

        //sacado de NativeStruct de version 4.0
        private struct PrintRectangle
        {
            /// <summary>
            /// Left X Bounds Coordinate
            /// </summary>
            public int Left;
            /// <summary>
            /// Top Y Bounds Coordinate
            /// </summary>
            public int Top;
            /// <summary>
            /// Right X Bounds Coordinate
            /// </summary>
            public int Right;
            /// <summary>
            /// Bottom Y Bounds Coordinate
            /// </summary>
            public int Bottom;

            public PrintRectangle(int iLeft, int iTop, int iRight, int iBottom)
            {
                Left = iLeft;
                Top = iTop;
                Right = iRight;
                Bottom = iBottom;
            }
        }
        private struct RangeToFormat
        {
            /// <summary>
            /// The HDC (device context) we print to
            /// </summary>
            public IntPtr hdc;
            /// <summary>
            /// The HDC we use for measuring (may be same as hdc)
            /// </summary>
            public IntPtr hdcTarget;
            /// <summary>
            /// Rectangle in which to print
            /// </summary>
            public PrintRectangle rc;
            /// <summary>
            /// Physically printable page size
            /// </summary>
            public PrintRectangle rcPage;
            /// <summary>
            /// Range of characters to print
            /// </summary>
            public CharacterRange chrg;
        }
        private struct CharacterRange
        {
            public int cpMin;
            public int cpMax;
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="oScintillaControl">Scintilla control being printed</param>
        public PrintDocument(Scintilla oScintillaControl)
        {
            m_oScintillaControl = oScintillaControl;
            DefaultPageSettings = new PageSettings();
        }


        internal bool ShouldSerialize()
        {
            return base.DocumentName != "document" || OriginAtMargins;
        }

        /// <summary>
        /// Method called after the Print method is called and before the first page of the document prints
        /// </summary>
        /// <param name="e">A PrintPageEventArgs that contains the event data</param>
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

            m_iPosition = 0;
            m_iPrintEnd = m_oScintillaControl.TextLength;
            m_iCurrentPage = 1;
        }

        /// <summary>
        /// Method called when the last page of the document has printed
        /// </summary>
        /// <param name="e">A PrintPageEventArgs that contains the event data</param>
        protected override void OnEndPrint(PrintEventArgs e)
        {
            base.OnEndPrint(e);
        }


        /// <summary>
        /// Method called when printing a page
        /// </summary>
        /// <param name="e">A PrintPageEventArgs that contains the event data</param>
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            PageSettings oPageSettings = null;
            HeaderInformation oHeader = ((PageSettings)DefaultPageSettings).Header;
            FooterInformation oFooter = ((PageSettings)DefaultPageSettings).Footer;
            Rectangle oPrintBounds = e.MarginBounds;
            bool bIsPreview = this.PrintController.IsPreview;

            // When not in preview mode, adjust graphics to account for hard margin of the printer
            if (!bIsPreview)
            {
                e.Graphics.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY);
            }

            // Get the header and footer provided if using Scintilla.Printing.PageSettings
            if (e.PageSettings is PageSettings)
            {
                oPageSettings = (PageSettings)e.PageSettings;

                oHeader = oPageSettings.Header;
                oFooter = oPageSettings.Footer;

                SetPrintMagnification(oPageSettings.FontMagnification);
                SetPrintColourMode((int)oPageSettings.ColorMode);
            }

            // Draw the header and footer and get remainder of page bounds
            oPrintBounds = DrawHeader(e.Graphics, oPrintBounds, oHeader);
            oPrintBounds = DrawFooter(e.Graphics, oPrintBounds, oFooter);

            // When not in preview mode, adjust page bounds to account for hard margin of the printer
            if (!bIsPreview)
            {
                oPrintBounds.Offset((int)-e.PageSettings.HardMarginX, (int)-e.PageSettings.HardMarginY);
            }
            DrawCurrentPage(e.Graphics, oPrintBounds);

            // Increment the page count and determine if there are more pages to be printed
            m_iCurrentPage++;
            e.HasMorePages = m_iPosition < m_iPrintEnd;


        }

        private void SetPrintMagnification(int magnification)
        {
            m_oScintillaControl.DirectMessage(SCI_SETPRINTMAGNIFICATION, new IntPtr(magnification), IntPtr.Zero);
        }

        private void SetPrintColourMode(int mode)
        {
            m_oScintillaControl.DirectMessage(SCI_SETPRINTCOLOURMODE, new IntPtr(mode), IntPtr.Zero);
        }

        private Rectangle DrawHeader(Graphics oGraphics, Rectangle oBounds, PageInformation oHeader)
        {
            if (oHeader.Display)
            {
                Rectangle oHeaderBounds = new Rectangle(oBounds.Left, oBounds.Top, oBounds.Width, oHeader.Height);

                oHeader.Draw(oGraphics, oHeaderBounds, this.DocumentName, m_iCurrentPage);

                return new Rectangle(
                    oBounds.Left, oBounds.Top + oHeaderBounds.Height + oHeader.Margin,
                    oBounds.Width, oBounds.Height - oHeaderBounds.Height - oHeader.Margin
                    );
            }
            else
            {
                return oBounds;
            }
        }

        private Rectangle DrawFooter(Graphics oGraphics, Rectangle oBounds, PageInformation oFooter)
        {
            if (oFooter.Display)
            {
                int iHeight = oFooter.Height;
                Rectangle oFooterBounds = new Rectangle(oBounds.Left, oBounds.Bottom - iHeight, oBounds.Width, iHeight);

                oFooter.Draw(oGraphics, oFooterBounds, this.DocumentName, m_iCurrentPage);

                return new Rectangle(
                    oBounds.Left, oBounds.Top,
                    oBounds.Width, oBounds.Height - oFooterBounds.Height - oFooter.Margin
                    );
            }
            else
            {
                return oBounds;
            }
        }

        private void DrawCurrentPage(Graphics oGraphics, Rectangle oBounds)
        {
            Point[] oPoints = {
                new Point(oBounds.Left, oBounds.Top),
                new Point(oBounds.Right, oBounds.Bottom)
                };
            oGraphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, oPoints);

            PrintRectangle oPrintRectangle = new PrintRectangle(oPoints[0].X, oPoints[0].Y, oPoints[1].X, oPoints[1].Y);

            RangeToFormat oRangeToFormat = new RangeToFormat();
            oRangeToFormat.hdc = oRangeToFormat.hdcTarget = oGraphics.GetHdc();
            oRangeToFormat.rc = oRangeToFormat.rcPage = oPrintRectangle;
            oRangeToFormat.chrg.cpMin = m_iPosition;
            oRangeToFormat.chrg.cpMax = m_iPrintEnd;

            m_iPosition = FormatRange(true, ref oRangeToFormat);

        }
        private int FormatRange(bool bDraw, ref RangeToFormat pfr)
        {
            GCHandle handle = GCHandle.Alloc(pfr, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                const int SCI_FORMATRANGE = 2151;

                return m_oScintillaControl.DirectMessage(SCI_FORMATRANGE, new IntPtr(bDraw ? 1 : 0), pointer).ToInt32(); ;
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
        }
        public new string DocumentName
        {
            get
            {
                return base.DocumentName;
            }
            set
            {
                base.DocumentName = value;
            }
        }

        private bool ShouldSerializeDocumentName()
        {
            return DocumentName != "document";
        }

        private void ResetDocumentName()
        {
            DocumentName = "document";
        }

        public new bool OriginAtMargins
        {
            get
            {
                return base.OriginAtMargins;
            }
            set
            {
                base.OriginAtMargins = value;
            }
        }

        private bool ShouldSerializeOriginAtMargins()
        {
            return OriginAtMargins;
        }

        private void ResetOriginAtMargins()
        {
            OriginAtMargins = false;
        }

    }

}
