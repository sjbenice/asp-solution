﻿using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BusinessLayer.Pages;

namespace LaboratoryLayer.Pages
{
	// Token: 0x02000028 RID: 40
	public class DownloadFiles : Page
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0000C4A8 File Offset: 0x0000A6A8
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (base.Request["id"] != null)
				{
					ExcelHandlingCLS excelHandlingCLS = new ExcelHandlingCLS();
					long sampleID = Convert.ToInt64(base.Request["id"]);
					MemoryStream reportListStreamBySampleID = excelHandlingCLS.GetReportListStreamBySampleID(sampleID);
					HttpContext.Current.Response.Buffer = true;
					HttpContext.Current.Response.Clear();
					HttpContext.Current.Response.ContentType = "archive/zip";
					HttpContext.Current.Response.AddHeader("Accept-Header", reportListStreamBySampleID.Length.ToString());
					HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=resultArchive.zip");
					HttpContext.Current.Response.AddHeader("Content-Length", reportListStreamBySampleID.Length.ToString());
					HttpContext.Current.Response.BinaryWrite(reportListStreamBySampleID.ToArray());
				}
				base.Response.Flush();
				base.Response.End();
			}
			catch (Exception ex)
			{
				this.LogError(ex);
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		private void LogError(Exception ex)
		{
			string text = string.Format("Time: {0}", DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt"));
			text += Environment.NewLine;
			text += "-----------------------------------------------------------";
			text += Environment.NewLine;
			text += string.Format("Message: {0}", ex.Message);
			text += Environment.NewLine;
			text += string.Format("StackTrace: {0}", ex.StackTrace);
			text += Environment.NewLine;
			text += string.Format("Source: {0}", ex.Source);
			text += Environment.NewLine;
			text += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
			text += Environment.NewLine;
			if (ex.InnerException != null)
			{
				text += string.Format("InnerException: {0}", ex.InnerException.Message);
				text += Environment.NewLine;
			}
			text += "-----------------------------------------------------------";
			text += Environment.NewLine;
			string path = base.Server.MapPath("~/ErrorLogs/ErrorLog.txt");
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				streamWriter.WriteLine(text);
				streamWriter.Close();
			}
		}

		// Token: 0x040001FB RID: 507
		protected HtmlForm form1;
	}
}
