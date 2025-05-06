namespace MauiAppLog;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	
	private void Button_Clicked(object sender, EventArgs e)
	{
		try
		{

			List<DadosUsuarios> lista_usuarios = new List<DadosUsuarios>()
			{
				new DadosUsuarios()
				{
					Usuario = "Maryana",
					Senha = "Atena2712",
				},

				new DadosUsuarios()
				{
					Usuario = "Douglas",
					Senha = "Nina123",
				},

				new DadosUsuarios()
				{
					Usuario = "Eduardo",
					Senha = "Senha"

				}

			};

			DadosUsuarios dados_digitados = new DadosUsuarios()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			//LINQ

			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))//Verifica se o usuario e a senha são iguais
                                                                                                                    //aos dados que estão armazenados no "banco de dados"
            {
                SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Behind();
			}
			else
			{
				throw new Exception("Usuário ou senha incorreto.");
			}
			
		}catch(Exception ex) {

			DisplayAlert("OPS!", ex.Message, "Fechar");

		}
	}
}