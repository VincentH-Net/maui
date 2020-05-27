using System.Maui;
using vm = PagesGallery.Markup.LiveStreamSampleViewModel;

namespace PagesGallery.Markup
{
	public partial class LiveStreamSamplePageMauiMvvm : ContentPage
	{
		public LiveStreamSamplePageMauiMvvm(vm vm)
		{
			BindingContext = vm;
			Build();
		}
	}
}
