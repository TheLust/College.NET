using College.NET.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College.NET
{
    public partial class Form1 : Form
    {
        DbRepository dbRepository = new DbRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "DataSet1";
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportSample.Report1.rdlc";
            this.reportViewer1.RefreshReport();

            refresh();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            spec spec = new spec();
            spec.idspec = Convert.ToInt32(textBox1.Text);
            spec.nmspec = textBox2.Text;

            dbRepository.specs.Add(spec);
            dbRepository.SaveChanges();
            refresh();
        }

        private void refresh()
        {
            var data = dbRepository.specs.ToList();
            dataGridView1.DataSource = data;
        }
    }
}
