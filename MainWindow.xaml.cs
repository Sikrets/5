using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using AsyncLibraryApp.Models;

namespace AsyncLibraryApp
{
    public partial class MainWindow : Window
    {
        private List<Author> _authors = new();
        private bool _loading = false;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new LibraryContext();
                await db.Database.EnsureCreatedAsync();

                _authors = await db.Authors.OrderBy(a => a.FullName).ToListAsync();

                CmbAuthors.ItemsSource = _authors;
                CmbAuthors.DisplayMemberPath = "FullName";
                CmbAuthors.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading authors: " + ex.Message);
            }
        }

        private async void CmbAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_loading) return;
            if (CmbAuthors.SelectedItem is not Author selectedAuthor) return;
            await LoadBooksAsync(selectedAuthor.Id);
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_loading) return;

            string search = TxtSearch.Text.Trim();
            if (search.Length > 0 && search.Length < 3) return;
            if (CmbAuthors.SelectedItem is not Author selectedAuthor) return;

            await LoadBooksAsync(selectedAuthor.Id, search);
        }

        private async System.Threading.Tasks.Task LoadBooksAsync(int authorId, string? search = null)
        {
            try
            {
                using var db = new LibraryContext();

                IQueryable<Book> query = db.Books.Where(b => b.AuthorId == authorId);

                if (!string.IsNullOrWhiteSpace(search) && search.Length >= 3)
                    query = query.Where(b => EF.Functions.Like(b.Title, $"%{search}%"));

                var books = await query.OrderBy(b => b.Year).ToListAsync();
                DgBooks.ItemsSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }
    }
}
