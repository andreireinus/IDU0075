using News.FormApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News.FormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class LocalResult : INotifyPropertyChanged
    {
        private DI _source;
        private AnalyzeResult _result;
        private LoadStatus _status;

        public LocalResult(DI source)
        {
            _source = source;
            _status = LoadStatus.New;
            _result = null;
        }

        public DI Source { get { return _source; } set { _source = value; NotifyPropertyChange("Source"); } }
        public AnalyzeResult Result { get { return _result; } set { _result = value; NotifyPropertyChange("Result"); } }
        public LoadStatus Status { get { return _status; } set { _status = value; NotifyPropertyChange("Status"); } }

        public string SourceTime { get { return Source.Time.ToString("dd.MM.yyyy"); } }
        public string SourceUrl { get { return Source.Url; } }
        public string ResultTicker
        {
            get
            {
                if (Result == null)
                {
                    return string.Empty;
                }
                return Result.StockTicker;
            }
        }
        public string ResultStartPrice
        {
            get
            {
                if (Result == null)
                {
                    return string.Empty;
                }
                return Result.OpenPrice.ToString("0.00");
            }
        }
        public string ResultEndPrice
        {
            get
            {
                if (Result == null)
                {
                    return string.Empty;
                }
                return Result.ClosePrice.ToString("0.00");
            }
        }
        public string ResultChange
        {
            get
            {
                if (Result == null)
                {
                    return string.Empty;
                }
                return (100 - (Result.ClosePrice * 100 / Result.OpenPrice)).ToString("0.000 %");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public enum LoadStatus
    {
        New,
        Loading,
        Complete,
        Error,
        NoResult
    }

    public class DI
    {
        public DateTime Time { get; set; }
        public string Url { get; set; }
        public DI(DateTime time, string url)
        {
            Time = time;
            Url = url;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var other = obj as DI;
            if (other == null)
            {
                return false;
            }
            return Time.Equals(other.Time) && Url.Equals(other.Url);
        }
        public override int GetHashCode()
        {
            return Time.GetHashCode() + (31 * Url.GetHashCode());
        }
    }
}
