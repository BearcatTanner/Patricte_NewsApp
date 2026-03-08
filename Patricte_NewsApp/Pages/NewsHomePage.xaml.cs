using Patricte_NewsApp.Models;


namespace Patricte_NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
    public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
        GetBreakingNews();
        ArticleList = new List<Article>();
        CVCategories.ItemsSource = CategoryList;

	}

    private async Task GetBreakingNews()
    {
        var apiService = new Services.ApiServices();
        var newsresult = await apiService.GetNews("general");
        foreach (var item in newsresult.Articles)
        {
            ArticleList.Add(item);
        }
        CVNews.ItemsSource = ArticleList;
    }
    private void CVCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;
        if (selectedCategory == null) return;
        #if WINDOWS
        // Force WinUI to clear the selected container
        if (CVNews.Handler?.PlatformView is Microsoft.UI.Xaml.Controls.ListViewBase lv)
            lv.SelectedIndex = -1;
        #endif

        Navigation.PushAsync(new NewsListPage(selectedCategory.Name));
        ((CollectionView)sender).SelectedItem = null;
    }
    private void CVNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        var selectedArticle = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedArticle == null) return;
#if WINDOWS
        // Force WinUI to clear the selected container
        if (CVNews.Handler?.PlatformView is Microsoft.UI.Xaml.Controls.ListViewBase lv)
            lv.SelectedIndex = -1;
#endif

        Navigation.PushAsync(new NewsDetailsPage(selectedArticle));
        ((CollectionView)sender).SelectedItem = null;
    }

   
}