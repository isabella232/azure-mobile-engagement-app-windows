using System;
using Azme.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Azme.Pages
{
  public sealed partial class WebViewPage : Page
  {
    public WebViewPage()
    {
      this.InitializeComponent();
    }

 
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      ComputeWebView(e.Parameter as string);
    }

    private void ComputeWebView(string url)
    {
      Uri feedUri = new Uri(url, UriKind.Absolute);
      Webview.Navigate(feedUri);
    }
  }
 
}
