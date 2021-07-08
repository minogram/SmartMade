﻿using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using OfficeOpenXml;
using ReactiveUI;

namespace EPPlueSample
{
    public class MainViewModel : ReactiveObject
    {
        public ObservableCollection<SimItem> Items { get; } = new();
        public ObservableCollection<string> Workers { get; } = new();
        public ObservableCollection<string> Equipments { get; } = new();

        public ICommand OpenCommand { get; }

        public MainViewModel()
        {
            OpenCommand = ReactiveCommand.Create(Open);
        }

        private void Open()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var fileInfo = new FileInfo(dialog.FileName);
                using var package = new ExcelPackage(fileInfo);
                var sheet = package.Workbook.Worksheets["작업지시서"];

                int row = 7;
                while (sheet.Cells[row, 1].Value != null)
                {
                    var col = 1;
                    var item = new SimItem();
                    item.WorkerName = sheet.Cells[row, col++].GetValue<string>();
                    item.WorkerID = sheet.Cells[row, col++].GetValue<string>();
                    item.OrderID = sheet.Cells[row, col++].GetValue<string>();
                    item.OrderName = sheet.Cells[row, col++].GetValue<string>();
                    item.ItemID = sheet.Cells[row, col++].GetValue<string>();
                    item.ItemName = sheet.Cells[row, col++].GetValue<string>();
                    item.ProcessID = sheet.Cells[row, col++].GetValue<string>();
                    item.ProcessName = sheet.Cells[row, col++].GetValue<string>();
                    item.StartTime = sheet.Cells[row, col++].GetValue<string>();
                    item.EndTime = sheet.Cells[row, col++].GetValue<string>();
                    item.EquipmentID = sheet.Cells[row, col++].GetValue<string>();
                    item.EquipmentName = sheet.Cells[row, col++].GetValue<string>();
                    item.ProcessKind = sheet.Cells[row, col++].GetValue<string>();
                    item.DivideKind = sheet.Cells[row, col++].GetValue<string>();
                    item.Remark = sheet.Cells[row, col++].GetValue<string>();
                    Items.Add(item);
                    row++;
                }

                Workers.Clear();
                Equipments.Clear();
                Items.Select(i => i.WorkerName).Distinct().ToList().ForEach(i => Workers.Add(i));
                Items.Select(i => i.EquipmentName).Distinct().ToList().ForEach(i => Equipments.Add(i));
            }
        }
    }
}
