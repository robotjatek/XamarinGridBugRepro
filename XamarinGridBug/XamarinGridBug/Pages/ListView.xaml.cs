
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinGridBug
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage
    {
        public ListView()
        {
            InitializeComponent();
        }
    }
}
