using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlertDialog = Android.App.AlertDialog;

namespace Exercise4
{
    [Activity(Label = "ConsentForm")]
    public class ConsentForm : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
           String fullName= Class1.fname + " " + Class1.mname + ". " + Class1.lname;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ConsentForm);

            String p1 = "   I, " + fullName + ", hereby provide my consent to participate in the ICT Congress scheduled to take place on March 25, 2023. \n\n";
            String p2 = "   I am fully aware that by participating in this Congress, I may be exposed to new and complex information," +
                        "and I may be required to interact with other participants, presenters, and sponsors.\n\n";
            String p4 = "   I acknowledge that my personal information, including address: "+Class1.address+" , and parents' names: "+Class1.mothersname+" & "+Class1.fathersname +" , may be collected and used for the purposes of organizing and conducting the Congress, " +
                        "including but not limited to registration, security, and identification.\n\n";
            String p5 = "   I affirm that I am "+ Class1.age +" years old, " +
                         "and that I have the legal capacity to provide my consent for my participation in this Congress.\n\n";
            String p6 = "    By signing this consent form, I acknowledge that I have read and fully understood the terms and conditions of this consent form, " +
                        "and I freely and voluntarily provide my consent to participate in the ICT Congress.\n";

            TextView consent = FindViewById<MultiAutoCompleteTextView>(Resource.Id.multiAutoCompleteTextView1);
            consent.Text = p1 + p2 + p4 + p5 + p6;

            TextView pname = FindViewById<TextView>(Resource.Id.txtPname);
            pname.Text = Class1.fname + " " + Class1.mname + ". " + Class1.lname;
            TextView _date = FindViewById<TextView>(Resource.Id.txtDateTime);
            _date.Text = DateTime.Now.ToString();

            var btnback = FindViewById<Button>(Resource.Id.btnconfirm);

            btnback.Click += delegate
            {
                AlertDialog.Builder dia = new AlertDialog.Builder(this);
                dia.SetTitle("Ok");
                dia.SetMessage("Confirmation Submit");
                dia.SetPositiveButton("Ok", (sender, args) =>
                {
                    var iback = new Intent(this, typeof(MainActivity));
                    StartActivity(iback);
                    Toast.MakeText(this, "Going back to Form", ToastLength.Long);

                });
                dia.SetNegativeButton("Cancel", (sender, args) =>
                {
                    dia.Dispose();

                });
                Dialog dia2 = dia.Create();
                dia2.Show();
            };
        }
    }
    }