using Patricte_NewsApp.Models;

namespace Patricte_NewsApp.Pages;

public partial class NewsDetailsPage : ContentPage
{
	public NewsDetailsPage(Article art)
	{
		InitializeComponent();
		Img.Source = art.Image;
		LblTitle.Text = art.Title;
		LblContent.Text = art.Content;

	}
}