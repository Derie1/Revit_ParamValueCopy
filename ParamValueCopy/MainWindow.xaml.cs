﻿/*
 * Created by SharpDevelop.
 * User: DAVY11177
 * Date: 27.03.2024
 * Time: 13:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace ParamValueCopy
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class MainWindow : Window
	{		
		public MainWindow(List<string> catList)
		{
			InitializeComponent();			
			categoryComboBox.ItemsSource = catList;
        }
		
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
			Close();
        }
    }
}