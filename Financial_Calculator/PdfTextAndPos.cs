/* PdfTextAndPos.cs
 * Author: Chris Haas
 * Modified by: David K Hwang
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace Financial_Calculator
{
    public class PdfTextAndPos
    {
        public iTextSharp.text.Rectangle Rect;
        public string Text;

        /// <summary>
        /// Constructs the PdfTextAndPos object containing both the text and rectangle location of the text in the PDF
        /// </summary>
        /// <param name="rect">Text rectangle location</param>
        /// <param name="text">Text at location</param>
        public PdfTextAndPos(iTextSharp.text.Rectangle rect, string text)
        {
            Rect = rect;
            Text = text;
        }
    }
}
