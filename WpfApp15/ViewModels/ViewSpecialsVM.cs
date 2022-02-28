using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewSpecialsVM : BaseVM
    {
        private Group selectedGroup;
        private List<Specials> specialsBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                SpecialsBySelectedGroup = SqlModel.GetInstance().SelectSpecials(selectedGroup);
                Signal();
            }
        }
        public List<Specials> SpecialsBySelectedGroup
        {
            get => specialsBySelectedGroup;
            set
            {
                specialsBySelectedGroup = value;
                Signal();
            }
        }
        public Prepod SelectedSpecial { get; set; }

        public ViewSpecialsVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}
