using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace rivER
{
	public class PersonnelViewModel : BaseViewModel
	{
		Personnel personnel;
		readonly IRivERWebService rivERWebService;
		readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		ObservableCollection<Request> requests;

		public ObservableCollection<Request> Requests { get { return requests; } }

		public PersonnelViewModel(INavigation navigation) : base(navigation)
		{
			rivERWebService = new RivERWebService();
			personnel = new Personnel();
			requests = new ObservableCollection<Request>();

			Commands.Add("AcknowledgeCommand", new Command<Request>(OnAcknowledgeCommand));

			GetPersonnelVacantAsync();
		}

		void OnAcknowledgeCommand(Request request)
		{
			request.State = true;

			rivERWebService.PostPersonnelAcknowledgeRequest(request.RequestID, Helpers.Settings.PersonnelID);
		}

		async void GetPersonnelVacantAsync()
		{
			var token = cancellationTokenSource.Token;

			try
			{
				await Task.Factory.StartNew(async () =>
				{
					while (true)
					{
						personnel = rivERWebService.GetPersonnelReadRequest(Helpers.Settings.PersonnelID).Result;

						foreach (var request in personnel.Requests)
						{
							if (!Requests.Any(r => r.RequestID == request.RequestID))
							{
								Requests.Add(request);
							}
                            Requests.Where(r => r.RequestID == request.RequestID)
                                .Select(r => { r.Alarm = request.Alarm; return r; });
						}

						await Task.Delay(3000);

						if (token.IsCancellationRequested)
							break;
					}
				}, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			catch (OperationCanceledException e)
			{
				System.Diagnostics.Debug.WriteLine("Cancel GetPersonnelVacantAsync ex {0}", e.Message);
			}
		}
	}
}

