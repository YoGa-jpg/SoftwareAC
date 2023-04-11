using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AAS.Models;
using AAS_Web.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Formatting = Xceed.Document.NET.Formatting;

namespace AAS.View
{
    /// <summary>
    /// Interaction logic for GetRecordsWindow.xaml
    /// </summary>
    public partial class GetRecordsWindow : Window
    {
        #region Reports

        private List<Report> reports = new List<Report>()
        {
            new Report()
            {
                ReportId = 1,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не работает VS",
                Status = new Status()
                {
                    Name = "Выполнено",
                    StatusId = 1
                },
                Program = new Program()
                {
                    ProgramName = "Visual Studio 2022"
                }
            },
            new Report()
            {
                ReportId = 2,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не запускается VS",
                Status = new Status()
                {
                    Name = "Не рассмотрено",
                    StatusId = 3
                },
                Program = new Program()
                {
                    ProgramName = "Visual Studio 2022"
                }
            },
            new Report()
            {
                ReportId = 3,
                ComputerId = 3,
                ProgramId = 3,
                ReportDate = DateTime.Parse("09.04.2023"),
                ReportTheme = "Не закрывается VS",
                Status = new Status()
                {
                    Name = "Не рассмотрено",
                    StatusId = 3
                },
                Program = new Program()
                {
                    ProgramName = "Visual Studio 2022"
                }
            }
        };

        #endregion

        #region Programs

