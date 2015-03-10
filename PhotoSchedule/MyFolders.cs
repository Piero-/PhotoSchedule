namespace PhotoSchedule
{
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

	[Activity (Label = "My Notebooks", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]		
	public class MyFolders : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (PhotoSchedule.Resource.Layout.MyFolders);
			//Reads from the MyFolders axml

			Button btnMath = FindViewById<Button> (PhotoSchedule.Resource.Id.btnMath);
			Button btnChem = FindViewById<Button> (PhotoSchedule.Resource.Id.btnChem);
			Button btnComp = FindViewById<Button> (PhotoSchedule.Resource.Id.btnComp);
			Button btnHist = FindViewById<Button> (PhotoSchedule.Resource.Id.btnHist);
			Button btnLang = FindViewById<Button> (PhotoSchedule.Resource.Id.btnLang);
			Button btnMisc = FindViewById<Button> (PhotoSchedule.Resource.Id.btnMisc);


			//"Parsing" the button btnCreate

			btnMath.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zMath));
			};

			btnChem.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zChemistry));
			};

			btnComp.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zComputing));
			};

			btnHist.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zHistory));
			};

			btnLang.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zLanguages));
			};

			btnMisc.Click += delegate{
				StartActivity(typeof(PhotoSchedule.zMiscellaneous));
			};
			//When clicked, it creates a new folder
			
		}
	}
}

