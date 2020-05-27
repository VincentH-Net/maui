using System.Maui;
using vm = PagesGallery.Markup.LiveStreamSampleViewModel;

namespace PagesGallery.Markup
{
	public partial class LiveStreamSamplePageForms : ContentPage
	{
		public LiveStreamSamplePageForms(vm vm)
		{
			BindingContext = vm;
			Build();
		}
	}
}
