using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MyCompanyInThePocket.Core.Services.Interface;

namespace MyCompanyInThePocket.Droid.Services
{
    public class AndroidMessageService : IMessageService
    {
        public Task ShowErrorToastAsync(Exception exception, string message)
        {
            var context = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            var toast = Toast.MakeText(context,
                message
#if DEBUG
                     + ": " + exception.Message
#endif

                , Snackbar.LengthLong);
            toast.SetGravity(GravityFlags.Top | GravityFlags.CenterHorizontal, 0, 0);
            toast.Show();

            return Task.FromResult(true);
        }
    }
}