﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LaboratoryLayer.Reports.Menu
{
    public partial class SampleSummaryReport : XtraReport
    {
        public SampleSummaryReport()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {            
        }

    }
}
