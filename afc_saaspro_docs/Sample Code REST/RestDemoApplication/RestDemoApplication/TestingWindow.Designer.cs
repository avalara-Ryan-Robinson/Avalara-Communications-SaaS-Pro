/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    TestingWindow Application Components


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
namespace Avalara.RestDemoApplication
{
   partial class TestingWindow
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingWindow));
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            this.TransactionGB = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PCodeTB = new System.Windows.Forms.TextBox();
            this.InvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.CustNoTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ViewReqJsonPB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CompanyIdentifierTB = new System.Windows.Forms.TextBox();
            this.ChargeTB = new System.Windows.Forms.TextBox();
            this.PostSamplePB = new System.Windows.Forms.Button();
            this.ChargeLB = new System.Windows.Forms.Label();
            this.ServiceTB = new System.Windows.Forms.TextBox();
            this.ServiceLB = new System.Windows.Forms.Label();
            this.TransactionTB = new System.Windows.Forms.TextBox();
            this.TransactionLB = new System.Windows.Forms.Label();
            this.CalcTaxInclusiveAdjustmentRB = new System.Windows.Forms.RadioButton();
            this.CalcAdjustmentRB = new System.Windows.Forms.RadioButton();
            this.CalcTaxInclusiveRB = new System.Windows.Forms.RadioButton();
            this.CalcStandardRB = new System.Windows.Forms.RadioButton();
            this.BenchmarkSettingsGB = new System.Windows.Forms.GroupBox();
            this.BatchRB = new System.Windows.Forms.RadioButton();
            this.ZipLookupRB = new System.Windows.Forms.RadioButton();
            this.DemoTabControl = new System.Windows.Forms.TabControl();
            this.DemoInputTab = new System.Windows.Forms.TabPage();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.GoButton = new Telerik.WinControls.UI.RadButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ThreadTrackBar = new Telerik.WinControls.UI.RadTrackBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.AvailableCPUsLB = new Telerik.WinControls.UI.RadLabel();
            this.AvailableCPUsTB = new Telerik.WinControls.UI.RadLabel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.VerifyCredentialsErrorMsg = new Telerik.WinControls.UI.RadLabel();
            this.RestVersionLB = new Telerik.WinControls.UI.RadLabel();
            this.VerifyCredentialCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.UrlLabel = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.UsernameTB = new Telerik.WinControls.UI.RadTextBox();
            this.PasswordTB = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.ImportedCountLB = new Telerik.WinControls.UI.RadLabel();
            this.TimedMinsTB = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.TestCountTB = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.InputFileBrowser = new Telerik.WinControls.UI.RadBrowseEditor();
            this.InputTestTypeRB = new Telerik.WinControls.UI.RadRadioButton();
            this.CountTestTypeRB = new Telerik.WinControls.UI.RadRadioButton();
            this.TimedTestTypeRB = new Telerik.WinControls.UI.RadRadioButton();
            this.DemoMetricsTab = new System.Windows.Forms.TabPage();
            this.DemoChartView = new Telerik.WinControls.UI.RadChartView();
            this.DisabledLB = new Telerik.WinControls.UI.RadLabel();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.AbortButton = new Telerik.WinControls.UI.RadButton();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.StatusBGLabel = new Telerik.WinControls.UI.RadLabel();
            this.StatusLabel = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.ThroughputTB = new Telerik.WinControls.UI.RadLabel();
            this.DemoClock = new Telerik.WinControls.UI.RadClock();
            this.TestEndTimeLB = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.ThroughputLB = new Telerik.WinControls.UI.RadLabel();
            this.ApiCalls = new Telerik.WinControls.UI.RadLabel();
            this.TestStartTimeLB = new Telerik.WinControls.UI.RadLabel();
            this.AvgApiThreadTimeLB = new Telerik.WinControls.UI.RadLabel();
            this.ElapsedTimeLB = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.BenchmarkProgressBar = new Telerik.WinControls.UI.RadProgressBar();
            this.AdvancedSettingsTab = new System.Windows.Forms.TabPage();
            this.ConstrucitonZoneImage = new System.Windows.Forms.PictureBox();
            this.ThreadBarRange = new Telerik.WinControls.UI.TrackBarRange();
            this.threadBarRange1 = new Telerik.WinControls.UI.TrackBarRange();
            this.ellipseShape1 = new Telerik.WinControls.EllipseShape();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ClientIdTB = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.ClientProfileIdTB = new Telerik.WinControls.UI.RadTextBox();
            this.TransactionGB.SuspendLayout();
            this.BenchmarkSettingsGB.SuspendLayout();
            this.DemoTabControl.SuspendLayout();
            this.DemoInputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCPUsLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCPUsTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyCredentialsErrorMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestVersionLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyCredentialCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UrlLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImportedCountLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimedMinsTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestCountTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputFileBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTestTypeRB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountTestTypeRB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimedTestTypeRB)).BeginInit();
            this.DemoMetricsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemoChartView)).BeginInit();
            this.DemoChartView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisabledLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbortButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBGLabel)).BeginInit();
            this.StatusBGLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThroughputTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemoClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestEndTimeLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThroughputLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApiCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestStartTimeLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvgApiThreadTimeLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElapsedTimeLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BenchmarkProgressBar)).BeginInit();
            this.AdvancedSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConstrucitonZoneImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientIdTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientProfileIdTB)).BeginInit();
            this.SuspendLayout();
            // 
            // TransactionGB
            // 
            this.TransactionGB.BackColor = System.Drawing.Color.Azure;
            this.TransactionGB.Controls.Add(this.label16);
            this.TransactionGB.Controls.Add(this.PCodeTB);
            this.TransactionGB.Controls.Add(this.InvoiceDate);
            this.TransactionGB.Controls.Add(this.label5);
            this.TransactionGB.Controls.Add(this.CustNoTB);
            this.TransactionGB.Controls.Add(this.label4);
            this.TransactionGB.Controls.Add(this.ViewReqJsonPB);
            this.TransactionGB.Controls.Add(this.label3);
            this.TransactionGB.Controls.Add(this.CompanyIdentifierTB);
            this.TransactionGB.Controls.Add(this.ChargeTB);
            this.TransactionGB.Controls.Add(this.PostSamplePB);
            this.TransactionGB.Controls.Add(this.ChargeLB);
            this.TransactionGB.Controls.Add(this.ServiceTB);
            this.TransactionGB.Controls.Add(this.ServiceLB);
            this.TransactionGB.Controls.Add(this.TransactionTB);
            this.TransactionGB.Controls.Add(this.TransactionLB);
            this.TransactionGB.Location = new System.Drawing.Point(7, 14);
            this.TransactionGB.Margin = new System.Windows.Forms.Padding(2);
            this.TransactionGB.Name = "TransactionGB";
            this.TransactionGB.Padding = new System.Windows.Forms.Padding(2);
            this.TransactionGB.Size = new System.Drawing.Size(458, 139);
            this.TransactionGB.TabIndex = 30;
            this.TransactionGB.TabStop = false;
            this.TransactionGB.Text = "Default Telecom Transaction Values";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 59;
            this.label16.Text = "PCode:";
            // 
            // PCodeTB
            // 
            this.PCodeTB.Location = new System.Drawing.Point(66, 111);
            this.PCodeTB.Name = "PCodeTB";
            this.PCodeTB.Size = new System.Drawing.Size(92, 20);
            this.PCodeTB.TabIndex = 58;
            this.PCodeTB.Text = "2636900";
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.InvoiceDate.Location = new System.Drawing.Point(66, 82);
            this.InvoiceDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.InvoiceDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.Size = new System.Drawing.Size(104, 20);
            this.InvoiceDate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Cust No:";
            // 
            // CustNoTB
            // 
            this.CustNoTB.Location = new System.Drawing.Point(66, 50);
            this.CustNoTB.Name = "CustNoTB";
            this.CustNoTB.Size = new System.Drawing.Size(92, 20);
            this.CustNoTB.TabIndex = 5;
            this.CustNoTB.Text = "21153";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Inv Date:";
            // 
            // ViewReqJsonPB
            // 
            this.ViewReqJsonPB.Location = new System.Drawing.Point(332, 18);
            this.ViewReqJsonPB.Name = "ViewReqJsonPB";
            this.ViewReqJsonPB.Size = new System.Drawing.Size(107, 34);
            this.ViewReqJsonPB.TabIndex = 10;
            this.ViewReqJsonPB.Text = "View Transaction as JSON";
            this.ViewReqJsonPB.UseVisualStyleBackColor = true;
            this.ViewReqJsonPB.Click += new System.EventHandler(this.ViewReqJsonPB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Company:";
            // 
            // CompanyIdentifierTB
            // 
            this.CompanyIdentifierTB.Location = new System.Drawing.Point(66, 25);
            this.CompanyIdentifierTB.Name = "CompanyIdentifierTB";
            this.CompanyIdentifierTB.Size = new System.Drawing.Size(92, 20);
            this.CompanyIdentifierTB.TabIndex = 4;
            this.CompanyIdentifierTB.Text = "TST";
            // 
            // ChargeTB
            // 
            this.ChargeTB.Location = new System.Drawing.Point(244, 81);
            this.ChargeTB.Name = "ChargeTB";
            this.ChargeTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChargeTB.Size = new System.Drawing.Size(60, 20);
            this.ChargeTB.TabIndex = 9;
            this.ChargeTB.Text = "100.00";
            // 
            // PostSamplePB
            // 
            this.PostSamplePB.Location = new System.Drawing.Point(332, 100);
            this.PostSamplePB.Name = "PostSamplePB";
            this.PostSamplePB.Size = new System.Drawing.Size(107, 23);
            this.PostSamplePB.TabIndex = 11;
            this.PostSamplePB.Text = "Run Sample";
            this.PostSamplePB.UseVisualStyleBackColor = true;
            this.PostSamplePB.Click += new System.EventHandler(this.PostSampleBTN_Click);
            // 
            // ChargeLB
            // 
            this.ChargeLB.AutoSize = true;
            this.ChargeLB.Location = new System.Drawing.Point(195, 84);
            this.ChargeLB.Name = "ChargeLB";
            this.ChargeLB.Size = new System.Drawing.Size(44, 13);
            this.ChargeLB.TabIndex = 19;
            this.ChargeLB.Text = "Charge:";
            // 
            // ServiceTB
            // 
            this.ServiceTB.Location = new System.Drawing.Point(256, 46);
            this.ServiceTB.Name = "ServiceTB";
            this.ServiceTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ServiceTB.Size = new System.Drawing.Size(48, 20);
            this.ServiceTB.TabIndex = 7;
            this.ServiceTB.Text = "6";
            // 
            // ServiceLB
            // 
            this.ServiceLB.AutoSize = true;
            this.ServiceLB.Location = new System.Drawing.Point(164, 49);
            this.ServiceLB.Name = "ServiceLB";
            this.ServiceLB.Size = new System.Drawing.Size(73, 13);
            this.ServiceLB.TabIndex = 17;
            this.ServiceLB.Text = "Service Type:";
            // 
            // TransactionTB
            // 
            this.TransactionTB.Location = new System.Drawing.Point(256, 25);
            this.TransactionTB.Name = "TransactionTB";
            this.TransactionTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransactionTB.Size = new System.Drawing.Size(48, 20);
            this.TransactionTB.TabIndex = 6;
            this.TransactionTB.Text = "13";
            // 
            // TransactionLB
            // 
            this.TransactionLB.AutoSize = true;
            this.TransactionLB.Location = new System.Drawing.Point(164, 28);
            this.TransactionLB.Name = "TransactionLB";
            this.TransactionLB.Size = new System.Drawing.Size(93, 13);
            this.TransactionLB.TabIndex = 15;
            this.TransactionLB.Text = "Transaction Type:";
            // 
            // CalcTaxInclusiveAdjustmentRB
            // 
            this.CalcTaxInclusiveAdjustmentRB.AutoSize = true;
            this.CalcTaxInclusiveAdjustmentRB.Location = new System.Drawing.Point(16, 86);
            this.CalcTaxInclusiveAdjustmentRB.Margin = new System.Windows.Forms.Padding(2);
            this.CalcTaxInclusiveAdjustmentRB.Name = "CalcTaxInclusiveAdjustmentRB";
            this.CalcTaxInclusiveAdjustmentRB.Size = new System.Drawing.Size(143, 17);
            this.CalcTaxInclusiveAdjustmentRB.TabIndex = 23;
            this.CalcTaxInclusiveAdjustmentRB.Text = "Tax Inclusive Adjustment";
            this.CalcTaxInclusiveAdjustmentRB.UseVisualStyleBackColor = true;
            // 
            // CalcAdjustmentRB
            // 
            this.CalcAdjustmentRB.AutoSize = true;
            this.CalcAdjustmentRB.Location = new System.Drawing.Point(16, 45);
            this.CalcAdjustmentRB.Margin = new System.Windows.Forms.Padding(2);
            this.CalcAdjustmentRB.Name = "CalcAdjustmentRB";
            this.CalcAdjustmentRB.Size = new System.Drawing.Size(77, 17);
            this.CalcAdjustmentRB.TabIndex = 21;
            this.CalcAdjustmentRB.Text = "Adjustment";
            this.CalcAdjustmentRB.UseVisualStyleBackColor = true;
            // 
            // CalcTaxInclusiveRB
            // 
            this.CalcTaxInclusiveRB.AutoSize = true;
            this.CalcTaxInclusiveRB.Location = new System.Drawing.Point(16, 66);
            this.CalcTaxInclusiveRB.Margin = new System.Windows.Forms.Padding(2);
            this.CalcTaxInclusiveRB.Name = "CalcTaxInclusiveRB";
            this.CalcTaxInclusiveRB.Size = new System.Drawing.Size(88, 17);
            this.CalcTaxInclusiveRB.TabIndex = 22;
            this.CalcTaxInclusiveRB.Text = "Tax Inclusive";
            this.CalcTaxInclusiveRB.UseVisualStyleBackColor = true;
            // 
            // CalcStandardRB
            // 
            this.CalcStandardRB.AutoSize = true;
            this.CalcStandardRB.Checked = true;
            this.CalcStandardRB.Location = new System.Drawing.Point(16, 24);
            this.CalcStandardRB.Margin = new System.Windows.Forms.Padding(2);
            this.CalcStandardRB.Name = "CalcStandardRB";
            this.CalcStandardRB.Size = new System.Drawing.Size(68, 17);
            this.CalcStandardRB.TabIndex = 20;
            this.CalcStandardRB.TabStop = true;
            this.CalcStandardRB.Text = "Standard";
            this.CalcStandardRB.UseVisualStyleBackColor = true;
            // 
            // BenchmarkSettingsGB
            // 
            this.BenchmarkSettingsGB.BackColor = System.Drawing.Color.Lavender;
            this.BenchmarkSettingsGB.Controls.Add(this.BatchRB);
            this.BenchmarkSettingsGB.Controls.Add(this.ZipLookupRB);
            this.BenchmarkSettingsGB.Controls.Add(this.CalcStandardRB);
            this.BenchmarkSettingsGB.Controls.Add(this.CalcTaxInclusiveAdjustmentRB);
            this.BenchmarkSettingsGB.Controls.Add(this.CalcAdjustmentRB);
            this.BenchmarkSettingsGB.Controls.Add(this.CalcTaxInclusiveRB);
            this.BenchmarkSettingsGB.Location = new System.Drawing.Point(7, 170);
            this.BenchmarkSettingsGB.Name = "BenchmarkSettingsGB";
            this.BenchmarkSettingsGB.Size = new System.Drawing.Size(458, 195);
            this.BenchmarkSettingsGB.TabIndex = 54;
            this.BenchmarkSettingsGB.TabStop = false;
            this.BenchmarkSettingsGB.Text = "API Call Options";
            // 
            // BatchRB
            // 
            this.BatchRB.AutoSize = true;
            this.BatchRB.Location = new System.Drawing.Point(16, 129);
            this.BatchRB.Margin = new System.Windows.Forms.Padding(2);
            this.BatchRB.Name = "BatchRB";
            this.BatchRB.Size = new System.Drawing.Size(53, 17);
            this.BatchRB.TabIndex = 27;
            this.BatchRB.Text = "Batch";
            this.BatchRB.UseVisualStyleBackColor = true;
            // 
            // ZipLookupRB
            // 
            this.ZipLookupRB.AutoSize = true;
            this.ZipLookupRB.Location = new System.Drawing.Point(16, 108);
            this.ZipLookupRB.Margin = new System.Windows.Forms.Padding(2);
            this.ZipLookupRB.Name = "ZipLookupRB";
            this.ZipLookupRB.Size = new System.Drawing.Size(79, 17);
            this.ZipLookupRB.TabIndex = 24;
            this.ZipLookupRB.Text = "Zip Lookup";
            this.ZipLookupRB.UseVisualStyleBackColor = true;
            // 
            // DemoTabControl
            // 
            this.DemoTabControl.Controls.Add(this.DemoInputTab);
            this.DemoTabControl.Controls.Add(this.DemoMetricsTab);
            this.DemoTabControl.Controls.Add(this.AdvancedSettingsTab);
            this.DemoTabControl.Location = new System.Drawing.Point(0, 0);
            this.DemoTabControl.Name = "DemoTabControl";
            this.DemoTabControl.SelectedIndex = 0;
            this.DemoTabControl.Size = new System.Drawing.Size(883, 397);
            this.DemoTabControl.TabIndex = 58;
            this.DemoTabControl.SelectedIndexChanged += new System.EventHandler(this.DemoTabControl_SelectedIndexChanged);
            // 
            // DemoInputTab
            // 
            this.DemoInputTab.Controls.Add(this.radPanel4);
            this.DemoInputTab.Controls.Add(this.radPanel2);
            this.DemoInputTab.Controls.Add(this.radPanel3);
            this.DemoInputTab.Controls.Add(this.radPanel1);
            this.DemoInputTab.Location = new System.Drawing.Point(4, 22);
            this.DemoInputTab.Name = "DemoInputTab";
            this.DemoInputTab.Padding = new System.Windows.Forms.Padding(3);
            this.DemoInputTab.Size = new System.Drawing.Size(875, 371);
            this.DemoInputTab.TabIndex = 0;
            this.DemoInputTab.Text = "Inputs";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.radLabel8);
            this.radPanel4.Controls.Add(this.GoButton);
            this.radPanel4.Location = new System.Drawing.Point(449, 210);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(423, 158);
            this.radPanel4.TabIndex = 34;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel8.Location = new System.Drawing.Point(23, 33);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(43, 19);
            this.radLabel8.TabIndex = 30;
            this.radLabel8.Text = "Step 4";
            // 
            // GoButton
            // 
            this.GoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GoButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.GoButton.Image = ((System.Drawing.Image)(resources.GetObject("GoButton.Image")));
            this.GoButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.GoButton.Location = new System.Drawing.Point(80, 10);
            this.GoButton.Margin = new System.Windows.Forms.Padding(0);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(126, 126);
            this.GoButton.TabIndex = 14;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            this.GoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GoButton_MouseDown);
            this.GoButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GoButton_MouseUp);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radLabel7);
            this.radPanel2.Controls.Add(this.ThreadTrackBar);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.AvailableCPUsLB);
            this.radPanel2.Controls.Add(this.AvailableCPUsTB);
            this.radPanel2.Location = new System.Drawing.Point(449, 3);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(423, 205);
            this.radPanel2.TabIndex = 33;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel7.Location = new System.Drawing.Point(23, 23);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(192, 19);
            this.radLabel7.TabIndex = 29;
            this.radLabel7.Text = "Step 3 - Configure thread usage";
            // 
            // ThreadTrackBar
            // 
            this.ThreadTrackBar.LabelStyle = Telerik.WinControls.UI.TrackBarLabelStyle.BottomRight;
            this.ThreadTrackBar.Location = new System.Drawing.Point(87, 98);
            this.ThreadTrackBar.Maximum = 32F;
            this.ThreadTrackBar.Name = "ThreadTrackBar";
            this.ThreadTrackBar.Size = new System.Drawing.Size(311, 43);
            this.ThreadTrackBar.TabIndex = 1;
            this.ThreadTrackBar.Text = "ThreadTrackBar";
            this.ThreadTrackBar.TickStyle = Telerik.WinControls.Enumerations.TickStyles.BottomRight;
            this.ThreadTrackBar.Value = 10F;
            this.ThreadTrackBar.ValueChanged += new System.EventHandler(this.ThreadTrackBar_ValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(30, 98);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(51, 47);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Threads\r\n    to\r\n   use";
            // 
            // AvailableCPUsLB
            // 
            this.AvailableCPUsLB.Location = new System.Drawing.Point(30, 62);
            this.AvailableCPUsLB.MinimumSize = new System.Drawing.Size(20, 20);
            this.AvailableCPUsLB.Name = "AvailableCPUsLB";
            // 
            // 
            // 
            this.AvailableCPUsLB.RootElement.DefaultSize = new System.Drawing.Size(20, 20);
            this.AvailableCPUsLB.RootElement.MinSize = new System.Drawing.Size(20, 20);
            this.AvailableCPUsLB.Size = new System.Drawing.Size(80, 20);
            this.AvailableCPUsLB.TabIndex = 5;
            this.AvailableCPUsLB.Text = "Available CPUs";
            // 
            // AvailableCPUsTB
            // 
            this.AvailableCPUsTB.BorderVisible = true;
            this.AvailableCPUsTB.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.AvailableCPUsTB.Location = new System.Drawing.Point(116, 60);
            this.AvailableCPUsTB.MinimumSize = new System.Drawing.Size(20, 20);
            this.AvailableCPUsTB.Name = "AvailableCPUsTB";
            // 
            // 
            // 
            this.AvailableCPUsTB.RootElement.MinSize = new System.Drawing.Size(20, 20);
            this.AvailableCPUsTB.Size = new System.Drawing.Size(20, 20);
            this.AvailableCPUsTB.TabIndex = 22;
            this.AvailableCPUsTB.Text = "10";
            this.AvailableCPUsTB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.ClientProfileIdTB);
            this.radPanel3.Controls.Add(this.radLabel2);
            this.radPanel3.Controls.Add(this.ClientIdTB);
            this.radPanel3.Controls.Add(this.radLabel14);
            this.radPanel3.Controls.Add(this.VerifyCredentialsErrorMsg);
            this.radPanel3.Controls.Add(this.RestVersionLB);
            this.radPanel3.Controls.Add(this.VerifyCredentialCheckBox);
            this.radPanel3.Controls.Add(this.radLabel4);
            this.radPanel3.Controls.Add(this.UrlLabel);
            this.radPanel3.Controls.Add(this.radLabel5);
            this.radPanel3.Controls.Add(this.UsernameTB);
            this.radPanel3.Controls.Add(this.PasswordTB);
            this.radPanel3.Controls.Add(this.radLabel6);
            this.radPanel3.Location = new System.Drawing.Point(3, 210);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(443, 158);
            this.radPanel3.TabIndex = 32;
            // 
            // VerifyCredentialsErrorMsg
            // 
            this.VerifyCredentialsErrorMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VerifyCredentialsErrorMsg.Location = new System.Drawing.Point(152, 102);
            this.VerifyCredentialsErrorMsg.Name = "VerifyCredentialsErrorMsg";
            this.VerifyCredentialsErrorMsg.Size = new System.Drawing.Size(2, 2);
            this.VerifyCredentialsErrorMsg.TabIndex = 31;
            // 
            // RestVersionLB
            // 
            this.RestVersionLB.Location = new System.Drawing.Point(269, 136);
            this.RestVersionLB.MinimumSize = new System.Drawing.Size(160, 18);
            this.RestVersionLB.Name = "RestVersionLB";
            // 
            // 
            // 
            this.RestVersionLB.RootElement.MinSize = new System.Drawing.Size(160, 18);
            this.RestVersionLB.Size = new System.Drawing.Size(160, 18);
            this.RestVersionLB.TabIndex = 30;
            this.RestVersionLB.Text = "REST API Version: (unverified)";
            this.RestVersionLB.TextWrap = false;
            // 
            // VerifyCredentialCheckBox
            // 
            this.VerifyCredentialCheckBox.Location = new System.Drawing.Point(27, 102);
            this.VerifyCredentialCheckBox.Name = "VerifyCredentialCheckBox";
            this.VerifyCredentialCheckBox.Size = new System.Drawing.Size(108, 18);
            this.VerifyCredentialCheckBox.TabIndex = 29;
            this.VerifyCredentialCheckBox.Text = "Verify Credentials";
            this.VerifyCredentialCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.VerifyCredentialCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.VerifyCredentialCheckBox.GetChildAt(0))).Text = "Verify Credentials";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadCheckmark)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.UI.RadCheckmark)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).GradientAngle = 45F;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).GradientPercentage = 0.15F;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).GradientPercentage2 = 0.7F;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.VerifyCredentialCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel4.Location = new System.Drawing.Point(17, 20);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(170, 19);
            this.radLabel4.TabIndex = 24;
            this.radLabel4.Text = "Step 2 - Set your credentials";
            // 
            // UrlLabel
            // 
            this.UrlLabel.Location = new System.Drawing.Point(27, 136);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(194, 18);
            this.UrlLabel.TabIndex = 2;
            this.UrlLabel.Text = "https://communicationsua.avalara.net";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(27, 43);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(56, 18);
            this.radLabel5.TabIndex = 27;
            this.radLabel5.Text = "Username";
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(89, 41);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(157, 20);
            this.UsernameTB.TabIndex = 25;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(326, 43);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(91, 20);
            this.PasswordTB.TabIndex = 26;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(267, 43);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(53, 18);
            this.radLabel6.TabIndex = 28;
            this.radLabel6.Text = "Password";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.ImportedCountLB);
            this.radPanel1.Controls.Add(this.TimedMinsTB);
            this.radPanel1.Controls.Add(this.TestCountTB);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.InputFileBrowser);
            this.radPanel1.Controls.Add(this.InputTestTypeRB);
            this.radPanel1.Controls.Add(this.CountTestTypeRB);
            this.radPanel1.Controls.Add(this.TimedTestTypeRB);
            this.radPanel1.Location = new System.Drawing.Point(3, 3);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(443, 205);
            this.radPanel1.TabIndex = 31;
            // 
            // ImportedCountLB
            // 
            this.ImportedCountLB.Location = new System.Drawing.Point(54, 163);
            this.ImportedCountLB.Name = "ImportedCountLB";
            this.ImportedCountLB.Size = new System.Drawing.Size(2, 2);
            this.ImportedCountLB.TabIndex = 31;
            // 
            // TimedMinsTB
            // 
            this.TimedMinsTB.Location = new System.Drawing.Point(143, 100);
            this.TimedMinsTB.Mask = "D";
            this.TimedMinsTB.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.TimedMinsTB.Name = "TimedMinsTB";
            this.TimedMinsTB.Size = new System.Drawing.Size(35, 20);
            this.TimedMinsTB.TabIndex = 27;
            this.TimedMinsTB.TabStop = false;
            this.TimedMinsTB.Text = "1";
            this.TimedMinsTB.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TimedMinsTB.ValueChanged += new System.EventHandler(this.TimedMinsTB_ValueChanged);
            // 
            // TestCountTB
            // 
            this.TestCountTB.Location = new System.Drawing.Point(143, 61);
            this.TestCountTB.Mask = "D";
            this.TestCountTB.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.TestCountTB.Name = "TestCountTB";
            this.TestCountTB.Size = new System.Drawing.Size(35, 20);
            this.TestCountTB.TabIndex = 26;
            this.TestCountTB.TabStop = false;
            this.TestCountTB.Text = "10";
            this.TestCountTB.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TestCountTB.ValueChanged += new System.EventHandler(this.TestCountTB_ValueChanged);
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.TestCountTB.GetChildAt(0))).Text = "10";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(17, 23);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(229, 19);
            this.radLabel3.TabIndex = 23;
            this.radLabel3.Text = "Step 1 - Choose the type of test to run";
            // 
            // InputFileBrowser
            // 
            this.InputFileBrowser.Location = new System.Drawing.Point(143, 137);
            this.InputFileBrowser.Name = "InputFileBrowser";
            this.InputFileBrowser.ReadOnly = false;
            this.InputFileBrowser.Size = new System.Drawing.Size(284, 20);
            this.InputFileBrowser.TabIndex = 4;
            this.InputFileBrowser.Text = "Sample.csv";
            this.InputFileBrowser.Value = "(Click to Select)";
            this.InputFileBrowser.Click += new System.EventHandler(this.InputFileBrowser_Click);
            ((Telerik.WinControls.UI.RadBrowseEditorElement)(this.InputFileBrowser.GetChildAt(0))).Text = "(Click to Select)";
            // 
            // InputTestTypeRB
            // 
            this.InputTestTypeRB.Location = new System.Drawing.Point(27, 138);
            this.InputTestTypeRB.Name = "InputTestTypeRB";
            this.InputTestTypeRB.Size = new System.Drawing.Size(67, 18);
            this.InputTestTypeRB.TabIndex = 15;
            this.InputTestTypeRB.TabStop = false;
            this.InputTestTypeRB.Text = "Input File";
            // 
            // CountTestTypeRB
            // 
            this.CountTestTypeRB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CountTestTypeRB.Location = new System.Drawing.Point(27, 62);
            this.CountTestTypeRB.Name = "CountTestTypeRB";
            this.CountTestTypeRB.Size = new System.Drawing.Size(112, 18);
            this.CountTestTypeRB.TabIndex = 16;
            this.CountTestTypeRB.Text = "Count (thousands)";
            this.CountTestTypeRB.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // TimedTestTypeRB
            // 
            this.TimedTestTypeRB.Location = new System.Drawing.Point(27, 100);
            this.TimedTestTypeRB.Name = "TimedTestTypeRB";
            this.TimedTestTypeRB.Size = new System.Drawing.Size(85, 18);
            this.TimedTestTypeRB.TabIndex = 17;
            this.TimedTestTypeRB.TabStop = false;
            this.TimedTestTypeRB.Text = "Timed (mins)";
            // 
            // DemoMetricsTab
            // 
            this.DemoMetricsTab.Controls.Add(this.DemoChartView);
            this.DemoMetricsTab.Controls.Add(this.radPanel5);
            this.DemoMetricsTab.Controls.Add(this.BenchmarkProgressBar);
            this.DemoMetricsTab.Location = new System.Drawing.Point(4, 22);
            this.DemoMetricsTab.Name = "DemoMetricsTab";
            this.DemoMetricsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DemoMetricsTab.Size = new System.Drawing.Size(875, 371);
            this.DemoMetricsTab.TabIndex = 1;
            this.DemoMetricsTab.Text = "Metrics";
            this.DemoMetricsTab.UseVisualStyleBackColor = true;
            // 
            // DemoChartView
            // 
            this.DemoChartView.AreaDesign = cartesianArea1;
            this.DemoChartView.Controls.Add(this.DisabledLB);
            this.DemoChartView.Location = new System.Drawing.Point(8, 6);
            this.DemoChartView.Name = "DemoChartView";
            this.DemoChartView.ShowGrid = false;
            this.DemoChartView.Size = new System.Drawing.Size(412, 328);
            this.DemoChartView.TabIndex = 10;
            this.DemoChartView.Text = "Chart";
            ((Telerik.WinControls.UI.RadChartElement)(this.DemoChartView.GetChildAt(0))).BackColor2 = System.Drawing.SystemColors.ControlLight;
            // 
            // DisabledLB
            // 
            this.DisabledLB.AutoSize = false;
            this.DisabledLB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisabledLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DisabledLB.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.DisabledLB.Location = new System.Drawing.Point(137, 96);
            this.DisabledLB.Name = "DisabledLB";
            this.DisabledLB.Size = new System.Drawing.Size(139, 90);
            this.DisabledLB.TabIndex = 23;
            this.DisabledLB.Text = "Disabled by Config";
            this.DisabledLB.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.DisabledLB.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.DisabledLB.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.DisabledLB.GetChildAt(0))).Text = "Disabled by Config";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.DisabledLB.GetChildAt(0).GetChildAt(0))).Opacity = 1D;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.DisabledLB.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.AbortButton);
            this.radPanel5.Controls.Add(this.radLabel13);
            this.radPanel5.Controls.Add(this.StatusBGLabel);
            this.radPanel5.Controls.Add(this.radLabel11);
            this.radPanel5.Controls.Add(this.ThroughputTB);
            this.radPanel5.Controls.Add(this.DemoClock);
            this.radPanel5.Controls.Add(this.TestEndTimeLB);
            this.radPanel5.Controls.Add(this.radLabel12);
            this.radPanel5.Controls.Add(this.ThroughputLB);
            this.radPanel5.Controls.Add(this.ApiCalls);
            this.radPanel5.Controls.Add(this.TestStartTimeLB);
            this.radPanel5.Controls.Add(this.AvgApiThreadTimeLB);
            this.radPanel5.Controls.Add(this.ElapsedTimeLB);
            this.radPanel5.Controls.Add(this.radLabel9);
            this.radPanel5.Controls.Add(this.radLabel10);
            this.radPanel5.Location = new System.Drawing.Point(426, 6);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(441, 328);
            this.radPanel5.TabIndex = 0;
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(3, 301);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(74, 24);
            this.AbortButton.TabIndex = 25;
            this.AbortButton.Text = "Abort";
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.AbortButton.GetChildAt(0))).Text = "Abort";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(2))).LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(2))).TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(2))).RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.AbortButton.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // radLabel13
            // 
            this.radLabel13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel13.Location = new System.Drawing.Point(19, 161);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(80, 25);
            this.radLabel13.TabIndex = 21;
            this.radLabel13.Text = "End Time";
            // 
            // StatusBGLabel
            // 
            this.StatusBGLabel.AutoSize = false;
            this.StatusBGLabel.Controls.Add(this.StatusLabel);
            this.StatusBGLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBGLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.StatusBGLabel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBGLabel.Location = new System.Drawing.Point(279, 261);
            this.StatusBGLabel.Name = "StatusBGLabel";
            this.StatusBGLabel.Size = new System.Drawing.Size(150, 30);
            this.StatusBGLabel.TabIndex = 23;
            this.StatusBGLabel.Text = "(placeholder)";
            this.StatusBGLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusLabel.Location = new System.Drawing.Point(1, 1);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(150, 30);
            this.StatusLabel.TabIndex = 22;
            this.StatusLabel.Text = "(placeholder)";
            this.StatusLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.StatusLabel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.StatusLabel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.StatusLabel.GetChildAt(0))).Text = "(placeholder)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.StatusLabel.GetChildAt(0).GetChildAt(0))).Opacity = 1D;
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.StatusLabel.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel11.Location = new System.Drawing.Point(19, 130);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(88, 25);
            this.radLabel11.TabIndex = 20;
            this.radLabel11.Text = "Start Time";
            // 
            // ThroughputTB
            // 
            this.ThroughputTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ThroughputTB.ForeColor = System.Drawing.Color.Blue;
            this.ThroughputTB.Location = new System.Drawing.Point(152, 223);
            this.ThroughputTB.Name = "ThroughputTB";
            this.ThroughputTB.Size = new System.Drawing.Size(84, 25);
            this.ThroughputTB.TabIndex = 18;
            this.ThroughputTB.Text = "(pending)";
            // 
            // DemoClock
            // 
            this.DemoClock.Location = new System.Drawing.Point(287, 3);
            this.DemoClock.Name = "DemoClock";
            this.DemoClock.Size = new System.Drawing.Size(134, 135);
            this.DemoClock.TabIndex = 8;
            this.DemoClock.Text = "radClock1";
            // 
            // TestEndTimeLB
            // 
            this.TestEndTimeLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TestEndTimeLB.Location = new System.Drawing.Point(151, 161);
            this.TestEndTimeLB.Name = "TestEndTimeLB";
            this.TestEndTimeLB.Size = new System.Drawing.Size(84, 25);
            this.TestEndTimeLB.TabIndex = 19;
            this.TestEndTimeLB.Text = "(pending)";
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel12.Location = new System.Drawing.Point(19, 50);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(125, 25);
            this.radLabel12.TabIndex = 14;
            this.radLabel12.Text = "Calls Processed";
            // 
            // ThroughputLB
            // 
            this.ThroughputLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ThroughputLB.Location = new System.Drawing.Point(19, 223);
            this.ThroughputLB.Name = "ThroughputLB";
            this.ThroughputLB.Size = new System.Drawing.Size(101, 25);
            this.ThroughputLB.TabIndex = 17;
            this.ThroughputLB.Text = "Throughput";
            // 
            // ApiCalls
            // 
            this.ApiCalls.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ApiCalls.ForeColor = System.Drawing.Color.Blue;
            this.ApiCalls.Location = new System.Drawing.Point(159, 50);
            this.ApiCalls.Name = "ApiCalls";
            this.ApiCalls.Size = new System.Drawing.Size(38, 25);
            this.ApiCalls.TabIndex = 12;
            this.ApiCalls.Text = "nnn";
            // 
            // TestStartTimeLB
            // 
            this.TestStartTimeLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TestStartTimeLB.Location = new System.Drawing.Point(151, 130);
            this.TestStartTimeLB.Name = "TestStartTimeLB";
            this.TestStartTimeLB.Size = new System.Drawing.Size(84, 25);
            this.TestStartTimeLB.TabIndex = 18;
            this.TestStartTimeLB.Text = "(pending)";
            // 
            // AvgApiThreadTimeLB
            // 
            this.AvgApiThreadTimeLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AvgApiThreadTimeLB.ForeColor = System.Drawing.Color.Blue;
            this.AvgApiThreadTimeLB.Location = new System.Drawing.Point(159, 19);
            this.AvgApiThreadTimeLB.Name = "AvgApiThreadTimeLB";
            this.AvgApiThreadTimeLB.Size = new System.Drawing.Size(77, 25);
            this.AvgApiThreadTimeLB.TabIndex = 11;
            this.AvgApiThreadTimeLB.Text = "0.00 secs";
            // 
            // ElapsedTimeLB
            // 
            this.ElapsedTimeLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ElapsedTimeLB.ForeColor = System.Drawing.Color.Blue;
            this.ElapsedTimeLB.Location = new System.Drawing.Point(152, 192);
            this.ElapsedTimeLB.Name = "ElapsedTimeLB";
            this.ElapsedTimeLB.Size = new System.Drawing.Size(84, 25);
            this.ElapsedTimeLB.TabIndex = 16;
            this.ElapsedTimeLB.Text = "(pending)";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel9.Location = new System.Drawing.Point(19, 19);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(114, 25);
            this.radLabel9.TabIndex = 10;
            this.radLabel9.Text = "Avg Call Time";
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radLabel10.Location = new System.Drawing.Point(19, 192);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(110, 25);
            this.radLabel10.TabIndex = 15;
            this.radLabel10.Text = "Elapsed Time";
            // 
            // BenchmarkProgressBar
            // 
            this.BenchmarkProgressBar.Location = new System.Drawing.Point(8, 340);
            this.BenchmarkProgressBar.Name = "BenchmarkProgressBar";
            this.BenchmarkProgressBar.ShowProgressIndicators = true;
            this.BenchmarkProgressBar.Size = new System.Drawing.Size(859, 24);
            this.BenchmarkProgressBar.TabIndex = 9;
            this.BenchmarkProgressBar.Text = "0 %";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.BenchmarkProgressBar.GetChildAt(0))).ShowProgressIndicators = true;
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.BenchmarkProgressBar.GetChildAt(0))).Text = "0 %";
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.BenchmarkProgressBar.GetChildAt(0).GetChildAt(1))).HorizontalLineColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.BenchmarkProgressBar.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // AdvancedSettingsTab
            // 
            this.AdvancedSettingsTab.Controls.Add(this.ConstrucitonZoneImage);
            this.AdvancedSettingsTab.Controls.Add(this.BenchmarkSettingsGB);
            this.AdvancedSettingsTab.Controls.Add(this.TransactionGB);
            this.AdvancedSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.AdvancedSettingsTab.Name = "AdvancedSettingsTab";
            this.AdvancedSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedSettingsTab.Size = new System.Drawing.Size(875, 371);
            this.AdvancedSettingsTab.TabIndex = 2;
            this.AdvancedSettingsTab.Text = "Advanced";
            this.AdvancedSettingsTab.UseVisualStyleBackColor = true;
            // 
            // ConstrucitonZoneImage
            // 
            this.ConstrucitonZoneImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ConstrucitonZoneImage.ErrorImage")));
            this.ConstrucitonZoneImage.Image = ((System.Drawing.Image)(resources.GetObject("ConstrucitonZoneImage.Image")));
            this.ConstrucitonZoneImage.Location = new System.Drawing.Point(506, 6);
            this.ConstrucitonZoneImage.Name = "ConstrucitonZoneImage";
            this.ConstrucitonZoneImage.Size = new System.Drawing.Size(348, 358);
            this.ConstrucitonZoneImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ConstrucitonZoneImage.TabIndex = 55;
            this.ConstrucitonZoneImage.TabStop = false;
            // 
            // ThreadBarRange
            // 
            this.ThreadBarRange.End = 10F;
            this.ThreadBarRange.Start = 1F;
            // 
            // threadBarRange1
            // 
            this.threadBarRange1.End = 10F;
            this.threadBarRange1.Start = 1F;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(27, 70);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(48, 18);
            this.radLabel2.TabIndex = 34;
            this.radLabel2.Text = "Client Id";
            // 
            // ClientIdTB
            // 
            this.ClientIdTB.Location = new System.Drawing.Point(89, 68);
            this.ClientIdTB.Name = "ClientIdTB";
            this.ClientIdTB.Size = new System.Drawing.Size(47, 20);
            this.ClientIdTB.TabIndex = 32;
            // 
            // radLabel14
            // 
            this.radLabel14.Location = new System.Drawing.Point(143, 70);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(51, 18);
            this.radLabel14.TabIndex = 35;
            this.radLabel14.Text = "Profile Id";
            // 
            // ClientProfileIdTB
            // 
            this.ClientProfileIdTB.Location = new System.Drawing.Point(198, 69);
            this.ClientProfileIdTB.Name = "ClientProfileIdTB";
            this.ClientProfileIdTB.Size = new System.Drawing.Size(47, 20);
            this.ClientProfileIdTB.TabIndex = 36;
            // 
            // TestingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 398);
            this.Controls.Add(this.DemoTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TestingWindow";
            this.Text = "AFC REST Demo Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestingWindow_FormClosing);
            this.Load += new System.EventHandler(this.TestingWindow_Load);
            this.TransactionGB.ResumeLayout(false);
            this.TransactionGB.PerformLayout();
            this.BenchmarkSettingsGB.ResumeLayout(false);
            this.BenchmarkSettingsGB.PerformLayout();
            this.DemoTabControl.ResumeLayout(false);
            this.DemoInputTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            this.radPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCPUsLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCPUsTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyCredentialsErrorMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestVersionLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyCredentialCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UrlLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImportedCountLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimedMinsTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestCountTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputFileBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTestTypeRB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountTestTypeRB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimedTestTypeRB)).EndInit();
            this.DemoMetricsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DemoChartView)).EndInit();
            this.DemoChartView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DisabledLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbortButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBGLabel)).EndInit();
            this.StatusBGLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThroughputTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemoClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestEndTimeLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThroughputLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApiCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestStartTimeLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvgApiThreadTimeLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElapsedTimeLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BenchmarkProgressBar)).EndInit();
            this.AdvancedSettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConstrucitonZoneImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientIdTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientProfileIdTB)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox TransactionGB;
      private System.Windows.Forms.RadioButton CalcTaxInclusiveAdjustmentRB;
      private System.Windows.Forms.RadioButton CalcAdjustmentRB;
      private System.Windows.Forms.RadioButton CalcTaxInclusiveRB;
      private System.Windows.Forms.RadioButton CalcStandardRB;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox CustNoTB;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button ViewReqJsonPB;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox CompanyIdentifierTB;
      private System.Windows.Forms.TextBox ChargeTB;
      private System.Windows.Forms.Button PostSamplePB;
      private System.Windows.Forms.Label ChargeLB;
      private System.Windows.Forms.TextBox ServiceTB;
      private System.Windows.Forms.Label ServiceLB;
      private System.Windows.Forms.TextBox TransactionTB;
      private System.Windows.Forms.Label TransactionLB;
      private System.Windows.Forms.GroupBox BenchmarkSettingsGB;
      private System.Windows.Forms.RadioButton ZipLookupRB;
      private System.Windows.Forms.DateTimePicker InvoiceDate;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.TextBox PCodeTB;
      private System.Windows.Forms.TabControl DemoTabControl;
      private System.Windows.Forms.TabPage DemoInputTab;
      private System.Windows.Forms.TabPage DemoMetricsTab;
      private Telerik.WinControls.UI.RadLabel UrlLabel;
      private Telerik.WinControls.UI.RadTrackBar ThreadTrackBar;
      private Telerik.WinControls.UI.TrackBarRange ThreadBarRange;
      private Telerik.WinControls.UI.TrackBarRange threadBarRange1;
      private Telerik.WinControls.UI.RadBrowseEditor InputFileBrowser;
      private Telerik.WinControls.UI.RadLabel radLabel1;
      private Telerik.WinControls.UI.RadLabel AvailableCPUsLB;
      private Telerik.WinControls.UI.RadButton GoButton;
      private Telerik.WinControls.UI.RadRadioButton TimedTestTypeRB;
      private Telerik.WinControls.UI.RadRadioButton CountTestTypeRB;
      private Telerik.WinControls.UI.RadRadioButton InputTestTypeRB;
      private Telerik.WinControls.UI.RadLabel AvailableCPUsTB;
      private Telerik.WinControls.UI.RadLabel radLabel3;
      private Telerik.WinControls.UI.RadTextBox PasswordTB;
      private Telerik.WinControls.UI.RadTextBox UsernameTB;
      private Telerik.WinControls.UI.RadLabel radLabel4;
      private Telerik.WinControls.UI.RadPanel radPanel4;
      private Telerik.WinControls.UI.RadLabel radLabel8;
      private Telerik.WinControls.UI.RadPanel radPanel2;
      private Telerik.WinControls.UI.RadLabel radLabel7;
      private Telerik.WinControls.UI.RadPanel radPanel3;
      private Telerik.WinControls.UI.RadLabel radLabel5;
      private Telerik.WinControls.UI.RadLabel radLabel6;
      private Telerik.WinControls.UI.RadPanel radPanel1;
      private System.Windows.Forms.TabPage AdvancedSettingsTab;
      private Telerik.WinControls.UI.RadCheckBox VerifyCredentialCheckBox;
      private Telerik.WinControls.UI.RadLabel RestVersionLB;
      private Telerik.WinControls.UI.RadClock DemoClock;
      private Telerik.WinControls.UI.RadMaskedEditBox TestCountTB;
      private Telerik.WinControls.UI.RadMaskedEditBox TimedMinsTB;
      private Telerik.WinControls.UI.RadLabel ImportedCountLB;
      private Telerik.WinControls.UI.RadProgressBar BenchmarkProgressBar;
      private Telerik.WinControls.UI.RadPanel radPanel5;
      private Telerik.WinControls.UI.RadLabel ApiCalls;
      private Telerik.WinControls.UI.RadLabel AvgApiThreadTimeLB;
      private Telerik.WinControls.UI.RadLabel radLabel9;
      private Telerik.WinControls.UI.RadLabel radLabel12;
      private Telerik.WinControls.UI.RadLabel radLabel10;
      private Telerik.WinControls.UI.RadLabel ElapsedTimeLB;
      private Telerik.WinControls.UI.RadLabel ThroughputTB;
      private Telerik.WinControls.UI.RadLabel ThroughputLB;
      private Telerik.WinControls.UI.RadLabel TestEndTimeLB;
      private Telerik.WinControls.UI.RadLabel TestStartTimeLB;
      private Telerik.WinControls.UI.RadLabel VerifyCredentialsErrorMsg;
      private Telerik.WinControls.UI.RadLabel radLabel13;
      private Telerik.WinControls.UI.RadLabel radLabel11;
      private Telerik.WinControls.UI.RadLabel StatusBGLabel;
      private Telerik.WinControls.UI.RadLabel StatusLabel;
      private System.Windows.Forms.RadioButton BatchRB;
      private Telerik.WinControls.UI.RadChartView DemoChartView;
      private Telerik.WinControls.EllipseShape ellipseShape1;
      private Telerik.WinControls.UI.RadButton AbortButton;
      private System.Windows.Forms.PictureBox ConstrucitonZoneImage;
      private Telerik.WinControls.UI.RadLabel DisabledLB;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox ClientIdTB;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadTextBox ClientProfileIdTB;
    }
}

