/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    Data Structs related to Rest Demo Application chart view of status


 UPDATE HISTORY:
    Ryan Robinson   12/21/2016   Created
*/
using System;
using System.Collections.Generic;
using Avalara.TestCommon.APIObjects;
using Telerik.Charting;
using Avalara.RestDemoApplication;

namespace Avalara.TestCommon.DataSetup
{
   public class ChartData
   {
      Telerik.WinControls.UI.ScatterSeries scatterSeries = new Telerik.WinControls.UI.ScatterSeries();
      Telerik.WinControls.UI.RadChartView chartView = null;

      public static int MinChartXValue = 0;
      public static int MaxChartXValue = 0;
      public static bool TossOutlierFlag = false;
      public static int OutlierUpperBound = 0;
      public static int OutlierLowerBound = 0;
      internal TestingWindow TestWin = null;

      public static void SetChartConfiguration(string minX, string maxX, string autFlag, string outUp, string outLow)
      {
         if (!string.IsNullOrEmpty(minX)) Int32.TryParse(minX, out MinChartXValue);
         if (!string.IsNullOrEmpty(maxX)) Int32.TryParse(maxX, out MaxChartXValue);
         if (!string.IsNullOrEmpty(autFlag)) bool.TryParse(autFlag, out TossOutlierFlag);
         if (TossOutlierFlag)
         {
            if (!string.IsNullOrEmpty(outUp)) Int32.TryParse(outUp, out OutlierUpperBound);
            if (!string.IsNullOrEmpty(outLow)) Int32.TryParse(outLow, out OutlierLowerBound);
         }
      }

      public static void SetChartConfiguration(int minX, int maxX, bool autFlag, int outUp, int outLow)
      {
         MinChartXValue = minX;
         MaxChartXValue = maxX;
         TossOutlierFlag = autFlag;
         OutlierUpperBound = outUp;
         OutlierLowerBound = outLow;
      }

      public ChartData(Telerik.WinControls.UI.RadChartView chart, TestingWindow testingWindow)
      {
         chartView = chart;
         TestWin = testingWindow;
         scatterSeries.DataPoints.Clear();
         scatterSeries.BackColor = System.Drawing.Color.Blue;
         scatterSeries.PointSize = new System.Drawing.SizeF(5, 5);
         chartView.Series.Clear();
         chartView.Series.Add(scatterSeries);

         Telerik.WinControls.UI.LinearAxis axis_horz = chartView.Axes[0] as Telerik.WinControls.UI.LinearAxis;
         Telerik.WinControls.UI.LinearAxis axis_vert = chartView.Axes[1] as Telerik.WinControls.UI.LinearAxis;

         axis_horz.LabelFitMode = AxisLabelFitMode.Rotate;
         axis_horz.LabelRotationAngle = 310;
         axis_horz.Title = "Calls";

         if (MinChartXValue > 0) axis_vert.Minimum = MinChartXValue;
         if (MaxChartXValue > MinChartXValue) axis_vert.Maximum = MaxChartXValue;
         axis_vert.Title = "Milliseconds";

      }

      public void AddChartPoint(int x, int y)
      {
         if (TestWin.DisableGraph)
         {
            return;
         }

         if ((!TossOutlierFlag) ||
            ((y > OutlierLowerBound) && ((OutlierUpperBound <= 0) || (y < OutlierUpperBound))))
         {
            TestWin.UpdateChartView(x, y);
            
         }
      }
   } // end public class ChartData
}



