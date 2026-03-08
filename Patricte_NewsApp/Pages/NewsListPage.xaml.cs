using Patricte_NewsApp.Models;

namespace Patricte_NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    public List<Article> CatArticleList;

    public NewsListPage(string cat)
	{
		InitializeComponent();
       LblTitle.Text = cat;
        GetNews(cat);
        CatArticleList = new List<Article>();
    }

    private async Task GetNews(string category)
    {
        string apicat = "category=" + category;
        var apiService = new Services.ApiServices();
        var newsresult = await apiService.GetNews(apicat);
        CatArticleList.Clear();
        foreach (var item in newsresult.Articles)
        {
            CatArticleList.Add(item);
        }
        CVNews.ItemsSource = CatArticleList;
    }

    private void CVNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}