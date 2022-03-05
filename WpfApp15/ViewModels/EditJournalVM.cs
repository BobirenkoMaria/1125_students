using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditJournalVM : BaseVM
    {
        public Journal EditJournal { get; }
        public CommandVM SaveJournal { get; set; }
        public Group JournalGroup
        {
            get => journalGroup;
            set
            {
                journalGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group journalGroup;

        public EditJournalVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditJournal = new Journal();
            Init();
        }

        public EditJournalVM(Journal editJournal, CurrentPageControl currentPageControl)
        {
            EditJournal = editJournal;
            this.currentPageControl = currentPageControl;
            Init();
            //            CuratorGroup = Groups.FirstOrDefault(s => s.ID == editCurator.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SaveJournal = new CommandVM(() => {
                if (EditJournal.Value < 2 || EditJournal.Value > 5)
                {
                    System.Windows.MessageBox.Show("Оценка должна быть в пределе от 2 до 5");
                    return;
                }
                //                EditCurator.GroupId = CuratorGroup.ID;
                var model = SqlModel.GetInstance();
                if (EditJournal.ID == 0)
                    model.Insert(EditJournal);
                else
                    model.Update(EditJournal);
                currentPageControl.SetPage(new ViewJournalsPage(JournalGroup));
            });
        }

    }
}
