using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    class MainVM : BaseVM
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        public CommandVM CreateGroup { get; set; }
        public CommandVM ViewGroups { get; set; }
        public CommandVM CreateStudent { get; set; }
        public CommandVM ViewStudents { get; set; }
        public CommandVM CreateCurator { get; set; }
        public CommandVM ViewCurators { get; set; }
        public CommandVM CreatePrepod { get; set; }
        public CommandVM ViewPrepods { get; set; }
        public CommandVM CreateSpecial { get; set; }
        public CommandVM ViewSpecials { get; set; }
        public CommandVM CreateDiscipline { get; set; }
        public CommandVM ViewDisciplines { get; set; }
        public CommandVM CreateJournal { get; set; }
        public CommandVM ViewJournals { get; set; }


        public MainVM()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;
            currentPageControl.SetPage(new OptionPage());
            CreateGroup = new CommandVM(() => {
                currentPageControl.SetPage(new EditGroupPage(new EditGroupVM(currentPageControl)));
            });
            ViewGroups = new CommandVM(() => {
                currentPageControl.SetPage(new ViewGroupsPage());
            });
            CreateStudent = new CommandVM(() => {
                currentPageControl.SetPage(new EditStudentPage(new EditStudentVM(currentPageControl)));
            });
            ViewStudents = new CommandVM(()=> {
                currentPageControl.SetPage(new ViewStudentsPage(null));
            });
            CreateCurator = new CommandVM(() => {
                currentPageControl.SetPage(new EditCuratorPage(new EditCuratorVM(currentPageControl)));
            });
            ViewCurators = new CommandVM(() => {
                currentPageControl.SetPage(new ViewCuratorsPage(null));
            });
            CreatePrepod = new CommandVM(() => {
                currentPageControl.SetPage(new EditPrepodPage(new EditPrepodVM(currentPageControl)));
            });
            ViewPrepods = new CommandVM(() => {
                currentPageControl.SetPage(new ViewPrepodsPage(null));
            });
            CreateSpecial = new CommandVM(() => {
                currentPageControl.SetPage(new EditSpecialPage(new EditSpecialVM(currentPageControl)));
            });
            ViewPrepods = new CommandVM(() => {
                currentPageControl.SetPage(new ViewSpecialsPage(null));
            });
            CreateDiscipline = new CommandVM(() => {
                currentPageControl.SetPage(new EditDisciplinePage(new EditDisciplineVM(currentPageControl)));
            });
            ViewDisciplines = new CommandVM(() => {
                currentPageControl.SetPage(new ViewDisciplinesPage(null));
            });
            CreateJournal = new CommandVM(() => {
                currentPageControl.SetPage(new EditJournalPage(new EditJournalVM(currentPageControl)));
            });
            ViewJournals = new CommandVM(() => {
                currentPageControl.SetPage(new ViewJournalsPage(null));
            });
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
