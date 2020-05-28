using System.Maui.Markup;
using System.Maui.Markup.LeftToRight;
using static System.Maui.Color;
using static PagesGallery.Markup.Factory;
using vm = PagesGallery.Markup.LiveStreamSampleViewModel;

namespace PagesGallery.Markup
{
	public partial class LiveStreamSamplePageMauiMvvm
	{
		void Build() => Content = VStack (
			Spacer (),

			Label () .Bind (nameof(vm.Message))
					 .Color (White, "#7258F6") .Font (64, "DIN Alternate") .LinesWordWrap ()
					 .Margin (left: 25, right: 25) .FillHorizontal () .TextLeft (),

			Button ("Increment") .Bind (nameof(vm.IncrementCommand))
				   .Color (White) .Font (32)
				   .RoundedBorder (radius: 20, color: Transparent) .Shadow ()
				   .Margin (30) .FillHorizontal () .Frame (height: 76),

			Button ("Decrement") .Bind (nameof(vm.DecrementCommand)),

			Spacer ()
		);
	}
}
