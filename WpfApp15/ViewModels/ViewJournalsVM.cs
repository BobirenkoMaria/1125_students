using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewJournalsVM : BaseVM
    {
        private Group selectedGroup;
        private List<Journal> journalsBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                JournalsBySelectedGroup = SqlModel.GetInstance().SelectJournals(selectedGroup);
                Signal();
            }
        }
        public List<Journal> JournalsBySelectedGroup
        {
            get => journalsBySelectedGroup;
            set
            {
                journalsBySelectedGroup = value;
                Signal();
            }
        }
        public Journal SelectedJournal { get; set; }

        public ViewJournalsVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}
