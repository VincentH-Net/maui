using System.ComponentModel;
using System.Maui;
using System.Windows.Input;

namespace PagesGallery.Markup
{
	public class LiveStreamSampleViewModel : INotifyPropertyChanged
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
}
