namespace swag 
{
	using System;
	using System.Collections;

	using CameraAppDemo;
	using swag;
	using System.Collections.Generic;
	using Android.App;
	using Android.Content;
	using Android.Content.PM;
	using Android.Graphics;
	using Android.OS;
	using Android.Provider;
	using Android.Widget;

	using Java.IO;

	using Environement = Android.OS.Environment;
	using Uri = Android.Net.Uri;

	public class MainActivity : Activity 
	{
		public static class App{
			public static File _file;
			public static File _dir;     
			public static Bitmap bitmap;
	}


	[Activity (Label = "Photo\nSchedule", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity1 : Activity
    {
       
        private ImageView _imageView;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // make it available in the gallery
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume to much memory 
            // and cause the application to crash.
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height ;
            App.bitmap = App._file.Path.LoadAndResizeBitmap (width, height);
        }
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(PhotoSchedule.Resource.Layout.Main);
			//Reads from Main.axml so it can use names and such from it

			if (IsThereAnAppToTakePictures())
			{
				CreateDirectoryForPictures();

					Button button = FindViewById<Button>(PhotoSchedule.Resource.Id.btnCam);
					_imageView = FindViewById<ImageView>(PhotoSchedule.Resource.Drawable.btnCamera);
				if (App.bitmap != null) {
					_imageView.SetImageBitmap (App.bitmap);
					App.bitmap = null;
				}
				button.Click += TakeAPicture;
			}

				Button btnNotebooks = FindViewById<Button> (PhotoSchedule.Resource.Id.btnNotebooks);
			//"Parsing" the button btnNotebook

			btnNotebooks.Click += delegate{
					StartActivity(typeof(PhotoSchedule.MyFolders));
			};
			//When clicked it goes to the MyFolders axml

				Button btnCamera = FindViewById<Button> (PhotoSchedule.Resource.Id.btnCam);
			//"Parsing" the button btnCamera

			btnCamera.Click += delegate {

			};
		}
		
		private void CreateDirectoryForPictures()
        {
            App._dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));

            StartActivityForResult(intent, 0);
        }
	}
}
}




	




