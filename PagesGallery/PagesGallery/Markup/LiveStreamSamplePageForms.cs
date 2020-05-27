using System.Maui;
using System.Maui.Markup;
using System.Maui.Markup.LeftToRight;
using static System.Maui.Color;
using vm = PagesGallery.Markup.LiveStreamSampleViewModel;

namespace PagesGallery.Markup
{
	public partial class LiveStreamSamplePageForms
	{
		void Build() => Content = 
			new StackLayout { Orientation = StackOrientation.Horizontal, Children = {
					new ContentView { } .Size (6),

					new Label { }
							   .Color (White, "#7258F6") .Font (64, "DIN Alternate") .LinesWordWrap ()
							   .Margin (left: 25, right: 25) .FillHorizontal () .TextLeft ()
							   .Bind (nameof(vm.Message)),

					new Button { Text = "Increment" }
								.Color (White) .Font (32)
								.RoundedBorder (radius: 20, color: Transparent) .Shadow ()
								.Margin (30) .FillHorizontal () .Frame (height: 76)
								.Bind (nameof(vm.IncrementCommand)),

					new Button { Text = "Decrement" }
								.Bind (nameof(vm.DecrementCommand)),

					new ContentView { } .Size (6),
				}
			};
	}
}
