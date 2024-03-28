/*
 * Created by SharpDevelop.
 * User: DAVY11177
 * Date: 27.03.2024
 * Time: 13:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;


namespace ParamValueCopy
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("6FBABC23-C6F1-4B68-815A-B32A9C6DD3C9")]
	public partial class ThisApplication
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
        #endregion

        /// <summary>
        /// Method returns list with Category names stored in sorted "List<string>" variable
        /// </summary>
        /// <param name="doc">Gets Revit document</param>
        /// <returns>List of category names</returns>
        public List<string> StoreDocCategories()
		{
        	UIDocument uidoc = this.ActiveUIDocument;
			Document doc = uidoc.Document;
    		Categories categories = doc.Settings.Categories;
    		List<string> catList = new List<string>();
    		
    		foreach (Category cat in categories) 
    		{
    			if (cat.AllowsBoundParameters) { catList.Add(cat.Name); }
    		}
    		catList.Sort();
    		
    		return catList;
		}
		
		/// <summary>
		/// This method just translate List of strings into a multiline one-string text to put it into a MessageBox or logfile.
		/// </summary>
		/// <param name="inputList">List of strings</param>
		/// <returns>One-string element formatted in multiline text</returns>
		public string OutputFormatter(List<string> inputList)
		{
			string result = "";
			//string lineTab = "    ";
			
			foreach (var elem in inputList)
			{
				result += elem + "\n";
			}
			return result;
		}
		
		/// <summary>
		/// This method display MessageBox with list of all document categories.
		/// </summary>
		public void ShowCategories()
		{
			//List<string> catList = new List<string> {"string1", "string2", "string3"};
			List<string> categoryList = StoreDocCategories();
						
			TaskDialog.Show("All categories", "List of categories in project: \n\n" + OutputFormatter(categoryList));
		}

		
		public void ShowWindow()
		{
			List<string> categoryList = StoreDocCategories();
			
			MainWindow window1 = new MainWindow(categoryList);
			window1.Show();
		}
	}
}