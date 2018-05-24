using System;

using AppKit;
using FFImageLoading;
using Foundation;

namespace tes
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           //Set directly from resource is working
            var imageView = new NSImageView
            {
                Frame = this.View.Bounds,
                Image=NSImage.ImageNamed("food.jpg")
            };
            this.View.AddSubview(imageView);
            //Using Image Service is not working to load pictures into NSImageView
            ImageService.Instance.LoadUrl("https://blog.traveloka.com/wp-content/uploads/2017/09/kampung_warna_warni_jodipan_malang_bs1.jpg").LoadingPlaceholder("food.jpg",FFImageLoading.Work.ImageSource.ApplicationBundle).Into(imageView);

            //Set directly from url is working
            //var imageView = new NSImageView
            //{
            //    Frame = this.View.Bounds,
            //    Image = new NSImage(new NSUrl("https://blog.traveloka.com/wp-content/uploads/2017/09/kampung_warna_warni_jodipan_malang_bs1.jpg"))
            //};
            //this.View.AddSubview(imageView);
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
