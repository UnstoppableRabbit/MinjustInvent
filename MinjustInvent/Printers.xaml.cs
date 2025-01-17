﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MinjustInvent
{
    /// <summary>
    /// Логика взаимодействия для Printers.xaml
    /// </summary>
    public partial class Printers : Window
    {
        private List<PrinterOrder> dataSource;
        private List<PrinterOrder> beforeOrders;
        public Printers()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены что хотите сохранить изменения?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    using (minjustDBEntities minjustDb = new minjustDBEntities())
                    {
                        var itemsForDelete = beforeOrders.Where(_ => !dataSource.Any(x => x.Id == _.Id)).Select(_ => _.Id).ToList();
                        if (itemsForDelete.Count > 0)
                            minjustDb.PrinterOrder.RemoveRange(minjustDb.PrinterOrder.Where(_ => itemsForDelete.Contains(_.Id)));
                    
                        var itemsForUpdate = dataSource.Where(_ => _.Id != Guid.Empty && !_.DBEquals(beforeOrders.FirstOrDefault(x => x.Id == _.Id))).ToList();
                        if (itemsForUpdate.Count > 0)
                        {
                            var itemsForUpdateIds = itemsForUpdate.Select(_ => _.Id).ToList();
                            var itemsForUpdateFromDb = minjustDb.PrinterOrder.Where(_ => itemsForUpdateIds.Contains(_.Id)).ToList();
                            foreach (var item in itemsForUpdateFromDb)
                            {
                                var s = itemsForUpdate.First(_ => _.Id == item.Id);
                                item.InventNumber = s.InventNumber;
                                item.Name = s.Name;
                                item.IP = s.IP;
                                item.CabinetNum = s.CabinetNum;
                                item.Cartridge = s.Cartridge;
                            }
                        }

                        var itemsForAdd = dataSource.Where(_ => _.Id == Guid.Empty).ToList();
                        if (itemsForAdd.Count > 0)
                        {
                            foreach (var i in itemsForAdd)
                                i.Id = Guid.NewGuid();
                            minjustDb.PrinterOrder.AddRange(itemsForAdd);
                        }
                        minjustDb.SaveChanges();
                        phonesGrid_Loaded(null, null);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "При выполнении произошла ошибка", MessageBoxButton.OK);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (printersGrid.SelectedIndex >= dataSource.Count)
                return;
            dataSource.RemoveAt(printersGrid.SelectedIndex);
            printersGrid.ItemsSource = null;
            printersGrid.ItemsSource = dataSource;
        }

        private void phonesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (minjustDBEntities minjustDb = new minjustDBEntities())
                printersGrid.ItemsSource = dataSource = minjustDb.PrinterOrder.OrderBy(_ => _.CabinetNum).ToList();
            beforeOrders = new List<PrinterOrder>();

            foreach (var d in dataSource)
                beforeOrders.Add(new PrinterOrder
                {
                    Id = d.Id,
                    IP = d.IP,
                    CabinetNum = d.CabinetNum,
                    Cartridge = d.Cartridge,
                    InventNumber = d.InventNumber,
                    Name = d.Name
                });
        }
    }
}
