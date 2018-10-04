using System.Collections.Generic;
using ClosedXML.Excel;

namespace ExcelTask
{
    public class DataExport
    {
        public static void Main(string[] args)
        {
            var data = new List<Person>
            {
                new Person("Александр", "Даргеев", 37, "+7-913-919-0434"),
                new Person("Вася", "Пупкин", 2, "нокиа 3310"),
                new Person("Князь", "Мышкин", 23, "03")
            };

            using (var excelFile = new XLWorkbook())
            {
                var sheet = excelFile.Worksheets.Add("Persons");
                sheet.Cell(1, 1).Value = "Имя";
                sheet.Cell(1, 1).Style.Font.Bold = true;
                sheet.Cell(1, 2).Value = "Фамилия";
                sheet.Cell(1, 2).Style.Font.Bold = true;
                sheet.Cell(1, 3).Value = "Возраст";
                sheet.Cell(1, 3).Style.Font.Bold = true;
                sheet.Cell(1, 4).Value = "Телефон";
                sheet.Cell(1, 4).Style.Font.Bold = true;

                var row = 2;

                foreach (var person in data)
                {
                    sheet.Cell(row, 1).Value = person.FirstName;
                    sheet.Cell(row, 2).Value = person.LastName;
                    sheet.Cell(row, 3).Value = person.Age;
                    sheet.Cell(row, 4).Value = person.Phone;

                    ++row;
                }

                var table = sheet.Range(1, 1, row - 1, 4);
                table.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                table.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                table.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                sheet.Columns().AdjustToContents();

                excelFile.SaveAs("PersonList.xlsx");
            }
        }
    }
}
