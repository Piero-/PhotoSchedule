
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace swag
{
	[Activity (Label = "My Folders")]			
	public class MyFolders : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MyFolders);
			//Reads from the MyFolders axml

			Button btnCreate = FindViewById<Button> (Resource.Id.btnCreate);
			//"Parsing" the button btnCreate

			btnCreate.Click += delegate{

			};
			//When clicked, it creates a new folder
			
		}
	}
}

