using News.FormApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News.FormApp
{
    public partial class MainForm : Form
    {
        NewsService service = new NewsService();
        private BindingList<LocalResult> bindingSource = new BindingList<LocalResult>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadUrl(DI input)
        {
            LocalResult item = bindingSource.Where(i => i.Source == input && i.Status == LoadStatus.New).FirstOrDefault();
            item.Status = LoadStatus.Loading;
            Invoke(new MethodInvoker(() => { dataGridView1.Refresh(); }));

            try
            {
                var result = service.Analyze(input.Url, input.Time);
                AnalyzeResult(item, result);
            }
            catch (Exception)
            {
                item.Status = LoadStatus.Error;
            }
        }

        private void AnalyzeResult(LocalResult item, AnalyzeResult[] result)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => { AnalyzeResult(item, result); }));
                return;
            }

            if (result == null || result.Length == 0)
            {
                item.Status = LoadStatus.NoResult;
                return;
            }
            else if (result.Length == 1)
            {
                item.Status = LoadStatus.Complete;
                item.Result = result[0];
            }
            else
            {
                item.Status = LoadStatus.Complete;
                item.Result = result[0];
                for (var i = 1; i < result.Length; i++)
                {
                    var lr = new LocalResult(item.Source);
                    lr.Status = LoadStatus.Complete;
                    lr.Result = result[i];

                    bindingSource.Add(lr);
                }
            }

            dataGridView1.Refresh();
        }

        private List<DI> _input = new List<DI>()
        {
            new DI(new DateTime(2013, 01, 23), "http://9to5mac.com/2013/01/23/outspoken-jim-cramer-on-aapl-stock/"),
            new DI(new DateTime(2013, 01, 20), "http://appleinsider.com/articles/13/01/20/rumor-apple-to-debut-48-iphone-math-device-alongside-next-gen-iphone-in-june"),
            new DI(new DateTime(2013, 11, 15), "http://www.marketwatch.com/story/breakfast-news-apple-inc-microsoft-corporation-intel-corporation-solarcity-corp-2013-11-15"),
            new DI(new DateTime(2013, 11, 15), "http://basicsmedia.com/the-google-inc-nasdaqgoog-that-the-market-knows-little-about-7404"),
            new DI(new DateTime(2013, 07, 09), "http://www.forbes.com/sites/avaseave/2013/07/09/emarketer-significant-growth-through-penetration-within-companies-as-digital-becomes-core-competency-in-all-functions/"),
            new DI(new DateTime(2013, 03, 04), "http://www.bloomberg.com/news/2013-03-04/u-s-stock-futures-decline-on-china-data-spending-cuts.html?cmpid=yhoo"),
            new DI(new DateTime(2013, 05, 07), "http://finance.yahoo.com/news/microsoft-xbox-pay-monthly-fee-183103636.html"),
        };


        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var i in _input)
            {
                bindingSource.Add(new LocalResult(i));

            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            foreach (var a in dataGridView1.Rows)
            {
                var row = a as DataGridViewRow;
                row.Selected = false;
            }

            new Task(() =>
            {
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 2
                };
                Parallel.ForEach(_input, options, i =>
                {
                    LoadUrl(i);
                });
            }).Start();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var value = bindingSource[e.RowIndex];
                var backColor = e.CellStyle.BackColor;

                if (value.Status == LoadStatus.New) { backColor = Color.White; }
                else if (value.Status == LoadStatus.Loading) { backColor = Color.LightYellow; }
                else if (value.Status == LoadStatus.Complete) { backColor = Color.LightGreen; }
                else if (value.Status == LoadStatus.Error) { backColor = Color.LightPink; }
                else if (value.Status == LoadStatus.NoResult) { backColor = Color.DarkRed; }

                e.CellStyle.BackColor = backColor;
            }
            catch (Exception ex)
            {

            }
        }
    }




}
