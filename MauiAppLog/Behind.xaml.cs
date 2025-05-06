using System.Threading.Tasks;

namespace MauiAppLog;

public partial class Behind : ContentPage
{
	public Behind()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            bemvindo.Text = $"Bem vindo (a) {usuario_logado}";//Interpolação de String(ESTUDAR!!!)
		});
	}

    private async void Clicked(object sender, EventArgs e)
    {
		bool confirma = await DisplayAlert("Tem certeza?", "Sair do APP", "Sim", "Não");

		if (confirma) 
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
		}
    }
}