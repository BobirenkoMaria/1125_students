using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewPrepodsVM : BaseVM
    {
        private Group selectedGroup;
        private List<Prepod> prepodsBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                PrepodsBySelectedGroup = SqlModel.GetInstance().SelectPrepods(selectedGroup);
                Signal();
            }
        }
        public List<Prepod> PrepodsBySelectedGroup
        {
            get => prepodsBySelectedGroup;
            set
            {
                prepodsBySelectedGroup = value;
                Signal();
            }
        }
        public Prepod SelectedPrepod { get; set; }

        public ViewPrepodsVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}
