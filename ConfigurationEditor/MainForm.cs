using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace ConfigurationEditor
{
    public partial class MainForm : Form
    {
        string fileName = null;
        BindingList<SiteParameter> siteParameters = new BindingList<SiteParameter>();
        HttpClient client = new HttpClient();

        public MainForm()
        {
            InitializeComponent();
            languageComboBox.SelectedIndex = 0;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.fileName = openFileDialog.FileName;

            string fileContent = File.ReadAllText(this.fileName);

            siteParameters = JsonConvert.DeserializeObject<BindingList<SiteParameter>>(fileContent);

            this.siteComboBox.DisplayMember = "SiteName";
            this.siteComboBox.DataSource = siteParameters;
            this.saveToolStripMenuItem.Enabled = true;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string content = JsonConvert.SerializeObject(siteParameters);
            File.WriteAllText(this.fileName, content);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.openFileDialog.InitialDirectory = this.saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            this.siteComboBox.DisplayMember = "SiteName";
            this.siteComboBox.DataSource = siteParameters;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            SiteParameter siteParameter = new SiteParameter
            {
                SiteName = "New",
            };
            siteParameters.Add(siteParameter);
            this.siteComboBox.SelectedItem = siteParameter;
        }

        private void SiteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            this.siteNameTextBox.Text = siteParameter.SiteName;
            this.urlTextBox.Text = siteParameter.UrlPattern;
            this.startUrlTextBox.Text = siteParameter.StartUrl;
            this.itemTextBox.Text = siteParameter.ItemPattern;
            this.startNumber.Value = siteParameter.StartNumber;
            this.pageStepNumber.Value = siteParameter.PageStepNumber ?? 0;
            this.captionPosition.Value = siteParameter.CaptionPosition;
            this.urlPosition.Value = siteParameter.UrlPosition;
            this.datePosition.Value = siteParameter.DatePosition;
            this.categoryTextBox.Text = siteParameter.CategoryPattern;
            this.indexCodeTextBox.Text = siteParameter.IndexCodePattern;
            this.issueCodeTextBox.Text= siteParameter.IssueCodePattern;
            this.publishAgencyTextBox.Text = siteParameter.PublishAgencyPattern;
            this.keywordTextBox.Text = siteParameter.KeywordPattern;
            this.attachmentTextBox.Text = siteParameter.AttachmentPattern;
            this.publishDateTextBox.Text = siteParameter.PublishDatePattern;
            this.contentTextBox.Text = siteParameter.ContentPattern;
            BindSource(siteParameter);
        }

        private void SiteNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.SiteName = this.siteNameTextBox.Text;
            siteParameters.ResetItem(siteParameters.IndexOf(siteParameter));
        }

        private void StartUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.StartUrl = this.startUrlTextBox.Text;
        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.UrlPattern = this.urlTextBox.Text;
        }

        private void ItemTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.ItemPattern = this.itemTextBox.Text;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string content = JsonConvert.SerializeObject(siteParameters);
            File.WriteAllText(this.saveFileDialog.FileName, content);
        }

        private void StartNumber_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.StartNumber = (int)this.startNumber.Value;
        }

        private void PageStepNumber_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            if (this.pageStepNumber.Value == 0)
            {
                siteParameter.PageStepNumber = null;
            }
            else
            {
                siteParameter.PageStepNumber = Convert.ToInt32(this.pageStepNumber.Value);
            }
        }

        private void UrlPosition_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.UrlPosition = (int)this.urlPosition.Value;
        }

        private void CaptionPosition_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.CaptionPosition = (int)this.captionPosition.Value;
        }

        private void DatePosition_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.DatePosition = (int)this.datePosition.Value;
        }

        private void Category_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.CategoryPattern = string.IsNullOrWhiteSpace(this.categoryTextBox.Text) ? null : this.categoryTextBox.Text;
        }

        private void IndexCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.IndexCodePattern = string.IsNullOrWhiteSpace(this.indexCodeTextBox.Text) ? null : this.indexCodeTextBox.Text;
        }

        private void IssueCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.IssueCodePattern = string.IsNullOrWhiteSpace(this.issueCodeTextBox.Text) ? null : this.issueCodeTextBox.Text;
        }

        private void PublishAgency_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.PublishAgencyPattern = string.IsNullOrWhiteSpace(this.publishAgencyTextBox.Text) ? null : this.publishAgencyTextBox.Text;
        }

        private void Keyword_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.KeywordPattern = string.IsNullOrWhiteSpace(this.keywordTextBox.Text) ? null : this.keywordTextBox.Text;
        }

        private void Attachment_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.AttachmentPattern = string.IsNullOrWhiteSpace(this.attachmentTextBox.Text) ? null : this.attachmentTextBox.Text;
        }

        private void PublishDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.PublishDatePattern = string.IsNullOrWhiteSpace(this.publishDateTextBox.Text) ? null : this.publishDateTextBox.Text;
        }

        private void Content_ValueChanged(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.ContentPattern = this.contentTextBox.Text;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }
            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.StartUrl = string.Format(siteParameter.UrlPattern, siteParameter.StartNumber * (siteParameter.PageStepNumber == null ? 1 : siteParameter.PageStepNumber));
            StringBuilder log = new StringBuilder();
            log.Append("Start crawl...\r\n");
            testLogTextBox.Text = log.ToString();
            log.Append(string.Format("Current list url:{0}\r\n", siteParameter.StartUrl));
            testLogTextBox.Text = log.ToString();
            string listError = string.Empty;
            string listResult = CreateHttpWebRequest(siteParameter.StartUrl, out listError);
            if(!string.IsNullOrWhiteSpace(listError))
            {
                log.Append(string.Format("Crawl list failed,because {0}\r\n", listError));
                testLogTextBox.Text = log.ToString();
                log.Append("End crawler...\r\n");
                testLogTextBox.Text = log.ToString();
                return;
            }
            DataTable table = new DataTable();
            table.Columns.Add("URL");
            table.Columns.Add("Caption");
            table.Columns.Add("Category");
            table.Columns.Add("IndexCode");
            table.Columns.Add("IssueCode");
            table.Columns.Add("PublishAgency");
            table.Columns.Add("Keyword");
            table.Columns.Add("Publish Date");
            table.Columns.Add("Attachment");
            log.Append("Analysis list html...\r\n");
            testLogTextBox.Text = log.ToString();
            Regex regex = new Regex(siteParameter.ItemPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(listResult);
            log.Append(string.Format("Analysis list total:{0}\r\n", matches.Count));
            if (matches.Count < 1)
            {
                log.Append("End crawler...\r\n");
                testLogTextBox.Text = log.ToString();
                return;
            }
            foreach (Match match in matches)
            {
                DataRow dr = table.NewRow();
                string detailUrl = new Uri(new Uri(siteParameter.StartUrl), match.Groups[siteParameter.UrlPosition].Value).AbsoluteUri.ToString();
                log.Append(string.Format("Current detail url:{0}\r\n", detailUrl));
                testLogTextBox.Text = log.ToString();
                dr[0] = detailUrl;
                dr[1] = match.Groups[siteParameter.CaptionPosition].Value;
                if (datePosition.Value > 0)
                {
                    dr[7] = match.Groups[siteParameter.DatePosition].Value;
                }
                string detailError = string.Empty;
                string detailResult = CreateHttpWebRequest(detailUrl, out detailError);
                if (!string.IsNullOrWhiteSpace(detailError))
                {
                    log.Append(string.Format("Crawl detail failed,because {0}\r\n", detailError));
                    testLogTextBox.Text = log.ToString();
                    continue;
                }
                log.Append("Analysis detail html...\r\n");
                testLogTextBox.Text = log.ToString();
                //analysis detail html
                AnalysisDetailHtml(detailResult, siteParameter, dr);
                table.Rows.Add(dr);
                dataGridView.DataSource = table;
            }
            log.Append("End crawler...\r\n");
            testLogTextBox.Text = log.ToString();
        }

        public string CreateHttpWebRequest(string url, out string error)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null)
                {
                    error = "Get response failed,the response is null";
                    return string.Empty;
                }
                if (response.StatusCode.GetHashCode() != 200)
                {
                    error = string.Format("Get response failed,the response status is {0}", response.StatusCode.GetHashCode());
                    return string.Empty;
                }
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(languageComboBox.Text));
                    error = string.Empty;
                    return HttpUtility.HtmlDecode(sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return string.Empty;
            }
        }

        public void AnalysisDetailHtml(string detailResult, SiteParameter siteParameter, DataRow dr)
        {
            if (!string.IsNullOrWhiteSpace(siteParameter.CategoryPattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.CategoryPattern, RegexOptions.IgnoreCase))
                {
                    dr[2] = Regex.Match(detailResult, siteParameter.CategoryPattern).Groups[1].Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(siteParameter.IndexCodePattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.IndexCodePattern, RegexOptions.IgnoreCase))
                {
                    dr[3] = Regex.Match(detailResult, siteParameter.IndexCodePattern).Groups[1].Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(siteParameter.IssueCodePattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.IssueCodePattern, RegexOptions.IgnoreCase))
                {
                    dr[4] = Regex.Match(detailResult, siteParameter.IssueCodePattern).Groups[1].Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(siteParameter.PublishAgencyPattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.PublishAgencyPattern, RegexOptions.IgnoreCase))
                {
                    dr[5] = Regex.Match(detailResult, siteParameter.PublishAgencyPattern).Groups[1].Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(siteParameter.KeywordPattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.KeywordPattern, RegexOptions.IgnoreCase))
                {
                    dr[6] = Regex.Match(detailResult, siteParameter.KeywordPattern).Groups[1].Value;
                }
            }
            if (datePosition.Value < 1 && !string.IsNullOrWhiteSpace(siteParameter.PublishDatePattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.PublishDatePattern, RegexOptions.IgnoreCase))
                {
                    dr[7] = Regex.Match(detailResult, siteParameter.PublishDatePattern).Groups[1].Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(siteParameter.AttachmentPattern))
            {
                if (Regex.IsMatch(detailResult, siteParameter.AttachmentPattern, RegexOptions.IgnoreCase))
                {
                    Match match = Regex.Match(detailResult, siteParameter.AttachmentPattern);
                    StringBuilder attachment = new StringBuilder();
                    foreach (Group group in match.Groups.Cast<Group>().Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(group.Value))
                        {
                            continue;
                        }
                        attachment.Append(string.Format("Url:{0},", HttpUtility.HtmlDecode(group.Value)));
                    }
                    dr[8] = attachment.ToString().TrimEnd(',');
                }
            }
        }

        private void AddDicButton_Click(object sender, EventArgs e)
        {
            if (this.siteComboBox.SelectedValue == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(this.parseKeyTextBox.Text) || string.IsNullOrWhiteSpace(this.parseValueTextBox.Text))
            {
                this.testLogTextBox.Text = "Please input key and value";
                return;
            }

            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            if (siteParameter.CustomProcessors == null)
            {
                siteParameter.CustomProcessors = new Dictionary<string, string>();
                siteParameter.CustomProcessors.Add(this.parseKeyTextBox.Text, this.parseValueTextBox.Text);
            }
            else
            {
                if(siteParameter.CustomProcessors.Keys.Contains(this.parseKeyTextBox.Text))
                {
                    siteParameter.CustomProcessors[this.parseKeyTextBox.Text] = this.parseValueTextBox.Text;
                }
                else
                {
                    siteParameter.CustomProcessors.Add(this.parseKeyTextBox.Text, this.parseValueTextBox.Text);
                }
            }
            BindSource(siteParameter);
            this.parseKeyTextBox.Text = string.Empty;
            this.parseValueTextBox.Text = string.Empty;
        }

        private void BindSource(SiteParameter siteParameter)
        {
            if (siteParameter.CustomProcessors == null || !siteParameter.CustomProcessors.Keys.Any())
            {

                this.parseDicDataGridView.DataSource = null;
                return;
            }

            this.parseDicDataGridView.DataSource = siteParameter.CustomProcessors?.Select(s => new { Key = s.Key, Value = s.Value }).ToArray();
            this.parseDicDataGridView.Rows[0].Selected = false;
            this.parseDicDataGridView.CurrentCell = null;
            this.parseDicDataGridView.ClearSelection();
        }

        private void removeDicButton_Click(object sender, EventArgs e)
        {
            var rows = this.parseDicDataGridView.SelectedRows;
            if (rows.Count < 1)
            {
                this.testLogTextBox.Text = "Please select an item delete";
                return;
            }

            string key = rows[0].Cells[0].Value.ToString();
            SiteParameter siteParameter = siteComboBox.SelectedItem as SiteParameter;
            siteParameter.CustomProcessors.Remove(key);
            if (!siteParameter.CustomProcessors.Any())
            {
                siteParameter.CustomProcessors = null;
            }

            BindSource(siteParameter);
        }
    }
}
