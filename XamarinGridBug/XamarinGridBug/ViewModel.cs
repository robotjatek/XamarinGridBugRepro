using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace XamarinGridBug
{
    public class Model
    {
        public string TextString { get; set; }

        public int Row { get; set; }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> ModelList { get; } = new ObservableCollection<Model>();

        public ViewModel()
        {
            AddModelCommand = new Command<Model>((Model toadd) =>
            {
                this.ModelList.Add(toadd);
            });

            RemoveModelCommand = new Command<Model>((Model toRemove) =>
            {
                this.ModelList.Remove(toRemove);
            });

            RemoveLastCommand = new Command(() =>
            {
                var toRemove = this.ModelList.Last();
                this.ModelList.Remove(toRemove);
            });

            var models = new Model[]
            {
                new Model
                {
                    TextString = "1",
                    Row = 0
                },
                new Model
                {
                    TextString = "2",
                    Row = 1
                },
                new Model
                {
                    TextString = "3",
                    Row = 2
                }
            };

            foreach (var m in models)
            {
                this.ModelList.Add(m);
            }
        }

        public ICommand AddModelCommand { get; private set; }

        public ICommand RemoveModelCommand { get; private set; }

        public ICommand RemoveLastCommand { get; private set; }
    }
}