        private List<Program> programs = new
            List<Program>()
            {
                new Program()
                {
                    ProgramId = 1,
                    ProgramName = "Adobe Photoshop",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 1,
                        TypeName = "Graphics"
                    }
                },
                new Program()
                {
                    ProgramId = 2,
                    ProgramName = "Visual Studio 2022",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 2,
                        TypeName = "IDE"
                    }
                },
                new Program()
                {
                    ProgramId = 3,
                    ProgramName = "VS Code",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 3,
                        TypeName = "Code Editor"
                    }
                },
                new Program()
                {
                    ProgramId = 2,
                    ProgramName = "Jetbrains Rider",
                    Type = new AAS_Web.Models.Type()
                    {
                        TypeId = 2,
                        TypeName = "IDE"
                    }
                },
            };

        #endregion

        #region Computers

        private List<Computer> computers = new
            List<Computer>()
            {
                new Computer()
                {
                    ComputerId = 1,
                    Worker = new Worker()
                    {
                        Fullname = "Иноземцев Герман Александрович",
                        Position = new Position()
                        {
                            PositionName = "Системный администратор"
                        }
                    }
                },
                new Computer()
                {
                    ComputerId = 2,
                    Worker = new Worker()
                    {
                        Fullname = "Алиев Эмиль Мусаевич",
                        Position = new Position()
                        {
                            PositionName = "Вахтерша"
                        }
                    }
                },
                new Computer()
                {
                    ComputerId = 3,
                    Worker = new Worker()
                    {
                        Fullname = "Давидович Антон Александрович",
                        Position = new Position()
                        {
                            PositionName = "Разработчик"
                        }
                    }
                },
                new Computer()
                {
                    ComputerId = 4,
                    Worker = new Worker()
                    {
                        Fullname = "Шабельянов Андрей Юрьевич",
                        Position = new Position()
                        {
                            PositionName = "Сталелитейник"
                        }
                    }
                }
            };

        #endregion

        #region Softwares

        private List<Software> software = new
            List<Software>()
            {
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 1,
                        ProgramName = "Adobe Photoshop",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 1,
                            TypeName = "Graphics"
                        }
                    },
                    Version = "Enterprise",
                    ProgramType = "Graphics"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 2,
                        ProgramName = "Visual Studio 2022",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 2,
                            TypeName = "IDE"
                        }
                    },
                    Version = "Community",
                    ProgramType = "IDE"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2099"),
                    Program = new Program()
                    {
                        ProgramId = 3,
                        ProgramName = "VS Code",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 3,
                            TypeName = "Code Editor"
                        }
                    },
                    Version = "Community",
                    ProgramType = "IDE"
                },
                new Software()
                {
                    Computer = new Computer()
                    {
                        ComputerId = 3,
                        Worker = new Worker()
                        {
                            Fullname = "Давидович Антон Александрович",
                            WorkerId = 1
                        }
                    },
                    ComputerId = 3,
                    LicenseStart = DateTime.Parse("01.01.2023"),
                    LicenseEnd = DateTime.Parse("01.06.2023"),
                    Program = new Program()
                    {
                        ProgramId = 2,
                        ProgramName = "Jetbrains Rider",
                        Type = new AAS_Web.Models.Type()
                        {
                            TypeId = 2,
                            TypeName = "IDE"
                        }
                    },
                    Version = "Enterprise",
                    ProgramType = "IDE"
                }
            };

        #endregion
        ConfigInfo config = new ConfigInfo(true);
        public GetRecordsWindow()
        {
            InitializeComponent();
        }

        private void Report_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime re;
            var menu = int.Parse((string) ((TypeBox.SelectedItem as ComboBoxItem)?.Tag ?? "10"));
            if(DateTime.TryParse(FirstDate.Text, out re) & DateTime.TryParse(SecondDate.Text, out re))
            {
                if(DateTime.Parse(SecondDate.Text) > DateTime.Parse(FirstDate.Text))
                {
                    switch (menu)
                    {
                        case 1:
                            if (FirstDate.Text != string.Empty & SecondDate.Text != string.Empty)
                                SoftwareOperability(Convert.ToDateTime(FirstDate.Text),
                                    Convert.ToDateTime(SecondDate.Text));
                            break;
                        case 2:
                            if (FirstDate.Text != string.Empty & SecondDate.Text != string.Empty)
                                ReportsStats(Convert.ToDateTime(FirstDate.Text), Convert.ToDateTime(SecondDate.Text));
                            break;
                        case 3:
                            SoftInfoReport();
                            break;
                        default:
                            MessageBox.Show("Выберите пункт", "Отчет", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
        }

        public void SoftInfoReport()
        {
            var doc = DocX.Create($@"{config.path}ОтчетПО.docx");

            //var Programs = JsonConvert.DeserializeObject<List<Program>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());

            //var Computers = JsonConvert.DeserializeObject<List<Computer>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputers", "POST", "").ToString());

            var Programs = programs;
            var Computers = computers;

            var titleFormat = new Formatting()
            {
                Size = 20,
                FontFamily = new Font("Times New Roman"),
                Bold = true
            };
            var textFormat = new Formatting()
            {
                Size = 12,
                FontFamily = new Font("Times New Roman")
            };

            var table_1 = doc.AddTable(1, 2);
            table_1.Design = TableDesign.MediumShading1Accent1;
            table_1.Alignment = Alignment.center;
            table_1.Rows[0].Cells[0].Paragraphs[0].Append("Название программного обеспечения", textFormat);
            table_1.Rows[0].Cells[1].Paragraphs[0].Append("Кол-во установок", textFormat);
            foreach (var program in Programs)
            {
                var r = table_1.InsertRow();
                r.Cells[0].Paragraphs[0].Append(program.ProgramName, textFormat);
                r.Cells[1].Paragraphs[0].Append(program.Softwares.Count.ToString(), textFormat);
            }

            var table_2 = doc.AddTable(1, 4);
            table_2.Design = TableDesign.MediumShading1Accent1;
            table_2.Alignment = Alignment.center;
            table_2.Rows[0].Cells[0].Paragraphs[0].Append("Номер компьютера", textFormat);
            table_2.Rows[0].Cells[1].Paragraphs[0].Append("Владелец компьютера", textFormat);
            table_2.Rows[0].Cells[2].Paragraphs[0].Append("Должность владельца", textFormat);
            table_2.Rows[0].Cells[3].Paragraphs[0].Append("Предустановленное ПО", textFormat);
            foreach (var comp in Computers)
            {
                var r = table_2.InsertRow();
                r.Cells[0].Paragraphs[0].Append(comp.ComputerId.ToString(), textFormat);
                r.Cells[1].Paragraphs[0].Append(comp.WorkerName, textFormat);
                r.Cells[2].Paragraphs[0].Append(comp.WorkerPosition, textFormat);
                if(comp.Softwares.Count > 0)
                    r.Cells[3].Paragraphs[0].Append(comp.Softwares?.Select(q => q.ProgramName)?.Aggregate((x, y) => x + "\n" + y), textFormat);
            }

            var par1 = doc.InsertParagraph("Отчет о программном обеспечении", false, titleFormat);
                par1.Alignment = Alignment.center;
                par1.SpacingAfter(20);
            var par2 = doc.InsertParagraph(
                    "\tДанный отчет носит информацию о всем программном обеспечении на компьютерах предприятия", false,
                    textFormat);
                par2.Alignment = Alignment.both;
            var par3 = doc.InsertParagraph(
                    $"\tВсего на предприятии зарегестрировано {Computers.Count} компьютеров и {Programs.Count} видов программного обеспечения для предустановки",
                    false, textFormat);
                par3.Alignment = Alignment.both;
            var par4 = doc.InsertParagraph("\tСписок ПО для предустановки:", false, textFormat);
                par4.Alignment = Alignment.both;
                par4.InsertTableAfterSelf(table_1);
                par4.SpacingAfter(10);
            var par5 = doc.InsertParagraph(
                    "\tДалее в таблице представлена информация о компьютерах, закрепленных за ними работниках, а также предустановленном программном обеспечении.",
                    false, textFormat);
                par5.Alignment = Alignment.both;
                par5.SpacingBefore(10);
                par5.SpacingAfter(10);
                par5.InsertTableAfterSelf(table_2);
            var par6 = doc.InsertParagraph($"Отчет за {DateTime.Now.ToShortDateString()}", false, textFormat);
                par6.Alignment = Alignment.right;
                par6.SpacingBefore(40);

            doc.Save();

            Process.Start("WINWORD.EXE", $@"{config.path}ОтчетПО.docx");
        }

        public void ReportsStats(DateTime startDate, DateTime endDate)
        {
            var doc = DocX.Create($@"{config.path}ОтчетЖалобы.docx");

            //var Reports = JsonConvert.DeserializeObject<List<Report>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
            //var ReportsAccepted = JsonConvert.DeserializeObject<List<Report>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReportsAccepted", "POST", "").ToString());
            //var ReportsNotAccepted = JsonConvert.DeserializeObject<List<Report>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReportsNotAccepted", "POST", "").ToString());
            //var ReportsDenied = JsonConvert.DeserializeObject<List<Report>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReportsDenied", "POST", "").ToString());

            var Reports = reports;
            var ReportsAccepted = reports.Where(q => q.Status.StatusId == 1);
            var ReportsNotAccepted = reports.Where(q => q.Status.StatusId == 2);
            var ReportsDenied = reports.Where(q => q.Status.StatusId == 3);

            var titleFormat = new Formatting()
            {
                Size = 20,
                FontFamily = new Font("Times New Roman"),
                Bold = true
            };
            var textFormat = new Formatting()
            {
                Size = 12,
                FontFamily = new Font("Times New Roman")
            };

            var table_1 = doc.AddTable(1, 5);
            table_1.Design = TableDesign.MediumShading1Accent1;
            table_1.Alignment = Alignment.center;
            table_1.Rows[0].Cells[0].Paragraphs[0].Append("Программа с неполадкой", textFormat);
            table_1.Rows[0].Cells[1].Paragraphs[0].Append("Тема жалобы", textFormat);
            table_1.Rows[0].Cells[2].Paragraphs[0].Append("Описание жалобы", textFormat);
            table_1.Rows[0].Cells[3].Paragraphs[0].Append("Статус жалобы", textFormat);
            table_1.Rows[0].Cells[4].Paragraphs[0].Append("Номер компьютера", textFormat);
            foreach (var report in Reports.Where(q => q.ReportDate > startDate & q.ReportDate < endDate))
            {
                var r = table_1.InsertRow();
                r.Cells[0].Paragraphs[0].Append(report.Program.ProgramName, textFormat);
                r.Cells[1].Paragraphs[0].Append(report.ReportTheme, textFormat);
                r.Cells[2].Paragraphs[0].Append(report.ReportDescription, textFormat);
                r.Cells[3].Paragraphs[0].Append(report.StatusName, textFormat);
                r.Cells[4].Paragraphs[0].Append(report.ComputerId.ToString(), textFormat);
            }

            var par1 = doc.InsertParagraph("Отчет статистики жалоб сотрудников", false, titleFormat);
                par1.Alignment = Alignment.center;
                par1.SpacingAfter(20);
            var par2 = doc.InsertParagraph(
                $"\tДанный отчет носит информацию о поступивших администратору жалобах в период с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}.", false, textFormat);
                par2.Alignment = Alignment.both;
                par2.SpacingAfter(10);
            var par3 = doc.InsertParagraph("\tНиже представлена таблица, содержащая данные жалоб.", false, textFormat);
                par3.Alignment = Alignment.both;
                par3.SpacingAfter(10);
                par3.InsertTableAfterSelf(table_1);
            var par4 = doc.InsertParagraph(
                $"\tИсходя из данных представленных в таблице всего было подано {Reports.Count} жалоб из которых {ReportsAccepted.Count()} отвечены, {ReportsNotAccepted.Count()} еще не рассмотрены и {ReportsDenied.Count()} отклонены. Наибольшее кол-во жалоб исходит с компьютера №{Reports.GroupBy(q => q.ComputerId).OrderBy(q => q.Count()).First().Key}", false, textFormat);
                par4.Alignment = Alignment.both;
            var par5 = doc.InsertParagraph($"Отчет за {DateTime.Now.ToShortDateString()}", false, textFormat);
                par5.Alignment = Alignment.right;
                par5.SpacingBefore(40);

            doc.Save();

            Process.Start("WINWORD.EXE", $@"{config.path}ОтчетЖалобы.docx");
        }

        public void SoftwareOperability(DateTime startDate, DateTime endDate)
        {
            var doc = DocX.Create($@"{config.path}ОтчетРаботыПО.docx");

            //var Reports = JsonConvert.DeserializeObject<List<Report>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetReports", "POST", "").ToString());
            //var Programs = JsonConvert.DeserializeObject<List<Program>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetPrograms", "POST", "").ToString());
            //var Softwares = JsonConvert.DeserializeObject<List<Software>>(
            //    RequestHelper.SendRequest($@"{config.uri}/Home/GetComputersInfo", "POST", "").ToString());

            var Reports = reports;
            var Programs = programs;
            var Softwares = software;

            var titleFormat = new Formatting()
            {
                Size = 20,
                FontFamily = new Font("Times New Roman"),
                Bold = true
            };
            var textFormat = new Formatting()
            {
                Size = 12,
                FontFamily = new Font("Times New Roman")
            };

            var table_1 = doc.AddTable(1, 3);
            table_1.Design = TableDesign.MediumShading1Accent1;
            table_1.Alignment = Alignment.center;
            table_1.Rows[0].Cells[0].Paragraphs[0].Append("Название ПО", textFormat);
            table_1.Rows[0].Cells[1].Paragraphs[0].Append("Тема жалобы", textFormat);
            table_1.Rows[0].Cells[2].Paragraphs[0].Append("Описание жалобы", textFormat);
            foreach (var report in Reports)
            {
                var r = table_1.InsertRow();
                r.Cells[0].Paragraphs[0].Append(report.Program.ProgramName, textFormat);
                r.Cells[1].Paragraphs[0].Append(report.ReportTheme, textFormat);
                r.Cells[2].Paragraphs[0].Append(report.ReportDescription, textFormat);
            }

            var table_2 = doc.AddTable(1, 2);
            table_2.Design = TableDesign.MediumShading1Accent1;
            table_2.Alignment = Alignment.center;
            table_2.Rows[0].Cells[0].Paragraphs[0].Append("Название программы", textFormat);
            table_2.Rows[0].Cells[1].Paragraphs[0].Append("Количество жалоб", textFormat);
            foreach (var program in Programs)
            {
                var r = table_2.InsertRow();
                r.Cells[0].Paragraphs[0].Append(program.ProgramName, textFormat);
                r.Cells[1].Paragraphs[0].Append(program.Reports.Count(q => q.ReportDate > startDate & q.ReportDate < endDate).ToString(), textFormat);
            }

            var table_3 = doc.AddTable(1, 5);
            table_3.Design = TableDesign.MediumShading1Accent1;
            table_3.Alignment = Alignment.center;
            table_3.Rows[0].Cells[0].Paragraphs[0].Append("Компьютер", textFormat);
            table_3.Rows[0].Cells[1].Paragraphs[0].Append("Программа", textFormat);
            table_3.Rows[0].Cells[2].Paragraphs[0].Append("Начало лицензии", textFormat);
            table_3.Rows[0].Cells[3].Paragraphs[0].Append("Конец лицензии", textFormat);
            table_3.Rows[0].Cells[4].Paragraphs[0].Append("Статус лицензии", textFormat);
            foreach (var soft in Softwares)
            {
                var r = table_3.InsertRow();
                r.Cells[0].Paragraphs[0].Append(soft.ComputerId.ToString(), textFormat);
                r.Cells[1].Paragraphs[0].Append(soft.ProgramName, textFormat);
                r.Cells[2].Paragraphs[0].Append(soft.LicenseStart.Value.ToShortDateString(), textFormat);
                r.Cells[3].Paragraphs[0].Append(soft.LicenseEnd.Value.ToShortDateString(), textFormat);
                r.Cells[4].Paragraphs[0].Append(DateTime.Now > soft.LicenseStart.Value & DateTime.Now < soft.LicenseEnd.Value ? "Активная" : "Ожидает продления", textFormat);
            }

            var par1 = doc.InsertParagraph("Отчет о работоспособности ПО", false, titleFormat);
                par1.SpacingAfter(20);
                par1.Alignment = Alignment.center;
            var par2 = doc.InsertParagraph(
                "\tДанный отчет носит информацию о жалобах на работу программного обеспечения и его текущий работоспособности.",
                false, textFormat);
                par2.Alignment = Alignment.both;
            var par3 = doc.InsertParagraph(
                $"\tС {startDate.ToShortDateString()} по {endDate.ToShortDateString()} число поступило {Reports.Count(q => q.ReportDate > startDate & q.ReportDate < endDate).ToString()} жалоб на ПО. Все жалобы за текущий срок представлены в таблице ниже.",
                false, textFormat);
                par3.Alignment = Alignment.both;
                par3.SpacingAfter(10);
                par3.InsertTableAfterSelf(table_1);
            var par4 = doc.InsertParagraph(
                "\tТакже из этой таблицы можно выделить количество жалоб на каждую программу, эта статистика будет представлена в таблице ниже. Программы расположены исходя из количества жалоб (по убыванию).",
                false, textFormat);
                par4.SpacingAfter(10);
                par4.SpacingBefore(10);
                par4.Alignment = Alignment.both;
                par4.InsertTableAfterSelf(table_2);
            var par5 = doc.InsertParagraph(
                "\tТакже в отчете представлена информация о лицензиях на ПО. Данная информация представлена в таблице ниже.",
                false, textFormat);
                par5.Alignment = Alignment.both;
                par5.SpacingAfter(10);
                par5.SpacingBefore(10);
                par5.InsertTableAfterSelf(table_3);

                var par6 = doc.InsertParagraph($"Отчет за {DateTime.Now.ToShortDateString()}", false, textFormat);
                par6.Alignment = Alignment.right;
                par6.SpacingBefore(40);

                doc.Save();

                Process.Start("WINWORD.EXE", $@"{config.path}ОтчетРаботыПО.docx");
        }
    }
}
