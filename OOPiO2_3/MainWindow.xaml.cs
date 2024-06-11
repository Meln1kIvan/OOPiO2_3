using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MyLib;

namespace OOPiO2_3
{
    public partial class MainWindow : Window
    {
        private MyCollection<int> collection;

        public MainWindow()
        {
            InitializeComponent();
            collection = new MyCollection<int>();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(ValueTextBox.Text, out value))
            {
                collection.Add(value);
                ValueTextBox.Clear();
                DisplayCollection();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter an integer value.");
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            collection.MergeSort();
            DisplayCollection();
        }

        private void DisplayCollection()
        {
            CollectionItemsTextBox.Text = string.Join(", ", collection);
        }

    }
}