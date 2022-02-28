using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewDisciplinesVM : BaseVM
    {
        private Group selectedGroup;
        private List<Discipline> disciplinesBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                DisciplinesBySelectedGroup = SqlModel.GetInstance().SelectDisciplines(selectedGroup);
                Signal();
            }
        }
        public List<Discipline> DisciplinesBySelectedGroup
        {
            get => disciplinesBySelectedGroup;
            set
            {
                disciplinesBySelectedGroup = value;
                Signal();
            }
        }
        public Discipline SelectedDiscipline { get; set; }

        public ViewDisciplinesVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}
