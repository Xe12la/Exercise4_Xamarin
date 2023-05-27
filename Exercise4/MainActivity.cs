using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using AlertDialog = Android.App.AlertDialog;

namespace Exercise4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btnConsent = FindViewById<Button>(Resource.Id.btnConsent);
            btnConsent.Click += BtnConsent_Click;


        }

        private void BtnConsent_Click(object sender, System.EventArgs e)
        {
            //Kulang og validation sa text
                int _age = 0;
                var build = new AlertDialog.Builder(this);
                AlertDialog dialog = build.Create();
                
            try
            {
                var age = FindViewById<EditText>(Resource.Id.txtAge);
                _age = int.Parse(age.Text);
                if (_age > 0)
                {

                    dialog.SetTitle("Confirm");
                    dialog.SetMessage("Do you want to continue?");
                    dialog.SetButton(
                        "Yes", (x, x1) =>
                        {
                            var fname = FindViewById<EditText>(Resource.Id.txtFname);
                            var mname = FindViewById<EditText>(Resource.Id.txtMInitial);
                            var lname = FindViewById<EditText>(Resource.Id.txtxLName);
                            var address = FindViewById<EditText>(Resource.Id.txtAddress);
                            var mother = FindViewById<EditText>(Resource.Id.txtMotherN);
                            var father = FindViewById<EditText>(Resource.Id.txtFatherN);

                            Class1.fname = fname.Text;
                            Class1.mname = mname.Text;
                            Class1.lname = lname.Text;
                            Class1.age = _age.ToString();
                            Class1.address = address.Text;
                            Class1.mothersname = mother.Text;
                            Class1.fathersname = father.Text;

                            var intent1 = new Intent(this, typeof(ConsentForm));
                            StartActivity(intent1);
                        });
                }
                else
                {
                    Toast.MakeText(this, "Please verify Informatio: example Age", ToastLength.Long);
                }

                dialog.SetButton2(
                "No", (x, x1) => {

                    var fname = FindViewById<EditText>(Resource.Id.txtFname);
                    fname.Text = "";
                    var mname = FindViewById<EditText>(Resource.Id.txtMInitial);
                    mname.Text = "";
                    var lname = FindViewById<EditText>(Resource.Id.txtxLName);
                    lname.Text = "";
                    var age = FindViewById<EditText>(Resource.Id.txtAge);
                    age.Text = "";
                    var address = FindViewById<EditText>(Resource.Id.txtAddress);
                    address.Text = "";
                    var mother = FindViewById<EditText>(Resource.Id.txtMotherN);
                    mother.Text = "";
                    var father = FindViewById<EditText>(Resource.Id.txtFatherN);
                    father.Text = "";

                });

                dialog.Show();
            }
            catch(Exception)
            {
                Toast.MakeText(this, "Please verify Informatio: example Age", ToastLength.Long).Show();
            }
                
                

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}