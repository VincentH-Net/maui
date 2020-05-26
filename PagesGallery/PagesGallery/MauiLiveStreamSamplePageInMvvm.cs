using System.ComponentModel;
using System.Maui;
using System.Maui.Markup;
using System.Maui.Markup.LeftToRight;
using System.Windows.Input;
using static PagesGallery.Factory;
using static System.Maui.Color;
using vm = PagesGallery.MauiLiveStreamSampleViewModel;

namespace PagesGallery
{
	public class MauiLiveStreamSamplePageInMvvm : ContentPage
	{
		public MauiLiveStreamSamplePageInMvvm(vm vm)
		{
			BindingContext = vm;
			Build();
		}

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

	public class MauiLiveStreamSampleViewModel : INotifyPropertyChanged
	{
		ICommand incrementCommand, decrementCommand;

		public string Message => $"I will run {Count} miles this month.";
		public int Count { get; set; }
		public ICommand IncrementCommand => incrementCommand ??= new Command(() => Increment());
		public ICommand DecrementCommand => decrementCommand ??= new Command(() => Decrement());

		void Increment() => Count++;
		void Decrement() => Count--;

		public event PropertyChangedEventHandler PropertyChanged;
			// Let's pretend PropertyChanged.Fody is used to generate IL to raise direct and calculated property changes
	}

	public static class Factory
	{
		public static Label Label(string text = null) => new Label { Text = text };
		public static Spacer Spacer() => new Spacer();
		public static Button Button(string text = null ) => new Button { Text = text };
		public static VStack VStack(params View[] children)
		{
			var stack = new VStack();
			foreach (var child in children) stack.Children.Add(child);
			return stack;
		}
	}

	public static class MarkupExtensions
	{
		public static T Color<T>(this T view, Color color, string background) where T : Label { view.TextColor = color; view.BackgroundColor = System.Maui.Color.FromHex(background); return view; }
		public static T Color<T>(this T view, Color color) where T : Button { view.TextColor = color; return view; }

		public static T LinesWordWrap<T>(this T view) where T : Label { view.LineBreakMode = System.Maui.LineBreakMode.WordWrap; return view; }
		public static T Margin<T>(this T view, double left = 0, double top = 0, double right = 0, double bottom = 0) where T : View { view.Margin = new Thickness(left, top, right, bottom); return view; }

		// No implemented here, will work in Core project due to FontElement being internal
		public static T Font<T>(this T view, float size, string family = null) // where T : IFontElement 
		{
			//view.SetValue(FontElement.FontSizeProperty, size.Value); 
			//view.SetValue(FontElement.FontFamilyProperty, family); 
			return view;
		}

		// Afaik no direct equivalent of these comet repo helpers exist in the dotnet/maui repo:
		public static T RoundedBorder<T>(this T view, double radius, Color color) where T : View { return view; }
		public static T Shadow<T>(this T view) where T : View { return view; }
		public static T Frame<T>(this T view, double height) where T : View { return view; }
	}

	public class VStack : StackLayout { public VStack() : { Orientation = StackOrientation.Vertical; } }

	public class Spacer : ContentView { public Spacer() { WidthRequest = HeightRequest = 6; } }
}
