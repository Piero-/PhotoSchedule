
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Java;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using swag;

namespace PhotoSchedule 
{
	[Activity (Label = "Photo\nSchedule", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	
	public class MainActivity : Activity 
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Main);
			//Reads from Main.axml so it can use names and such from it

			Button btnNotebooks = FindViewById<Button> (Resource.Id.btnNotebooks);
			//"Parsing" the button btnNotebook

			btnNotebooks.Click += delegate{
				StartActivity(typeof(MyFolders));
			};
			//When clicked it goes to the MyFolders axml

			Button btnCamera = FindViewById<Button> (Resource.Id.btnCamera);
			//"Parsing" the button btnCamera

			btnCamera.Click += delegate {
				drawPicture(Picture);
			};
		}
	}
}




	




