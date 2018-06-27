using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace Financial_Calculator
{
    public partial class FORM_add_transactions : Form
    {
        private List<Transaction> _transactionList = new List<Transaction>();


        private SqlConnection sql_con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\Xsjadia\\Programs\\Financial Calculator\\Financial_Calculator\\Financial_Calculator\\Finances_DKH.mdf;Integrated Security = True; Connect Timeout = 30");

        public FORM_add_transactions()
        {
            InitializeComponent();
        }

        

        private void FORM_add_transactions_Load(object sender, EventArgs e)
        {
            uxTransactionList.View = View.Details;
            uxTransactionList.Columns.Add("Date", 100, HorizontalAlignment.Center);
            uxTransactionList.Columns.Add("Description", 650, HorizontalAlignment.Center);
            uxTransactionList.Columns.Add("Debit", 100, HorizontalAlignment.Center);
            uxTransactionList.Columns.Add("Credit", 100, HorizontalAlignment.Center);
            
        }

        private void uxButton_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF |*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                uxTextBox_transaction_file_location.Text = ofd.FileName;
            }
        }

        private void uxParseTransactions_Click(object sender, EventArgs e)
        {
            

            try
            {
                using (PdfReader reader = new PdfReader(uxTextBox_transaction_file_location.Text))
                {
                    List<string> raw_text = new List<string>();
                    
                    StreamWriter outFile = new StreamWriter("testParse.txt"); // parsed text
                    StreamWriter outFileFull = new StreamWriter("testFull.txt"); // full text
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        // Rectangle Text Box Capture Method

                        RectangleLocationTextExtractionStrategy strat = new RectangleLocationTextExtractionStrategy();
                        string pageText = PdfTextExtractor.GetTextFromPage(reader, i, strat);

                        // find start of transactions on pdf page

                        // find headers of page

                        // find "Date" header and match coordinates with "Description"
                        int parseIndexStart = 0;
                        for (int dateHeaderSearchIndex = 0; dateHeaderSearchIndex < strat.textCoordinates.Count; dateHeaderSearchIndex++)
                        {
                            if (strat.textCoordinates[dateHeaderSearchIndex].Text == "Date")
                            {
                                // Search for "Description" header that follows "Date"
                                for (int descriptSearchIndex = dateHeaderSearchIndex + 1; descriptSearchIndex < dateHeaderSearchIndex + 5; descriptSearchIndex++)
                                {
                                    // if found within 5 blocks of text from "Date" ==> must be headers
                                    if (strat.textCoordinates[descriptSearchIndex].Text == "Description")
                                    {
                                        parseIndexStart = descriptSearchIndex;
                                    }
                                }
                            }
                        }

                        // Begin decoding/stitching parsed text boxes
                        string datePattern = @"\d+/\d+/\d+";
                        Regex dateRegex = new Regex(datePattern);
                        string amtPattern = @"\$[\d\.\,^\$]+";
                        Regex amtRegex = new Regex(amtPattern);

                        int currentDateIndex;
                        int nextDateIndex;

                        // find beginning of Transaction Data
                        for (int dateSearchIndex = parseIndexStart; dateSearchIndex < strat.textCoordinates.Count; dateSearchIndex++)
                        {
                            // if text matches datePattern
                            if (dateRegex.Match(strat.textCoordinates[dateSearchIndex].Text).Success)
                            {
                                // Search for credit/debit amount
                                for (int amtSearchIndex = dateSearchIndex+1; amtSearchIndex < strat.textCoordinates.Count; amtSearchIndex++)
                                {
                                    // if index of transaction amount is found
                                    if (amtRegex.Match(strat.textCoordinates[amtSearchIndex].Text).Success)
                                    {
                                        // define description values and create Transaction object from data
                                        StringBuilder sb = new StringBuilder();
                                        for (int descIndex = dateSearchIndex+1; descIndex < amtSearchIndex; descIndex++)
                                        {
                                            sb.Append(strat.textCoordinates[descIndex].Text);
                                        }

                                        // build transaction object and add to list
                                        Transaction temp = new Transaction(strat.textCoordinates[dateSearchIndex].Text, sb.ToString().Trim(), Convert.ToDecimal(strat.textCoordinates[amtSearchIndex].Text.Substring(1)), 0, "n/a");
                                        _transactionList.Add(temp);

                                        // start next search at end of current transaction
                                        dateSearchIndex = amtSearchIndex + 1;

                                        //break amtRegex loop
                                        break;
                                   
                                    }
                                }                           
                            }
                        }

                        // Regex Match Method
                        /*

                        // USING COLLECTION OF MATCHES

                        string pageText = PdfTextExtractor.GetTextFromPage(reader, i);
                        //raw_text.Add(PdfTextExtractor.GetTextFromPage(reader, i));
                        outFileFull.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i,));

                        // string transDate = @"(\d+/\d+/\d+) ([^\$]+) \$([\d\.\,]+) \$([\d\.\,]+)";
                        string transDate = @"(\d+/\d+/\d+) ([^\$]+) \$([\d\.\,^\$]+)"; // gets date, name, and first dollar value
                        string transDateAlt = @"(\n\d+/\d+/\d+) ([^\$]+) \$([\d\.\,]+\s)";



                        // regex to parse individual transactions
                        MatchCollection transMatches = Regex.Matches(pageText, transDate);
                        int previous_index = 0;
                        int previous_length = 0;
                        string prevMatch = null;
                        foreach (Match match in transMatches)
                        {
                            if (prevMatch is null)
                            {
                                outFile.WriteLine(match);
                                prevMatch = match.Value;
                            }
                            else
                            {

                                // HERE!!!!!  Need to figure out how to capture extra text; regex strings need to be improved (see 1/4/18-1/3/18)
                                // capture text inbetween matches
                                int prevMatchEndIndex = pageText.IndexOf(prevMatch) + prevMatch.Length;
                                int currMatchIndex = pageText.IndexOf(match.Value);
                                string inbetweenMatchesText = pageText.Substring(prevMatchEndIndex, (match.Index - prevMatchEndIndex));
                                string regexNotWhiteSpace = @"\n.+\n";
                                string regexWhiteSpace = @"\n\s*\n";
                                MatchCollection nonWhiteSpace = Regex.Matches(inbetweenMatchesText, regexNotWhiteSpace);
                                MatchCollection whiteSpace = Regex.Matches(inbetweenMatchesText, regexWhiteSpace);

                                // if match found only whitespace
                                if (nonWhiteSpace.Count == whiteSpace.Count)
                                {
                                    outFile.WriteLine(match);
                                }
                                else
                                {
                                    // append to current match's label
                                    GroupCollection currMatchGrouping = match.Groups;
                                    outFile.WriteLine(currMatchGrouping[1] + nonWhiteSpace[0].Value.Trim('\n') + currMatchGrouping[2] + "$" + currMatchGrouping[3]);
                                }
                                prevMatch = match.Value;
                            }  
                        }
                        */

                    }

                    // Post transactions to uxTransactionList
                    foreach (Transaction t in _transactionList)
                    {
                        string[] tempData = { t.Description, t.Credit.ToString(), t.Debit.ToString() };
                        uxTransactionList.Items.Add(t.Date).SubItems.AddRange(tempData);
                    }

                    outFile.Close();
                }
            }
            catch (IOException ioe)
            {
                MessageBox.Show("Incompatible File, Please Try Again");
            }
        }

    }
}
