using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MVVM_API_SampleProject.ViewModels;
using MVVM_API_SampleProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;
using MVVM_API_SampleProject.Services;

namespace MVVM_API_SampleProject.ViewModels
{
    //Herdando ObservableObject do Community Toolkit Mvvm
    internal partial class PostViewModel : ObservableObject, IDisposable
    {
        private readonly PostService _postService;

        [ObservableProperty]
        public int _UserId;
        [ObservableProperty]
        public int _Id;
        [ObservableProperty]
        public string _Title;
        [ObservableProperty]
        public string _Body;
        //Uma coleção de Post
        [ObservableProperty]
        public ObservableCollection<Post> _posts;

        public PostViewModel()
        {
           
            Posts = new ObservableCollection<Post>();
            _postService = new PostService();
        }

        //Consumir a API Rest -> Criação de Commands

        public ICommand GetPostsCommand => new Command(async () => await LoadPostAsync());

        private async Task LoadPostAsync()
        {
            Posts = await _postService.GetPostsAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}